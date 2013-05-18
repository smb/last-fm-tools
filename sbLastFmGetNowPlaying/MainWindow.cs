using ExpanderApp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbLastFmGetNowPlaying
{
    public partial class MainWindow : Form
    {
        /*
         * String user = Properties.Settings.Default.user;
         * String apiKey = Properties.Settings.Default.apiKey;
         * String defaultTarget = Properties.Settings.Default.defaultTarget; 
         */

        String user;
        String apiKey;
        String defaultTarget;
        String url = "http://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user={0}&api_key={1}&format=json";
        String time;
        String defaultPrefix;
        int iTime;

        public MainWindow()
            {
            Dictionary<string, string> Properties = new Dictionary<string, string>();

            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();


            try
            {
                Properties = GetProperties("settings.ini");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("settings.ini not found");              
                Environment.Exit(-1);
            }

            try
            {
                user = Properties["user"];
                apiKey = Properties["apiKey"];
                defaultTarget = Properties["targetFile"];
                time = Properties["time"];                
                defaultPrefix = Properties["prefix"];
                //time = "1000";
            }
            catch (KeyNotFoundException ex) {
                MessageBox.Show("settings-key not found (needed variables: user, apiKey, defaultTarget, time, prefix)");
                Environment.Exit(-1);
            }

            if (user == null || apiKey == null || defaultTarget == null || time == null || user.Equals("xxxxxx") || apiKey.Equals("xxxxxx"))
            {
                MessageBox.Show("invalid settings.ini (needed Variables: user, apiKey, defaultTarget, time)");
                Environment.Exit(-1);
            }

            try
            {
                iTime = Convert.ToInt32(time);
                if (iTime < 5000 || iTime > Int32.MaxValue)
                {
                    throw new FormatException();                        
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("invalid time value (must be numeric and >= 5000): " + time);
                Environment.Exit(-1);
            }

            InitializeComponent();

            timer1.Interval = iTime;            

            Expander debugExpander = new Expander();
            debugExpander.Size = new System.Drawing.Size(325, 230);
            debugExpander.Location = new System.Drawing.Point(4, 165);
            debugExpander.BorderStyle = BorderStyle.FixedSingle;

            ExpanderHelper.CreateLabelHeader(debugExpander, "Debug-Output", SystemColors.ActiveBorder, new Bitmap(thisExe.GetManifestResourceStream("sbLastFmGetNowPlaying.Resources.ExpandImage.png")), new Bitmap(thisExe.GetManifestResourceStream("sbLastFmGetNowPlaying.Resources.CollapseImage.png")));
            
            this.tbOutputWindow.Location = new System.Drawing.Point(0, 0);
            this.tbOutputWindow.Multiline = true;
            this.tbOutputWindow.Name = "tbOutputWindow";
            this.tbOutputWindow.ReadOnly = true;           
            this.tbOutputWindow.TabIndex = 7;
            this.tbOutputWindow.Size = new System.Drawing.Size(debugExpander.Width, 200);
            debugExpander.Content = tbOutputWindow;
            debugExpander.Collapse();

            ExpanderHelper.CreateLabelHeader(debugExpander, "Debug-Output", SystemColors.ActiveBorder, new Bitmap(thisExe.GetManifestResourceStream("sbLastFmGetNowPlaying.Resources.ExpandImage.png")), new Bitmap(thisExe.GetManifestResourceStream("sbLastFmGetNowPlaying.Resources.CollapseImage.png")));


            this.Controls.Add(debugExpander);

            
        }

        public string CurrentVersion
        {
            get
            {
                return ApplicationDeployment.IsNetworkDeployed
                       ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                       : Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }   

        private void Form1_Load(object sender, EventArgs e)
        {
            tbFileLocation.Text = defaultTarget;

            tbPrefix.Text = defaultPrefix;

            
            linkLabelSource.Links.Add(8, 36, "https://github.com/smb/last-fm-tools");

            
            linkLabelAuthor.Links.Add(8, 35, "mailto:sb@sbuehl.com?subject=last-fm-tools");


            this.Text = Assembly.GetExecutingAssembly().GetName().Name +" " + CurrentVersion;
        }

        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url).Replace("#", "").Replace("@", "");
                }
                catch (Exception e) {
                    System.Console.WriteLine(e.Message);
                    
                }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var data = _download_serialized_json_data<RootObject>(String.Format(url, user, apiKey));

                if (data.error != null)
                {
                    printText(String.Format("Error (#{0}): {1}", data.error, data.message));
                }
                else
                {
                    foreach (Track track in data.recenttracks.track)
                    {
                        //System.Console.WriteLine(track.name);                    

                        if (track.attr != null && track.attr.nowplaying.Equals("true"))
                        {
                            tbArtist.Text = track.artist.text;
                            tbTitle.Text = track.name;

                            if (tbFileLocation.Text != null)
                            {
                                saveToFile(track.artist.text, track.name, track.url, this.tbPrefix.Text);
                            }

                            printText("np:", false);
                        }

                        printText(track.name);
                    }
                }
            }
            catch (Exception ex) {
                printText("Ex: " + ex.Message);
            }

            printText("===================================");            
                
        }

        public void printText(String text, bool newLine = true)
        {

            if (newLine)
            {
                System.Console.WriteLine(text);
                tbOutputWindow.AppendText(text + Environment.NewLine);
            }
            else
            {
                System.Console.Write(text);
                tbOutputWindow.AppendText(text);
            }
        }

        private void saveToFile(string artist, string track, string url, string prefix) 
        {
            if (tbFileLocation.Text != null && tbFileLocation.Text != "")
            {
                TextWriter tw = new StreamWriter(tbFileLocation.Text);
                string outText = String.Format("{0}{1} - {2}", prefix, artist, track);
                tw.Write(outText);
                printText("Write to File: " + outText);
                tw.Flush();
                tw.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbFileLocation.Text = saveFileDialog1.FileName;
            }
        }

        public static Dictionary<string, string> GetProperties(string path)
        {
            string fileData = "";
            using (StreamReader sr = new StreamReader(path))
            {
                fileData = sr.ReadToEnd().Replace("\r", "");
            }
            Dictionary<string, string> Properties = new Dictionary<string, string>();
            string[] kvp;
            string[] records = fileData.Split("\n".ToCharArray());
            foreach (string record in records)
            {
                kvp = record.Split("=".ToCharArray());
                Properties.Add(kvp[0], kvp[1]);
            }
            return Properties;
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

            String url = e.Link.LinkData as string;
            System.Console.WriteLine("link: " + url);
            ProcessStartInfo psi = new ProcessStartInfo(url);
            Process.Start(psi);
        }
    }
}

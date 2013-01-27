using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbLastFmGetNowPlaying
{
    public partial class Form1 : Form
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

        public Form1()
        {
            Dictionary<string, string> Properties = new Dictionary<string, string>();

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
            }
            catch (KeyNotFoundException ex) {
                MessageBox.Show("settings-key not found");
                Environment.Exit(-1);
            }

            if (user == null || apiKey == null || defaultTarget == null || user.Equals("xxxxxx") || apiKey.Equals("xxxxxx"))
            {
                MessageBox.Show("invalid settings.ini");
                Environment.Exit(-1);
            }

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = defaultTarget;
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
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var data = _download_serialized_json_data<RootObject>(String.Format(url, user, apiKey));

                foreach (Track track in data.recenttracks.track)
                {
                    System.Console.WriteLine(track.name);

                    if (track.attr != null && track.attr.nowplaying.Equals("true"))
                    {
                        textBox1.Text = track.artist.text;
                        textBox2.Text = track.name;

                        if (textBox3.Text != null)
                        {
                            saveToFile(track.artist.text, track.name, track.url);
                        }
                    }
                }
            }
            catch (Exception) { }

            System.Console.WriteLine("===================================");
                
        }

        private void saveToFile(string artist, string track, string url)
        {
            if (textBox3.Text != null && textBox3.Text != "")
            {
                TextWriter tw = new StreamWriter(textBox3.Text);
                tw.Write(String.Format("{0} - {1}", artist, track));
                tw.Flush();
                tw.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox3.Text = saveFileDialog1.FileName;
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
    }
}

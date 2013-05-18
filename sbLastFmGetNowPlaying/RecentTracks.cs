using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbLastFmGetNowPlaying
{
public class Artist
{
    public string text { get; set; }
    public string mbid { get; set; }
}

public class Album
{
    public string text { get; set; }
    public string mbid { get; set; }
}

public class Image
{
    public string text { get; set; }
    public string size { get; set; }
}

public class Date
{
    public string text { get; set; }
    public string uts { get; set; }
}

public class Track
{
    public Artist artist { get; set; }
    public string name { get; set; }
    public string streamable { get; set; }
    public string mbid { get; set; }
    public Album album { get; set; }
    public string url { get; set; }
    public List<Image> image { get; set; }
    public Attr attr { get; set; }
    public Date date { get; set; }
}

public class Attr2
{
    public string user { get; set; }
    public string page { get; set; }
    public string perPage { get; set; }
    public string totalPages { get; set; }
    public string total { get; set; }
}

public class Attr
{
    public string nowplaying { get; set; }
}

public class Recenttracks
{
    public List<Track> track { get; set; }
    public Attr2 attr { get; set; }
}

public class RootObject
{
    public Recenttracks recenttracks { get; set; }
    public string error { get; set; }
    public string message { get; set; }
    public List<string> links { get; set; }
}
}

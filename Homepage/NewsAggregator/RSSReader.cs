using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Spatial;
using System.Text;
using System.Threading.Tasks;

namespace Homepage.NewsAggregator
{
    public class RSSReader
    {
		private List<string> xmlUrls = new List<string>() { "http://thehill.com/rss/syndicator/19110", "https://hnrss.org/frontpage" };


		public RSSReader()
	    {   
	    }

	    public void ProcessRssXml()
	    {

	    }

	    public void ReadRssXml()
	    {

	    }

	    public IEnumerable<string> GetRssUrlsList()
	    {
			IEnumerable<string> fullList = new List<string>();



		    return fullList;
	    }

	    public List<string> GetRssUrl(string urlAddress)
	    {
		    List<string> feedUrls = new List<string>();
			
		    try
		    {
			    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
			    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

				if (response.StatusCode == HttpStatusCode.OK)
			    {
				    Stream receiveStream = response.GetResponseStream();
				    StreamReader readStream = null;
				    if (response.CharacterSet == null)
					    readStream = new StreamReader(receiveStream);
				    else
					    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
				    string data = readStream.ReadToEnd();
				    response.Close();
				    readStream.Close();

				    System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(data,
					    "<link rel=\"alternate\" type=\"application/rss\\+xml\"(.+?) href=\"(.+?)\"",
					    System.Text.RegularExpressions.RegexOptions.IgnoreCase);

				    while (match.Success)
				    {
					    feedUrls.Add(match.Groups[2].Value);
					    match = match.NextMatch();
				    }
			    }
		    }
		    catch (Exception e)
		    {
			    

		    }
		    
		    return feedUrls;
		}
    }
}

using System;
using System.Threading.Channels;

namespace BAM_Learning
{
	public class ClsCHNFile
	{
		// Instrumentation standard    :SAEJ211, issued 1992
		public string fileHeader = "";
		public int nbrOfChannels;
		public List<ClsCHNLine> channels = new List<ClsCHNLine>();
		

		public ClsCHNFile()
		{

		}

		public void ReadFile()
		{
			// Read in the file and 
			// For the first line of the file, save it as fileHeader. This enables reprinting of the file.
			// For the second line of the file, save the quantity of channels

			ClsCHNLine channel = new ClsCHNLine();

			channels.Add(channel);
		}

		public void WriteFile()
		{
			// Asynchronously write each line 
			// fileHeader, "Number of Channels      :" + nbrOfChannels.toString()
			// Loop through list and combine "Name of channel" + ### + "    :"
			// .PadLeft or .PadRight to keep the spaces
		}

		public void ProcessLine()
		{
			// Separate the file by semi colons, etc
		}
		

	}
}



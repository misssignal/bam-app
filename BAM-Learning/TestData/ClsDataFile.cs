using System;
using System.Threading.Channels;

namespace BAM_Learning
{
	public class ClsDataFile
	{

		/*
		    Channel code                :M0MBARLEMIUPACXP
			Laboratory channel code     :M0MBARLEMIUPACXP
			Customer channel code       :M0MBARLEMIUPACXP
			Reference channel           :implicit
			Reference channel name      :NOVALUE
			Data source                 :transducer
			Test object number          :1
			Name of the channel         :Mobile Barrier Left Middle Upper Acceleration X
			Location                    :M0MBARLEMIUPACXP
			Direction                   :X
			Pre-filter type             :2000
			Channel frequency class     :NOVALUE
			Cut off frequency           :NOVALUE
			Reference system            :local
			Transducer type             :NOVALUE
			Transducer id               :NOVALUE
			Transducer natural frequency:NOVALUE
			Transducer damping ratio    :NOVALUE
			Offset post test            :NOVALUE
			Channel amplitude class     :1472
			Sampling interval           :0.0001
			Unit                        :m/(s*s)
			Time of first sample        :-0.1
			Number of samples           :6000
			First global maximum value  :1.470835E+3
			Time of maximum value       :6.480000E-2
			First global minimum value  :-3.005184E+2
			Time of minimum value       :6.400000E-2
			Dimension                   :AC
			Bit resolution              :16
			Start offset interval       :-1.000000E-2
			End offset interval         :0.000000E+0
			Data status                 :ok
		*/

		public ClsDataFile()
		{

		}
		public void ReadFile()
		{
			// Each line of the MME file is a key value pair
			// If what is to be read in is defined strictly, then it will be easy to identify test objes
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



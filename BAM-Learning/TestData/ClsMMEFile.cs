using System;

namespace BAM_Learning
{
	public class ClsMMEFile
	{
		/*
			Data format edition number  :1.6
			Laboratory name             :BASt
			Laboratory contact name     :Cichos
			Laboratory contact phone    :0049 2204 43624
			Laboratory contact fax      :0049 2204 43687
			Laboratory contact email    :NOVALUE
			Laboratory test ref. number :AK3T02SI
			Customer name               :FAKRA-AK3
			Customer test ref. number   :AK3T02SI
			Customer project ref. number:NOVALUE
			Customer order number       :NOVALUE
			Customer cost unit          :NOVALUE
			Customer test engineer name :NOVALUE
			Customer test engineer phone:NOVALUE
			Customer test engineer fax  :NOVALUE
			Customer test engineer email:NOVALUE
			Title                       :Side Impact Mobile Barrier
			Medium no./number of media  :1/1
			Timestamp                   :2004-06-02 11:26:54
			Type of the test            :Side Impact
			Subtype of the test         :NOVALUE
			Regulation                  :NOVALUE
			Reference temperature       :NOVALUE
			Relative air humidity       :NOVALUE
			Date of the test            :2004-03-22
			Number of test objects      :2
		*/



		public ClsMMEFile()
		{

		}

		public void ReadFile()
		{
			// Each line of the MME file is a key value pair
			// If what is to be read in is defined strictly, then it will be easy to identify test objects
		}

		public void WriteFile()
		{
			// Asynchronously write each line 

		}

		public void ProcessLine()
		{
			// Separate the file by semi colons, etc
		}

	}
}



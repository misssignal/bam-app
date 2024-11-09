using System;

namespace BAM_Learning
{
    public class ClsTestData
    {
        ClsCHNFile channelFile = new ClsCHNFile();
        ClsMMEFile mmeFile = new ClsMMEFile();
        ClsDataFile dataFile = new ClsDataFile();

        public ClsTestData()
        {
            // Path demo
            channelFile.channels[1].mmeCode = "";
        }

    }
}



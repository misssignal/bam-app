using System;

namespace BAM_Learning
{
    public class ClsMMETestObj
    {
        List<string> key = new List<string>();
        List<string> value = new List<string>();


        // The purpose of this is to have a consistent chunk
        // of text and parameters for each Test Object

        /*
            Name of test object 1       :Mobile Barrier
            Velocity test object 1      :13.92
            Mass test object 1          :965
            Driver position object 1    :NOVALUE
            Impact side test object 1   :NOVALUE
            Type of test object 1       :M
            Class of test object 1      :NOVALUE
            Code of test object 1       :NOVALUE
            Ref. number of test object 1:NOVALUE
        */


        public ClsMMETestObj()
        {

        }

        public string GetValueForKey(string parameter)
        {
            if(key.Contains(parameter))
            {
                return value[key.IndexOf(parameter)];
            }
            return "";
        }

    }
}



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrome
{
    class GetResultFromSupport
    {
        public static List<string> readFile(string path)
        {
            List<string> keys = new List<string>();
            StreamReader sr = new StreamReader(path);
            string temp = "";
            string line = "";
            while ((temp = sr.ReadLine()) != null)
            {
                if (temp.Contains("|"))
                {
                    line += temp;
                    keys.Add(line.ToLower());
                    line = "";
                }
                else
                {
                    line += temp + " ";
                }
            }
            sr.Close();
            return keys;
        }

    }
}

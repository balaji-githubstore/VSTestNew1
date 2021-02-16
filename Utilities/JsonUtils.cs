using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenEmrAutomation.Utilities
{
    public class JsonUtils
    {
        public static String GetValue(string key)
        {

            //string path = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            path = path.Substring(0, path.LastIndexOf("bin"));
            path = new Uri(path).LocalPath;
            StreamReader reader = new StreamReader(path + "/testdata/app.json");
            string data = reader.ReadToEnd();

            dynamic jdata = JsonConvert.DeserializeObject(data);
            string value = Convert.ToString(jdata[key]);
            
            return value;
        }

        public void JsonIntoObjectArray(string path,string key)
        {
            path = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")) + "/testdata/app.json";
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();

            dynamic jdata = JsonConvert.DeserializeObject(data);

            object[] main = new object[jdata[key].Count];

            for (int i = 0; i < main.Length; i++)
            {
                object[] temp = new object[jdata[key][i].Count];
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = Convert.ToString(jdata[key][i][j]);
                }
                main[i] = temp;
            }
            Console.WriteLine(main);
        }
    }
}

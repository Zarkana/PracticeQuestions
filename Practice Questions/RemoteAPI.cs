using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Practice_Questions
{
    class RemoteAPI
    {
        public static string URL { get; set; } = "http://ws-7-qadev5:9000";

        public static TestInfo[] tests;       

        public static void InitClient()
        {            
            tests = new TestInfo[] {
                new TestInfo(1, "record 1"),
                new TestInfo(2, "record 3")
            };

            //WebClient client = new WebClient { UseDefaultCredentials = true };

            //string attempt3 = client.DownloadString($"{URL}/api/tests");

            //var baseAddress = "http://www.example.com/1.0/service/action";

            //var http = (HttpWebRequest)WebRequest.Create(new Uri($"{URL}/api/tests"));
            //http.Accept = "application/json";
            //http.ContentType = "application/json";
            //http.Method = "POST";

            //string parsedContent = JsonConvert.SerializeObject(tests);
            //ASCIIEncoding encoding = new ASCIIEncoding();
            //Byte[] bytes = encoding.GetBytes(parsedContent);

            //Stream newStream = http.GetRequestStream();
            //newStream.Write(bytes, 0, bytes.Length);
            //newStream.Close();            

            //try
            //{
            //    var response = http.GetResponse();
            //} catch(Exception ex)
            //{
            //    string error = ReadHttpContent(ex);
            //}

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri($"{URL}/api/tests"));
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(tests);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }                
            }
            catch (Exception ex)
            {
                string error = ReadHttpContent(ex);
            }

            string strCmdText;

            //System.Diagnostics.Process command = new System.Diagnostics.Process();
            //command.StartInfo.FileName = @"cmd";
            //command.StartInfo.UserName = "JoeCampbell";
            //command.StartInfo.Domain = "LD";
            //System.Security.SecureString pwd = new System.Security.SecureString();

            //foreach (char c in "")
            //    pwd.AppendChar(c);

            //command.StartInfo.Password = pwd;
            //command.StartInfo.CreateNoWindow = false;
            //command.StartInfo.Verb = "open";
            //command.StartInfo.UseShellExecute = false;

            
            //    command.Start();
            
            //command.WaitForExit();
            //command.Close();
            //strCmdText = "/c nunit3-console C:\\Users\\JoeCampbell>nunit3-console \"C:\\source\\Workspaces\\EmpowerQAAutomation\\LDAutomation_December2018_PlusUIARefactor\\LoanDepotAutomation\\bin\\Debug\\LoanDepotAutomation.dll\" --test=\"LoanDepotAutomation.Tests.Regression.AUS_verify\"";
            //strCmdText = "/c nunit3-console";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            //System.Diagnostics.Process.Start("cmd");

            using (StreamWriter writer = new StreamWriter(new FileStream("testloader_success.txt", FileMode.Create)))
            {
                writer.WriteLine(JsonConvert.SerializeObject(tests));
            }
        }

        public static string ReadHttpContent(Exception ex)
        {
            var stream = (ex as System.Net.WebException).Response.GetResponseStream();
            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
    }


    class TestInfo
    {
        public int id { get; set; }
        public string command { get; set; }

        public TestInfo(int id, string command)
        {
            this.id = id;
            this.command = command;
        }
    }
}

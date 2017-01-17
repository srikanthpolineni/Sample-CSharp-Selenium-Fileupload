using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Sample_CSharp_Selenium_Fileupload
{
    class Program
    {
        const string browser = "\"Chrome\""; //Chrome/IE/Firefox
        const string path = "\"C:\\test\\test.png\"";

        static void Main(string[] args)
        {
            var webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://www.w3schools.com/jsref/tryit.asp?filename=tryjsref_fileupload_get");
            Thread.Sleep(5000);
            var iframe = webDriver.FindElement(By.Id("iframeResult"));
            webDriver.SwitchTo().Frame(iframe);
            var uploadButton = webDriver.FindElement(By.Id("myFile"));
            uploadButton.Click();



            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "SeleniumFileUpload.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = browser +" " + path;
            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
            }
			//TODO: remaining work

            Console.Read();
        }
    }
}

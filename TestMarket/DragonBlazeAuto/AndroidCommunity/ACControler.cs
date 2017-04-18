using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBlazeAuto.AndroidCommunity
{

    class ACControler
    {
        private string adbRootPath = Path.Combine(Environment.CurrentDirectory, "Lib\\adb.exe");
        private string ErrorHeader = "[***]";

        public string ADBPATH
        {
            get
            {
                return adbRootPath;
            }
            set
            {
                if (File.Exists(value))
                {
                    ADBPATH = value;
                }
            }
        }



        public List<string> GetListDevices()
        {

            string abc = GetEndStandardOutput("devices");

            return new List<string>();
        }

        public void Tap(Point location) {


        }

        private string GetEndStandardOutput(string pstrCommand)
        {
            ProcessStartInfo processInfo = null;
            Process process = null;
            string output = string.Empty;
            try
            {
                processInfo = new ProcessStartInfo(ADBPATH, pstrCommand);
                processInfo.CreateNoWindow = true;
                processInfo.UseShellExecute = false;
                // *** Redirect the output ***
                processInfo.RedirectStandardError = false;
                processInfo.RedirectStandardOutput = true;

                process = Process.Start(processInfo);
                process.WaitForExit();

                // *** Read the streams ***
                output = process.StandardOutput.ReadToEnd();
            }
            catch (Exception objEx)
            {
                return ErrorHeader + Environment.NewLine + objEx.Message;
            }
            finally
            {
                if (process != null)
                    process.Close();
            }
            return output;
        }


    }
}

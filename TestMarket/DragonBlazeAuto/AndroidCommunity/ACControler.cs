using DragonBlazeAuto.Enum;
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
        private const string SHELL_INPUT = " SHELL INPUT ";
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

        public Utility.TapStatus Tap(Point location)
        {
            if (location.IsEmpty) return Utility.TapStatus.LocationEmpty;
            string strResult = GetEndStandardOutput(SHELL_INPUT + " TAP " + location.X + " " + location.Y);

            return Utility.TapStatus.NotError;

        }
        public Utility.TapStatus Tap(string strDeviceID, Point location)
        {

            //string strResult = GetEndStandardOutput();

            return Utility.TapStatus.NotError;

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
                return Utility.ERROR_HEADER + Environment.NewLine + objEx.Message;
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

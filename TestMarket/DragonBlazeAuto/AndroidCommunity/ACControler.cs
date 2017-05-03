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



        public string[] GetListDevices()
        {

            string abc = GetEndStandardOutput("devices");

            return new List<string>();
        }

        public string[] Tap(Point location)
        {
            if (location.IsEmpty) return Utility.TapStatus.LocationEmpty;
            string strResult = GetEndStandardOutput(SHELL_INPUT + " TAP " + location.X + " " + location.Y);

            return Utility.TapStatus.NotError;

        }
        public string[] Tap(string strDeviceID, Point location)
        {

            if (location.IsEmpty) return Utility.TapStatus.LocationEmpty;
            string strResult = GetEndStandardOutput(strDeviceID + SHELL_INPUT + " TAP " + location.X + " " + location.Y);

            return Utility.TapStatus.NotError;

        }
        
        public string[] ResetServer()
        {
            List<string> output = new List<string>();
            
            output.Add(GetEndStandardOutput("kill-server"));
            output.Add(GetEndStandardOutput("start-server"));
            
            return output.ToArray();
        }

        public string[] StopServer()
        {
            string output;

            output = GetEndStandardOutput("kill-server");

            return new string[] { output };
        }


        private string GetEndStandardOutput(string strCommand)
        {
            ProcessStartInfo processInfo = null;
            Process process = null;
            string output = string.Empty;
            try
            {
                processInfo = new ProcessStartInfo(ADBPATH, strCommand);
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
        public Image Screenshot() {
        }
        public Image Screenshot(string DeviceIP)
        {
            ProcessStartInfo processInfo = null;
            Process process = null;
            string output = string.Empty;
            try
            {
                processInfo = new ProcessStartInfo(ADBPATH, "adb connect " + DeviceIP);
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
                return null;
            }
            finally
            {
                if (process != null)
                    process.Close();

            }
            return null;
        }

    }
}

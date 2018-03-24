using System;
using System.Xml;
using System.IO;

namespace BotServer
{
    internal class Configuration
    {
        // servo positions in microseconds
        // get these values from the Maestro Control Center application
        public int ToolheadGrab = 1160;
        public int ToolheadRelease = 2000;
        public int YAxisDown = 968;
        public int YAxisStop = 950;
        public int YAxisUp = 935;
        public int PivotInTray = 2527;
        public int PivotDrive = 2145;
        public int PivotOutTray = 1783;

        // maximum time for toolhead to complete a move, in milliseconds
        public int MaxToolheadMoveTime = 5000;
        // maximum time for pivot to complete a move
        public int MaxPivotMoveTime = 15000;
        // time it takes to lower disc to drive tray
        public int YAxisLowertoDriveTime = 4900;
        // time it takes to lower to out tray drop point
        public int YAxisLowertoOutTrayDropTime = 3000;
        // time to allow pivot motion to settle
        public int PivotSettleTime = 1000;

        // pivot speed and acceleration
        public int PivotSpeed = 8;
        public int PivotAcceleration = 0;

        // toolhead speed and acceleration
        public int ToolheadSpeed = 20;
        public int ToolheadAcceleration = 1;

        public string MaestroPort = @"/dev/ttyACM0";

        /// <summary>
        /// Loads a configuation from a file
        /// </summary>
        /// <param name="FileName">Path and name of configuration file</param>
        public void Load
            (
            string FileName
            )
        {
            // check file exists
            if (!File.Exists(FileName))
            {
                throw new Exception(String.Format("The file {0} cannot be found", FileName));
            }

            var document = new XmlDocument();
            using (XmlReader Reader = new XmlTextReader(FileName))
            {
                document.Load(Reader);
            }

            ToolheadGrab = int.Parse(document.SelectSingleNode("//ToolheadGrab").InnerText);
            ToolheadRelease = int.Parse(document.SelectSingleNode("//ToolheadRelease").InnerText);
            YAxisDown = int.Parse(document.SelectSingleNode("//YAxisDown").InnerText);
            YAxisStop = int.Parse(document.SelectSingleNode("//YAxisStop").InnerText);
            YAxisUp = int.Parse(document.SelectSingleNode("//YAxisUp").InnerText);
            PivotInTray = int.Parse(document.SelectSingleNode("//PivotInTray").InnerText);
            PivotDrive = int.Parse(document.SelectSingleNode("//PivotDrive").InnerText);
            PivotOutTray = int.Parse(document.SelectSingleNode("//PivotOutTray").InnerText);
            MaxToolheadMoveTime = int.Parse(document.SelectSingleNode("//MaxToolheadMoveTime").InnerText);
            MaxPivotMoveTime = int.Parse(document.SelectSingleNode("//MaxPivotMoveTime").InnerText);
            YAxisLowertoDriveTime = int.Parse(document.SelectSingleNode("//YAxisLowertoDriveTime").InnerText);
            YAxisLowertoOutTrayDropTime = int.Parse(document.SelectSingleNode("//YAxisLowertoOutTrayDropTime").InnerText);
            PivotSettleTime = int.Parse(document.SelectSingleNode("//PivotSettleTime").InnerText);
            PivotSpeed = int.Parse(document.SelectSingleNode("//PivotSpeed").InnerText);
            PivotAcceleration = int.Parse(document.SelectSingleNode("//PivotAcceleration").InnerText);
            ToolheadSpeed = int.Parse(document.SelectSingleNode("//ToolheadSpeed").InnerText);
            ToolheadAcceleration = int.Parse(document.SelectSingleNode("//ToolheadAcceleration").InnerText);
            MaestroPort = document.SelectSingleNode("//MaestroPort").InnerText;
        }
    }
}

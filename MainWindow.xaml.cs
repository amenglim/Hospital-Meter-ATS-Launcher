using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Xml;
//using Hospital_Meter_ATS_Launcher.Resources.SVN;

namespace Hospital_Meter_ATS_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Version based on number of GitHub commits.
        //const string Version = "1.0." + SvnInfo.REVISION;
        //const string BuildDate = SvnInfo.BUILD_DATE;
        const string Version = "1.0.";
        const string BuildDate = "10/25/2023";
        const string Author = "Anthony Meng-Lim";

        private const string ApplicationInformationFile = @"C:\Hospital Meter ATS\Configurations\ApplicationInformation.xml";
        public static string HospitalMeterATSPath = "";
        public static string MochaTN5250Path = "";
        public static string MeterAttributesEditorPath = "";
        public static string HospitalMeterDockATSPath = "";

        public static Process processInfo = null;

        public MainWindow()
        {
            InitializeComponent();

            GetApplicationInformation();

            Title = "Hospital Meter ATS Launcher " + Version;

        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menuVersion_Click(object sender, RoutedEventArgs e)
        {
            string versionInfo = "Version: " + Version + "\n\n" +
                     "Author: " + Author + "\n\n" +
                     "Build Date: " + BuildDate;

            MessageBox.Show(versionInfo, "Version Information");
        }

        // Get the software files directory information.
        private static void GetApplicationInformation()
        {
            XmlReaderSettings xmlReaderSetting = new()
            {
                // This is set to Parse as we want to allow use of DTD.
                DtdProcessing = DtdProcessing.Parse
            };

            // This is the XML reader object that will open the file and be used to access the objects within.
            XmlReader xmlReader = XmlReader.Create(ApplicationInformationFile, xmlReaderSetting);

            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    // Each node is considered an Element.
                    case XmlNodeType.Element:
                        // Get the location of the Strip Reader Software Files first.
                        if (xmlReader.HasAttributes)
                        {
                            if (xmlReader.GetAttribute(0) == "HospitalMeterATS")
                            {
                                HospitalMeterATSPath = xmlReader.ReadInnerXml();
                            }
                            else if (xmlReader.GetAttribute(0) == "MochaTN5250")
                            {
                                MochaTN5250Path = xmlReader.ReadInnerXml();
                            }
                            else if (xmlReader.GetAttribute(0) == "MeterAttributes")
                            {
                                MeterAttributesEditorPath = xmlReader.ReadInnerXml();
                            }
                            else if (xmlReader.GetAttribute(0) == "HospitalMeterDockATS")
                            {
                                HospitalMeterDockATSPath = xmlReader.ReadInnerXml();
                            }
                        }
                        break;
                }
            }
        }

        private void HospitalMeterATS_Click(object sender, RoutedEventArgs e)
        {
            string hospitalMeterPath = HospitalMeterATSPath;

            if (File.Exists(hospitalMeterPath))
            {
                Process meterconfig = new()
                {
                    // This opens Hospital Meter ATS app no matter which version the PC has.
                    StartInfo = new ProcessStartInfo(hospitalMeterPath)
                    {
                        UseShellExecute = true,
                        RedirectStandardOutput = false,
                        CreateNoWindow = false
                    }
                };
                Application.Current.Shutdown();
                meterconfig.Start();
            }
            else
            {
                MessageBox.Show(hospitalMeterPath + " does not exist. Please make sure the program is downloaded to the correct path.\n");
            }
        }

        private void MochaTN5250_Click(object sender, RoutedEventArgs e)
        {
            string mochaTN5250Path = MochaTN5250Path;

            if (File.Exists(mochaTN5250Path))
            {
                Process.Start(mochaTN5250Path);
            }
            else
            {
                MessageBox.Show(mochaTN5250Path + " does not exist. Please make sure the program is downloaded to the correct path.\n");
            }
        }

        private void meterConfigurationUtility_Click(object sender, RoutedEventArgs e)
        {
            string meterConfigPath = MeterAttributesEditorPath;

            if (File.Exists(meterConfigPath))
            {
                Process meterconfig = new()
                {
                    // This opens Excel no matter which version the PC has.
                    StartInfo = new ProcessStartInfo(meterConfigPath)
                    {
                        UseShellExecute = true,
                        RedirectStandardOutput = false,
                        CreateNoWindow = false
                    }
                };
                meterconfig.Start();
            }
            else
            {
                MessageBox.Show(meterConfigPath + " does not exist. Please make sure the program is downloaded to the correct path.\n");
            }


        }

        private void HospitalMeterDockATS_Click(object sender, RoutedEventArgs e)
        {
            string hospitalMeterDockATSPath = HospitalMeterDockATSPath;


            if (File.Exists(hospitalMeterDockATSPath))
            {
                Process hospitalMeterDockATS = new()
                {
                    // This opens Excel no matter which version the PC has.
                    StartInfo = new ProcessStartInfo(hospitalMeterDockATSPath)
                    {
                        UseShellExecute = true,
                        RedirectStandardOutput = false,
                        CreateNoWindow = false
                    }
                };
                hospitalMeterDockATS.Start();
            }
            else
            {
                MessageBox.Show(hospitalMeterDockATSPath + " does not exist. Please make sure the program is downloaded to the correct path.\n");
            }
        }
    }
}

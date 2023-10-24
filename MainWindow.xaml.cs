using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Hospital_Meter_ATS_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Version based on number of GitHub commits.
        const string Version = "V0.2";
        const string BuildDate = "10/23/2023";
        const string Author = "Anthony Meng-Lim";
        public static Process processInfo = null;

        public MainWindow()
        {
            InitializeComponent();
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
        private void HospitalMeterATS_Click(object sender, RoutedEventArgs e)
        {
            string hospitalMeterPath = @"C:\Users\amenglim\Desktop\Hospital Meter ATS - Shortcut.lnk";

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
            string mochaTN5250Path = "C:\\Program Files (x86)\\MochaSoft\\Mocha TN5250 for Vista\\tn5250.exe";

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
            string meterConfigPath = @"C:\Users\amenglim\Desktop\Meter Attributes Editor.lnk";
            string path = @"C:\Users\amenglim\Desktop\Meter Attributes Editor - Shortcut.lnk";

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
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;

namespace Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DownloadClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Directory.Exists("Client"))
                {
                    Directory.Delete("Client", true);
                }
                Directory.CreateDirectory("Client");
                var client = new WebClient();
                client.DownloadFile("https://localhost:44352/api/client", "Client/Client.zip");
                ZipFile.ExtractToDirectory("Client/Client.zip", "Client/");
            }
            catch (Exception ex)
            {
                Exception.Text = ex.ToString();
            }
        }

        private void DownloadData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Directory.Exists("Data"))
                {
                    Directory.Delete("Data", true);
                }
                Directory.CreateDirectory("Data");
                var client = new WebClient();
                client.DownloadFile("https://localhost:44352/api/bundles/primitives/binary", "Data/primitives");
                client.DownloadFile("https://localhost:44352/api/bundles/terrains/binary", "Data/terrains");
            }
            catch (Exception ex)
            {
                Exception.Text = ex.ToString();
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var p = new Process();
                p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "/Client";
                p.StartInfo.FileName = Directory.GetCurrentDirectory() + "/Client/Client.exe";
                p.Start();
            }
            catch (Exception ex)
            {
                Exception.Text = ex.ToString();
            }
        }
    }
}

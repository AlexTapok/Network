using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace FileSendClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class FileDetails
        {
            public string Type = "";
            public long Size = 0;

            public string TYPE { get; set; }
            public long SIZE { get; set; }
        }

        private static FileDetails Dfile;
        //public static string Status = null;
        private static int Port = 7000;
        private static UdpClient Client = new UdpClient(Port);
        private static IPEndPoint IpEnd = null;

        private static FileStream fs;
        private static Byte[] receiveBytes = new Byte[0];

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                GetFileDetails();
                ReciveFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void ReciveFile()
        {
            try
            {
                tbxStatus.Text += "Wait to recive file\n";
                receiveBytes = Client.Receive(ref IpEnd);

                tbxStatus.Text += "File recived ... Save\n";
                fs = new FileStream("temp." + Dfile.Type, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Write(receiveBytes, 0, receiveBytes.Length);

                tbxStatus.Text += "File is Saved\n";
                Thread.Sleep(2000);
                tbxStatus.Text += "File Opened\n";

                Process.Start(fs.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
                Client.Close();
            }
        }
        public void GetFileDetails()
        {
            try
            {
                tbxStatus.Text += "Wait resive file details\n";
                receiveBytes = Client.Receive(ref IpEnd);
                tbxStatus.Text += "file details resived\n";


                XmlSerializer fileSerializer = new XmlSerializer(typeof(FileDetails));
                MemoryStream stream1 = new MemoryStream();

                stream1.Write(receiveBytes, 0, receiveBytes.Length);
                stream1.Position = 0;

                Dfile = (FileDetails)fileSerializer.Deserialize(stream1);

                tbxStatus.Text += "Recived file type ." + Dfile.TYPE +
                    " file size " + Dfile.SIZE.ToString() + " bytes\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}

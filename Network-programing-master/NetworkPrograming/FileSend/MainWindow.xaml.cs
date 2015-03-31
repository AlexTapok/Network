using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace FileSend
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Serializable]
        public class FileDatalies
        {
            public string Type = "";
            public long Size = 0;
            public long SIZE { get; set; }
            public string TYPE { get; set; }
    
        }

        private static UdpClient Client = new UdpClient();

        

        private static IPAddress ipAdreses;
        private static IPEndPoint IpEnd;
        private const int port = 7000;
        public static FileDatalies Dfile = new FileDatalies();
      

        private static FileStream fs;

        public MainWindow()
        {
            InitializeComponent();
        }

    

        public static void SendFileInfo()
        {
            Dfile.TYPE = fs.Name.Substring((int)fs.Name.Length - 3 , 3);
            Dfile.SIZE = fs.Length;

            XmlSerializer fileSerializer = new XmlSerializer(typeof(FileDatalies));
            MemoryStream memoryStream = new MemoryStream();

           fileSerializer.Serialize(memoryStream, Dfile);
          
                
          

            memoryStream.Position = 0;
            Byte[] bytes = new Byte[memoryStream.Length];
            memoryStream.Read(bytes, 0, Convert.ToInt32(memoryStream.Length));
            MessageBox.Show("Send File Info");

            Client.Send(bytes, bytes.Length, IpEnd);
            MessageBox.Show(bytes[0] + " " +bytes.Length + " " + IpEnd);
            memoryStream.Close();

        }


        private void btnSend_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ipAdreses = IPAddress.Parse(tbxIP.Text);
                IpEnd = new IPEndPoint(ipAdreses, port);
                fs = new FileStream(@tbxPath.Text, FileMode.Open, FileAccess.Read);

                if (fs.Length > 8192)
                {
                    MessageBox.Show("File size biggest than 8kb");
                    Client.Close();
                    fs.Close();
                    return;
                }

                SendFileInfo();

                Thread.Sleep(1000);

                SendFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void SendFile()
        {
            Byte[] bytes = new Byte[fs.Length];

            fs.Read(bytes, 0, bytes.Length);
            MessageBox.Show("Send file with size " + fs.Length + "bytes");
            try
            {
                Client.Send(bytes, bytes.Length, IpEnd);
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
            MessageBox.Show("File Sended");
        }
    }
}

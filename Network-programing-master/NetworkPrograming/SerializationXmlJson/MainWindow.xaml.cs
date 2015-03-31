using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace SerializationXmlJson
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Human
        {
            public string FName;
            public string LName;
            public int Age;

            public Human()
            {
            }
                

            public Human(string fname , string lname , int age)
            {
                FName = fname;
                LName = lname;
                Age  = age;
            }

            public string fNAME { get; set; }
            public string lNAME { get; set; }
            public int AGE { get; set; }

           

        }
        public static bool isJson = false;
        public MainWindow()
        {
            InitializeComponent();
            btnStart.IsEnabled = false;
            btnEnd.IsEnabled = false;
        }
        public void SerializeXml()
        {
            try
            {
               

                XmlSerializer serializer = new XmlSerializer(typeof(Human));
                Human human = new Human();
                human.fNAME = "a";
                human.lNAME = "b";
                human.AGE = 50;
                TextWriter writer = new StreamWriter(@"C:\Users\Serhiy\Desktop\aaa.txt");
                serializer.Serialize(writer, human);
                writer.Close();
                MessageBox.Show("Serialized");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeserializeXml()
        {
            try
            {
                Human human = new Human();
                XmlSerializer serializer = new XmlSerializer(typeof(Human));
                TextReader reader = new StreamReader(@"C:\Users\Serhiy\Desktop\aaa.txt");
               human = (Human)serializer.Deserialize(reader);
               tbx_Data.Text = "First Name "+  
                   human.fNAME + "\n" + "Last Name "+human.lNAME + "\n" +"Age " +human.AGE;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SerializeJSON()
        {
            Human human = new Human();
            human.fNAME = "Json";
            human.lNAME = "Serialization";
            human.AGE = 2;
           
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Human));
            ser.WriteObject(stream, human);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            tbx_Data.Text = "JSON form of Person object:\n";
            tbx_Data.Text += sr.ReadToEnd() + "\n";
            stream.Position = 0;
            Human human1 = (Human)ser.ReadObject(stream);
            tbx_Data.Text += "------Deserialized--------\n";
            tbx_Data.Text += "First Name: " + human1.fNAME + "\n";
            tbx_Data.Text += "Last Name: " + human1.lNAME + "\n";
            tbx_Data.Text += "Age: " + human1.AGE + "\n";

            stream.Close();
            sr.Close();
        }

        private void btnStart_Click_1(object sender, RoutedEventArgs e)
        {
            if (isJson == true)
            {
                SerializeJSON();
            }
            else
            {
                SerializeXml();
            }
         
            
        }

        private void btnEnd_Click_1(object sender, RoutedEventArgs e)
        {
            DeserializeXml();
        }

        private void rb_Xml_Checked_1(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = true;
            btnEnd.IsEnabled = true;
            lbl_Status.Content = "\tXml Serialization";
            isJson = false;
            tbx_Data.Text = "";
        }

        private void rb_Json_Checked_1(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = true;
            btnEnd.IsEnabled = false;
            lbl_Status.Content = "\tJson Serialization";
            tbx_Data.Text = "";
            isJson = true;
        }
    }
}

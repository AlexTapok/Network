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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Child2.xaml
    /// </summary>
    public partial class Child2 : Window
    {
        public Window ParentWin;
        DateTime start;
        int keyToPress;
        public Child2()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            TextBox2.Text += "\nparent: " + ParentWin.Name;
        }

        private void StartGame_Click_1(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            keyToPress = r.Next(65, 90);
            char ch = (char) keyToPress;
            key.Text = "Enter " + keyToPress + " " + ch;
            start = DateTime.Now;
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            pressed.Text = KeyInterop.VirtualKeyFromKey(e.Key) + " " + e.Key;
            if (KeyInterop.VirtualKeyFromKey(e.Key) == keyToPress)
            {
                TimeSpan span = DateTime.Now - start;
                key.Text = span.TotalMilliseconds + "ms";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread thread = null;
        Child1 ch1 = null;
        Process proc = new Process();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void start_Click_1(object sender, RoutedEventArgs e)
        {
            proc.StartInfo.FileName = "calc.exe";
            proc.Start();
        }

        private void stop_Click_1(object sender, RoutedEventArgs e)
        {
            proc.CloseMainWindow();
            proc.Close();
        }

        private void get_Click_1(object sender, RoutedEventArgs e)
        {
            string list = null;
            Process[] processes = Process.GetProcesses();
            foreach (var p in processes)
            {
                list += p.ProcessName + "\t" + p.Id + "\n";
            }
            MessageBox.Show(list);
        }

        private void loadDll_Click_1(object sender, RoutedEventArgs e)
        {
            Assembly asm = Assembly.Load(AssemblyName.GetAssemblyName("SampleLibrary.dll"));
            Module mod = asm.GetModule("SampleLibrary.dll");
            Type Person = mod.GetType("SampleLibrary.Person") as Type;
            object per = Activator.CreateInstance(Person, new object[] { "Royko", "Serhiy", 18 });
            MessageBox.Show(Convert.ToString(Person.GetMethod("Print").Invoke(per, null)));

        }

        private void child1_Click_1(object sender, RoutedEventArgs e)
        {
            ch1 = new Child1();
            ch1.ParentWin = this;
            ch1.TextBox2.Text = changeChild1.Text;
            ch1.Show();
        }

        private void child2_Click_1(object sender, RoutedEventArgs e)
        {
            Child2 ch2 = new Child2();
            ch2.ParentWin = this;
            ch2.TextBox2.Text += "\nno no no";
            ch2.Show();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.Name = "The_best_parent_window";
        }

        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            pressedButton.Text = KeyInterop.VirtualKeyFromKey(e.Key) + " " + e.Key;
        }

        private void changeChild1_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (ch1 != null)
                ch1.TextBox2.Text = changeChild1.Text;
        }

        private void processesTree_Loaded_1(object sender, RoutedEventArgs e)
        {
            thread = new Thread(delegate() { Dispatcher.Invoke(delegate() { Method(sender); }); });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        static void Method(object sender)
        {
            Process[] pt = Process.GetProcesses();
            for(int i=0; i<pt.Length-1; i++)
            {
                Process p = Process.GetProcessById( pt[i].Id);
                ProcessTree t = new ProcessTree(p);
                TreeViewItem item = new TreeViewItem();

                item.Header = t.ProcessName;
                List<string> ct = new List<string>();
                foreach (var v in t.ChildProcesses)
                {
                    ct.Add(v.ProcessName);
                }
                item.ItemsSource = ct;
                var tree = sender as TreeView;
                tree.Items.Add(item);
            }
        }
    }
}

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

namespace BluriSVG.TestApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (o, e) =>
            {
                svg_.DataList.Add("M101.36,45A6.65,6.65,0,0,1,108,51.64V85.36A6.65,6.65,0,0,1,101.36,92H12.64A6.65,6.65,0,0,1,6,85.36V51.64A6.65,6.65,0,0,1,12.64,45h88.72m0-6H12.64A12.64,12.64,0,0,0,0,51.64V85.36A12.64,12.64,0,0,0,12.64,98h88.72A12.64,12.64,0,0,0,114,85.36V51.64A12.64,12.64,0,0,0,101.36,39Z");
            };
        }
    }
}

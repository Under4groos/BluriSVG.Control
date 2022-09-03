using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace BluriSVG.Control.View.Controls
{
    /// <summary>
    /// Логика взаимодействия для Svg.xaml
    /// </summary>
    public partial class Svg : UserControl , INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> DataList_ = new ObservableCollection<string>();


        public ObservableCollection<string> DataList
        {
            get
            {
                return DataList_;
            }
            set
            {
                DataList_ = value;
                OnPropertyChanged("svg_update");
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



        public Svg()
        {
            InitializeComponent();
            this.DataContext = this;


            //System.Windows.Shapes.Path path_svg = new System.Windows.Shapes.Path();

            //path_svg.Data = Geometry.Parse(svg.d);
            //path_svg.Fill = Brushes.White;

            //path_svg.SnapsToDevicePixels = true;
        }
    }
}

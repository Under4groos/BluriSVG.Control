﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
        Size _Resize = new Size(1,1);
        public Size Resize
        {
            get
            {
                return _Resize;


            }
            set
            {
                _Resize = value;
                _resize(_Resize.Width, _Resize.Height);
            }
        }
        private string _path_svg = "";


        public string PathSvg
        {
            get
            {
                return _path_svg;
            }
            set
            {
                _path_svg = value;
                if (File.Exists(_path_svg))
                {
                    string data_ = File.ReadAllText(_path_svg);
                    DataList.Clear();
                    foreach (Match _svg in Regex.Matches(data_ , "<svg[\\w\\W]+?<\\/svg>"))
                    {
                        foreach (Match item in Regex.Matches(_svg.Value, "<path[\\w\\W]+?\\/>"))
                        {

                            foreach (Match _d in Regex.Matches(item.Value, "d=\\\"[\\w\\W]+?\\\""))
                            {

                                DataList.Add(Regex.Replace(_d.Value, "(d=\")|(\")", ""));
                               // Console.WriteLine(Regex.Replace(_d.Value, "(d=\")|(\")", ""));
                            }
                        }
                    }

                }
            }
        }

        private void _resize(double w , double h)
        {
            ScaleTransform myScaleTransform = new ScaleTransform();
            myScaleTransform.ScaleX = w;
            myScaleTransform.ScaleY = h;
            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(myScaleTransform);
            this.RenderTransform = myTransformGroup;
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
        }
    }
}

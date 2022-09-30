using BluriSVG.Control.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BluriSVG.Control.View.Controls
{


    public partial class Svg : UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<SvgData> DataList_ = new ObservableCollection<SvgData>();
        private Vector GeomSize = new Vector(0,0);

        public Svg()
        {
            InitializeComponent();
            this.DataContext = this;

            this.PropertyChanged += Svg_PropertyChanged;

            this.Loaded += (o, e) =>
            {
                _update();
            };

            this.SizeChanged += (o, e) =>
            {
                if (this.AutoSizable)
                {
                    _update();
 
                }
            };
        }

        private void _update()
        {
            this.Resize = (Size)(new Vector(

                       this.ActualWidth / GeomSize.X,
                       this.ActualHeight / GeomSize.Y

                       ));
        }

        private void Svg_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "svg_path":


                    this.DataList.Clear();
                    this.Add(DataPath);
                    break;
                case "AutoSizable":
                    
                    break;
                default:
                    break;
            }
        }


        public ObservableCollection<SvgData> DataList
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
        Size _Resize = new Size(1, 1);
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

        private string _path = "";

        public string DataPath
        {
            get
            {
                return _path;
            }

            set
            {
                _path = value;
                OnPropertyChanged("svg_path");
            }

        }


        private bool _AutoSizable = false;

        public bool AutoSizable
        {
            get
            {
                return _AutoSizable;
            }
            set
            {
                _AutoSizable = value;
                OnPropertyChanged("AutoSizable");
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
                string location = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName;
                string local_path_svg = System.IO.Path.Combine(location, _path_svg);
                if (!File.Exists(_path_svg))
                {
                    if (!File.Exists(local_path_svg))
                    {
                        return;
                    }
                    else
                    {
                        _path_svg = local_path_svg;
                    }
                }

                string data_ = File.ReadAllText(_path_svg);
                DataList.Clear();
                foreach (Match _svg in Regex.Matches(data_, "<svg[\\w\\W]+?<\\/svg>"))
                {
                    foreach (Match item in Regex.Matches(_svg.Value, "<path[\\w\\W]+?\\/>"))
                    {
                        foreach (Match _d in Regex.Matches(item.Value, "d=\\\"[\\w\\W]+?\\\""))
                        {
                            this.Add(Regex.Replace(_d.Value, "(d=\")|(\")", ""), Fill);
                        }
                    }
                }


                if (Regex.IsMatch(data_, RegexPattern.ViewBox))
                {
                    string viv_ = Regex.Match(data_, RegexPattern.ViewBox).Value;

                    viv_ = Regex.Match(viv_, "\"[\\s\\S]+?\"").Value.Replace("\"" , "");
                    if (viv_ != String.Empty)
                    {
                        int[] ints = new int[4];
                        string[] array_ = viv_.Split(' ');

                        for (int i = 0; i < array_.Length; i++)
                        {
                            if(Regex.IsMatch(array_[i] , "\\.[0-9]"))
                            {
                                ints[i] = int.Parse(Regex.Replace(array_[i], "\\.[0-9]+", ""));
                                continue;
                            }
                            ints[i] = int.Parse(array_[i]);  
                        }
                        GeomSize.X = ints[2];
                        GeomSize.Y = ints[3];  
                    }
                }
            }
        }
        private Brush _Fill = Brushes.White;
        public Brush Fill
        {
            get
            {
                return _Fill;
            }
            set
            {
                _Fill = value;
                PathSvg = PathSvg;
            }
        }
        public void Add(string str_, Brush brush)
        {
            this.DataList.Add(new SvgData()
            {
                Path = str_,
                Fill = brush,
            });

        }
        public void Add(string str_)
        {
            Add(str_, Fill);

        }

        private void _resize(double w, double h)
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
    }
}

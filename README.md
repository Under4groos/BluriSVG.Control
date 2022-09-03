
# SVGlib WPF
<img src="https://i.imgur.com/PbHckLo.png" width="100">

https://www.youtube-nocookie.com/embed/iQmJB_Kkh6g

# WPF code
<img src="https://i.imgur.com/flNXjpx.png" width="200">

# C# code
```csharp
public MainWindow()
{
  InitializeComponent();
  svg_image.OpenFile(@"C:\Users\UnderKo\Downloads\done_black_24dp.svg");
  this.SizeChanged += (o, e) =>
  {
    svg_image.SetSizeSvg(this.Width, this.Height);
  };
}
private void Button_Click(object sender, RoutedEventArgs e)
{
  svg_image.SizeSVG = new Size(7, 3);
  svg_image.UpdateSize();
}
```
# License
MIT - do whatever you want.

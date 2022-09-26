# images

<img src="https://i.imgur.com/flNXjpx.png" width="200"> 
 
http://www.youtube.com/watch?feature=player_embedded&v=FiJCrrW4FiE
# Using
```html 
xmlns:svg="clr-namespace:BluriSVG.Control.View.Controls;assembly=BluriSVG.Control" 
``` 

# Resource 
```html
<Window.Resources>
    <clr:String x:Key="SVG">F1 M48,48z M0,0z M38.8492,38.8492C42.6495,35.049 45,29.799 45,24 45,12.402 35.598,3 24,3 12.402,3 3,12.402 3,24 3,29.799 5.35051,35.049 9.15076,38.8492</clr:String>
</Window.Resources>

 <svg:Svg Width="200" Height="100" Background="Orange"
                        DataPath="{StaticResource SVG}"
                      Resize="0.1,0.1" Fill="White" />

```

# WPF code 
```html
<StackPanel>
  <svg:Svg Width="50" Height="50" Background="Orange" PathSvg="C:\Users\Maks\Downloads\banana-bananas-bunch-svgrepo-com.svg" Resize="1,1" Fill="Red" />
  <svg:Svg Width="50" Height="50" Background="Orange" PathSvg="C:\Users\Maks\Downloads\banana-bananas-bunch-svgrepo-com.svg" Resize="1,1" Fill="Green" />
  <svg:Svg Width="50" Height="50" Background="Orange" PathSvg="C:\Users\Maks\Downloads\banana-bananas-bunch-svgrepo-com.svg" Resize="1,1" Fill="Blue" />
  <svg:Svg Width="50" Height="50" Background="Orange" PathSvg="C:\Users\Maks\Downloads\20ec14b1be6ee8760a40687db70c7406_auto_x2 (1).svg" Resize="0.4,0.4" Fill="White" />
</StackPanel>
```
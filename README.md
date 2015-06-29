# Simple RichFormat TextBlock for WPF
Simple RichFormat TextBlock for WPF, you can use both with or without Binding

The markdown is basically in this format 
`[property=value]content[property]`


|Property|StartTag|EndTag|Notes|Example|
--- | --- |  --- | --- | ---
|FontWeight|`[weight=value]`|`[weight]`|check <a href="https://msdn.microsoft.com/it-it/library/system.windows.fontweights(v=vs.110).aspx" target="_blank">MSDN</a> for accepted values|`[weight=semibold] this text is semibold[weight]`
|FontSize|`[fsize=value]`|`[fsize]`|If you place + or - after fsize= the value will be added to the previous font size, this way you can have the sizing relative to the context in which the text will be placed.|`[fsize=25]this text has 25px in height[fsize]`
|Foreground|`[color=value]`|`[color]`|HEX,KnownColor ecc, everything that this method can convert to a Color: '<strong>ColorConverter.ConvertFromString</strong>'|`[color=LightSkyBlue] this text is blue[color]`
|Images|`[image=value]`||Path to image file supported by WPF|`[image=c:\pathtoyourimage\image.png]`
Many others coming in future versions.

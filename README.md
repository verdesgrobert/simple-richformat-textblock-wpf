# Simple RichFormat TextBlock for WPF
Simple RichFormat TextBlock for WPF, you can use both with or without Binding

###Accepted tags
|Property|StartTag|EndTag|Value Type|Notes|
--- | --- | --- | --- | ---
|FontWeight|`[weight=value]`|`[weight]`|string|check <a href="https://msdn.microsoft.com/it-it/library/system.windows.fontweights(v=vs.110).aspx" target="_blank">MSDN</a> for accepted values|
|FontSize|`[fsize=value]`|`[fsize]`|double|If you place + or - after fsize= the value will be added to the previous font size, this way you can have the sizing relative to the context in which the text will be placed.| 
|Foreground|`[color=value]`|`[color]`|string|HEX,KnownColor ecc, everything that this method can convert to a Color: '<strong>ColorConverter.ConvertFromString</strong>'
|Images|`[image=value]`|`[image]`|string|Path to image file supported by WPF
Many others coming in future versions.

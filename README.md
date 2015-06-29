# Simple RichFormat TextBlock for WPF
Simple RichFormat TextBlock for WPF, you can use both with or without Binding


<strong>Font weight:</strong>  

Start tag accepting string values (check <a href="https://msdn.microsoft.com/it-it/library/system.windows.fontweights(v=vs.110).aspx" target="_blank">MSDN</a> for accepted values):   
<b>[weight=value]</b>  
End tag <b>[weight]</b>

<strong>Font size:</strong>  

Start tag accepting a double* value:   
<b>[fsize=value]</b>  
End tag <b>[fsize]</b>

<em>*If you place + or - after fsize= the value will be added to the previous font size, this way you can have the sizing relative to the context in which the text will be placed.</em>

<strong>Foreground:</strong>  

Start tag accepting string values (HEX,KnownColor ecc, everything that this method can convert to a Color: '<strong>ColorConverter.ConvertFromString</strong>')   
<b>[color=value]</b>  
End tag <b>[color]</b>  

Many others coming in future versions.

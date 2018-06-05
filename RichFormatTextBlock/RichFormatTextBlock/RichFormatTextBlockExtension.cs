using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Image = System.Windows.Controls.Image;

namespace RichFormattextBlock
{
    public static class RichFormatTextBlockExtension
    {
        public static void SetRichFormatText(this TextBlock textBlock, string text)
        {
            if (textBlock == null) return;
            string[] strs = text.Split('[');
            textBlock.ClearValue(TextBlock.TextProperty);
            var solidColorBrush = textBlock.Foreground as SolidColorBrush;
            List<Color> colors = new List<Color> { Colors.Black };
            List<double> fontSizes = new List<double> { textBlock.FontSize };
            List<FontWeight> weights = new List<FontWeight> { textBlock.FontWeight };
            if (solidColorBrush != null)
                colors.Add(solidColorBrush.Color);
            foreach (string str in strs)
            {
                string[] parts = str.Split(']');
                string txt;
                if (parts.Length > 1)
                {
                    txt = parts[1];
                    string format = parts[0];
                    string[] fParts = format.Split('=');
                    if (fParts.Length == 1)//end tag
                    {
                        switch (fParts[0])
                        {
                            case "color":
                                colors.RemoveAt(colors.Count - 1);
                                break;
                            case "weight":
                                weights.RemoveAt(weights.Count - 1);
                                break;
                            case "fsize":
                                fontSizes.RemoveAt(fontSizes.Count - 1);
                                break;
                        }
                    }
                    else
                    {
                        switch (fParts[0])
                        {
                            case "color":
                                string color = fParts[1];
                                var colorObj = ColorConverter.ConvertFromString(color);

                                if (colorObj != null)
                                    colors.Add((Color)colorObj);
                                break;

                            case "weight":
                                var fontWeight = new FontWeightConverter().ConvertFromString(fParts[1]);
                                if (fontWeight != null)
                                    weights.Add((FontWeight)fontWeight);
                                break;

                            case "fsize":
                                double fontSize = fontSizes.Last();
                                string fSize = fParts[1];
                                if (fParts[1].StartsWith("+") || fParts[1].StartsWith("-"))
                                {
                                    fSize = fParts[1].Substring(1);
                                }
                                var ok = double.TryParse(fSize, out fontSize);

                                if (ok)
                                {
                                    if (fParts[1].StartsWith("+"))
                                        fontSize = fontSizes.Last() + fontSize;
                                    if (fParts[1].StartsWith("-"))
                                        fontSize = fontSizes.Last() - fontSize;
                                    fontSizes.Add(fontSize);
                                }

                                break;

                            case "image":
                                string imageUrl = fParts[1];
                                AddImage(textBlock, imageUrl, 1.2, BaselineAlignment.Center);
                                break;
                        }
                    }
                }
                else
                {
                    txt = parts[0];
                }
                if (!string.IsNullOrEmpty(txt))
                {
                    textBlock.Inlines.Add(new Run(txt)
                    {
                        Foreground = new SolidColorBrush(colors.Last()),
                        FontWeight = weights.Last(),
                        FontSize = fontSizes.Last(),
                        BaselineAlignment = BaselineAlignment.Center
                    });
                }
            }
        }

        private static void AddImage(TextBlock textBlock, string imageUrl, double lineHeight = 1.2, BaselineAlignment alignment = BaselineAlignment.Center)
        {
            if (File.Exists(imageUrl))
            {
                Image imgMessage = new Image();
                imgMessage.Height = textBlock.FontSize * lineHeight;
                BitmapImage bi = new BitmapImage();

                bi.BeginInit();
                bi.UriSource = new Uri(imageUrl, UriKind.RelativeOrAbsolute);
                bi.EndInit();

                imgMessage.Source = bi;
                InlineUIContainer iuc = new InlineUIContainer(imgMessage);
                iuc.BaselineAlignment = alignment;
                textBlock.Inlines.Add(iuc);
            }
        }
    }
}

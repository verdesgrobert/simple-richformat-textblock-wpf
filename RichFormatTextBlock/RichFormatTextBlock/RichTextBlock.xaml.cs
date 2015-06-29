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
using RichFormattextBlock;

namespace RichFormatTextBlock
{
    /// <summary>
    /// Interaction logic for RichTextBlock.xaml
    /// </summary>
    public partial class RichTextBlock : UserControl
    {
        public RichTextBlock()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(
            "TextWrapping", typeof(TextWrapping), typeof(RichTextBlock), new PropertyMetadata(default(TextWrapping)));

        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(RichTextBlock), new PropertyMetadata(OnPropertyChangedCallback));

        private static void OnPropertyChangedCallback(DependencyObject s, DependencyPropertyChangedEventArgs ev)
        {
            if (ev.Property == TextProperty)
            {
                var rich = (s as RichTextBlock);
                if (rich != null)
                    rich.txtText.SetRichFormatText(ev.NewValue.ToString());
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
                txtText.SetRichFormatText(value);
            }
        }
    }
}

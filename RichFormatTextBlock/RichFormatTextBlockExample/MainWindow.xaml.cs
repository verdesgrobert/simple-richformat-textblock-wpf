using System.Windows;
using RichFormattextBlock;

namespace RichFormatTextBlockExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Text =
                "This text is just normal, but what it comes after this is [weight=bold]bold, and it goes off just right now[weight]. you can even color some [color=Green]par[color][color=Blue]ts[color] or even [color=yellow]comb[color=Cyan]ine[color][color] them you can even make something [color=LightSkyBlue]colored[weight=ExtraBold] and Bold or [color]only Bold[weight]";
            txtExtra.SetRichFormatText(Text);
            DataContext = this;
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof (string), typeof (MainWindow), new PropertyMetadata(default(string)));

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}

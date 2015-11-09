using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App2
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            lijst.Items.Add("a");
            lijst.Items.Add("a2");
            lijst.Items.Add("a4");
            lijst.Items.Add("dsa");
            lijst.Items.Add("a2sad");
            lijst.Items.Add("aasdas4");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lijst.SelectedIndex > -1)
            {
                lijst.Items.RemoveAt(lijst.SelectedIndex);
            }
        }
    }
}

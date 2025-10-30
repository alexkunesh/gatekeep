using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Gatekeep
{
    /// <summary>
    /// Interaction logic for ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public class ListItem
        {
            public string FriendlyName { get; set; }
            public string ExecutablePath { get; set; }
            public BitmapSource Bitmap { get; set; }

            public ListItem(string ExecutablePath)
            {
                this.ExecutablePath = ExecutablePath;
                FriendlyName = Win32.GetExecutableDisplayName(ExecutablePath);
                Bitmap = Win32.GetExecutableIcon(ExecutablePath);
            }
        }

        public ConfigurationWindow()
        {
            InitializeComponent();

            var distractibleTempList = new List<ListItem>
            {
                new(@"C:\Windows\System32\calc.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
                new(@"C:\Windows\notepad.exe"),
            };

            DistractibleListBox.ItemsSource = distractibleTempList;
            ProductiveListBox.ItemsSource = distractibleTempList;
        }

        /// <summary>
        /// This event handler will deselect the productive list box if the distractible list box has received focus.
        /// </summary>
        private void DistractibleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DistractibleListBox.SelectedIndex != -1)
            {
                ProductiveListBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// This event handler will deselect the distractible list box if the productive list box has received focus.
        /// </summary>
        private void ProductiveListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductiveListBox.SelectedIndex != -1)
            {
                DistractibleListBox.SelectedIndex = -1;
            }
        }

        private void AddDistractionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddProductiveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UninstallButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

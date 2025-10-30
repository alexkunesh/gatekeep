using System.Media;
using System.Windows;

namespace Gatekeep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Play asterisk sound.
            SoundPlayer sound = new SoundPlayer("UAsterisk.wav");
            sound.Play();
        }

        private void AcknowledgeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OverrideButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }
    }
}
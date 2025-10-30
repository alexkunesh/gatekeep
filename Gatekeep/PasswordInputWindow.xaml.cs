using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Gatekeep
{
    /// <summary>
    /// Interaction logic for PasswordInputWindow.xaml
    /// </summary>
    public partial class PasswordInputWindow : Window
    {
        private string _inputString = "";

        public PasswordInputWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Play asterisk sound.
            SoundPlayer sound = new SoundPlayer("UQuestion.wav");
            sound.Play();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                // Delete the last character of the input string if there is a character to delete.
                if (_inputString.Length > 0)
                {
                    _inputString = _inputString.Substring(0, _inputString.Length - 1);
                    UpdateInputView();
                }
                return;
            }

            // Ignore spaces
            if (e.Key == Key.Space)
            {
                return;
            }

            // Append the upper-case variant of the inputted key.
            var keyChar = e.Key.ToString(); // This does NOT do what you would think it does.
                                            // This converts the Key enum name into a string.
                                            // This can provide some weird non character responses. We'll check for that now.

            if (keyChar.Length > 1 || !(keyChar[0] >= 'A' && keyChar[0] <= 'Z'))
            {
                return;
            }

            _inputString += keyChar;
            UpdateInputView();

            // If 8 characters have been received, attempt to unlock.
            if (_inputString.Length >= 8)
            {
                AttemptUnlock();
            }
        }

        private void UpdateInputView()
        {
            StringBuilder sb = new();
            for (var i = 0; i < 8; i++)
            {
                sb.Append(_inputString.Length > i ? _inputString[i] : "_");
                if (i < 7) sb.Append(" ");
                if (i == 3) sb.Append("- ");
            }
            InputTextBlock.Text = sb.ToString();
        }

        private void AttemptUnlock()
        {
        }
    }
}

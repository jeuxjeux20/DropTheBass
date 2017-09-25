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

namespace DropTheBass
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MediaPlayer Player { get; } = new MediaPlayer();
        public int EndPosition { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var castedSender = (TextBox)sender;
            castedSender.Text = new string(castedSender.Text
                                                       .Where((c) => char.IsNumber(c))
                                                       .ToArray());
            try
            {
                if (Player.NaturalDuration.TimeSpan.TotalSeconds < (int.Parse(castedSender.Text)))
                {
                    castedSender.Text = Player.NaturalDuration.TimeSpan.TotalSeconds.ToString();
                }
                else if (int.Parse(EndMusic.Text) <= int.Parse(castedSender.Text))
                {
                    castedSender.Text = (int.Parse(EndMusic.Text) - 1).ToString();
                }
            }
            catch
            {
                castedSender.Text = "0";
                castedSender.IsEnabled = false;
            }

        }
    }
}


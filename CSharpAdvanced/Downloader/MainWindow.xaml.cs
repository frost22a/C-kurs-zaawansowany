using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace Downloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string DownloadedString { get; set; }
        public event Action<string> StringDownloader = (x) => { };
        public event Action<string, string> FileNameProvided = (x, y) => { };
        public MainWindow()
        {
            InitializeComponent();

            StringDownloader += (x) => SetControlsStateAfterDownload();
            StringDownloader += (x) => DownloadedString = x;
            StringDownloader += (y) =>
            {
                Application.Current.Dispatcher.Invoke(() => 
                {
                    DisplayText.Text = "Podaj nazwę pliku";
                    MessageBox.Show("Podaj nazwę pliku");
                });
            };

            FileNameProvided += SaveToFile;
            FileNameProvided += (x, y) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    DisplayText.Text = "Zapisano plik";
                    MessageBox.Show("Zapisano plik");
                });
            };

            FileName.Visibility = Visibility.Hidden;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DownloadedString != null)
            {

                FileNameProvided.Invoke(FileName.Text, DownloadedString);
                return;
            }
            
            var currentUrl = WebsiteUrl.Text;

            await Task.Run(async () =>
                {
                    var webClient = new WebClient();
                    var downloadedString = await webClient.DownloadStringTaskAsync(currentUrl);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        DisplayText.Text = "Success!";
                    });
                    StringDownloader.Invoke(downloadedString);
                });
        }

        private void SetControlsStateAfterDownload()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                WebsiteUrl.Visibility = Visibility.Hidden;
                FileName.Visibility = Visibility.Visible;
                SubmitButton.Content = "Click to Save";
            });
                        
        }

        private void SaveToFile(string fileName, string downloadedString)
        {
            File.WriteAllText(fileName, downloadedString);
        }
                
    }
}

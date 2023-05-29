using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace WpfLab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class CurrentTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double position)
            {
                if (position != 0) ;
                TimeSpan timeSpan = TimeSpan.FromSeconds(position);
                //return timeSpan.ToString(@"hh\:mm\:ss\.fff");
                return timeSpan.ToString(@"hh\:mm\:ss\.fff");
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (value is TimeSpan timeSpan)
            {
                string format = "hh\\:mm\\:ss\\.fff";
                string formattedTimeSpan = timeSpan.ToString(format);

                formattedTimeSpan = formattedTimeSpan.TrimStart('0');

                if (timeSpan.Milliseconds == 0)
                {
                    format = "hh\\:mm\\:ss";
                    formattedTimeSpan = timeSpan.ToString(format);
                }

                return formattedTimeSpan;
            }

            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (value is string timeString)
            {
                TimeSpan timeSpan;
                bool parseSuccess = TimeSpan.TryParseExact(timeString, "h\\:m\\:s\\.fff", language, out timeSpan);

                if (parseSuccess)
                {
                    return timeSpan;
                }
            }

            return value;
        }

    }
    public class Row
    {
        public TimeSpan ShowTime { get; set; }
        public TimeSpan HideTime { get; set; }

        public string Text { get; set; }

        public string Translation { get; set; }

        public Row()
        {
            ShowTime = TimeSpan.Zero;
            HideTime = TimeSpan.Zero;
            Text = string.Empty;
            Translation = string.Empty;
        }

        public Row(TimeSpan showtime, TimeSpan hidetime, string text, string translation)
        {
            ShowTime = showtime;
            HideTime = hidetime;
            Text = text;
            Translation = translation;
        }
    }
    public partial class MainWindow : Window
    {
        private ObservableCollection<Row> Rows { get; set; }

        bool isVideoPlaying = false;
        bool userIsDraggingSlider = false;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            volumeSlider.Value = videoPlayer.Volume;

            string source = "C:\\Users\\glowa\\Desktop\\Studia\\SOP2\\SOP2 Wykład 10-20210505_141640-Nagrywanie spotkania.mp4";
            videoPlayer.Source = new Uri(source);
            isVideoPlaying = true;
            videoPlayer.Play();

            Rows = new ObservableCollection<Row>();

            DataContext = Rows;

            //DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
            DateTime date1 = DateTime.Now, date2 = date1.AddMinutes(35);
            DateTime date3 = new DateTime(2023, 8, 18, 11, 44, 50);
            //DateTime date2 = new DateTime(2023, 8, 18, 13, 30, 30);
            DateTime date4 = new DateTime(2023, 8, 18, 12, 4, 24);
            TimeSpan ts1 = date2 - date1, ts2 = date4 - date3;

            Row r1 = new Row(ts1, ts1, "aaa", "aaa (in English)");
            Row r2 = new Row(ts2, ts2, "bbb", "bbb (in English)");
            Rows.Add(r1);
            Rows.Add(r2);

            Rows = new ObservableCollection<Row>(Rows.OrderBy(x => x.ShowTime));
        }

        // https://wpf-tutorial.com/audio-video/how-to-creating-a-complete-audio-video-player/
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((videoPlayer.Source != null) && (videoPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                positionSlider.Minimum = 0;
                positionSlider.Maximum = videoPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                positionSlider.Value = videoPlayer.Position.TotalSeconds;
            }
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a simple subtitle composer.", "Subtitle Composer", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                videoPlayer.Source = new Uri(openFileDialog.FileName);
                isVideoPlaying = true;
            }
        }

        private void videoPlayer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isVideoPlaying)
            {
                pauseButton_Click(null, null);
                //isVideoPlaying = false;
            }
            else
            {
                playButton_Click(null, null);
                //isVideoPlaying = true;
            }
            
        }

        private void videoPlayer_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (videoPlayer.Source != null)
            {
                if (e.Delta > 0 && videoPlayer.Volume < 1)
                    videoPlayer.Volume += 0.1;
                else if (e.Delta < 0 && videoPlayer.Volume > 0)
                    videoPlayer.Volume -= 0.1;
            }
        }

        private void videoPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan duration = videoPlayer.NaturalDuration.TimeSpan;
            positionSlider.Maximum = duration.TotalSeconds;
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Row)
            {
                TimeSpan showTime = ((Row)dataGrid.SelectedItem).ShowTime;
                positionSlider.Value = showTime.TotalSeconds;

                videoPlayer.Position = TimeSpan.FromSeconds(positionSlider.Value);
            }
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            videoPlayer.Play();
            isVideoPlaying = true;
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            videoPlayer.Pause();
            isVideoPlaying = false;
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            videoPlayer.Stop();
            isVideoPlaying = false;
            positionSlider.Value = 0;
        }

        private void positionSlider_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void positionSlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            //Position = positionSlider.Value;
            videoPlayer.Position = TimeSpan.FromSeconds(positionSlider.Value);
        }

        private void positionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            currentPositionText.Text = TimeSpan.FromSeconds(positionSlider.Value).ToString(@"hh\:mm\:ss");
        }

        private void pbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            videoPlayer.Volume = pbVolume.Value;
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double volume = volumeSlider.Value;
            videoPlayer.Volume = volume;
        }

    }
}

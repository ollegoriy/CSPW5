using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Put_v_Valhalu_5.View;
using Put_v_Valhalu_5.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;


namespace Put_v_Valhalu_5.ViewModel
{
    class MainViewModel : BindingHelper
    {
        private int volume;

        public int Volume
        {
            get { return volume; }
            set
            {
                if (volume != value)
                {
                    volume = value;
                    OnPropertyChanged(nameof(Volume));
                }
            }
        }
        private MediaPlayer mediaPlayer;
        private double _currentPosition;
        public double CurrentPosition
        {
            get { return _currentPosition; }
            set
            {
                _currentPosition = value;
                OnPropertyChanged(nameof(CurrentPosition));
            }
        }

        private double _totalDuration;
        public double TotalDuration
        {
            get { return _totalDuration; }
            set
            {
                _totalDuration = value;
                OnPropertyChanged(nameof(TotalDuration));
            }
        }
        private double _sliderValue;
        private double _totalTime = 100;
        private DispatcherTimer _timer;

        public double SliderValue
        {
            get { return _sliderValue; }
            set
            {
                _sliderValue = value;
                OnPropertyChanged(nameof(SliderValue));
            }
        }
        public double TotalTime
        {
            get { return _totalTime; }
        }
        private MediaElement mediaElement;
        public MediaElement MediaElement
        {
            get { return mediaElement; }
            set
            {
                mediaElement = value;
                OnPropertyChanged();
            }
        }
        private bool isPlaying;
        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                OnPropertyChanged();
            }
        }

        List<string> songg = new List<string>();
        string a = "C:\\Games\first.mp3";
        string b = "C:\\Games\second.mp3";
        string c = "C:\\\\Games\\third.mp3";



        public BindabkeCommadn PlayCommand { get; set; }
        public BindabkeCommadn Dalee { get; set; }
        public BindabkeCommadn Nazad { get; set; }
        public BindabkeCommadn Pause { get; set; }
        public BindabkeCommadn Vugruz { get; set; }
        public BindabkeCommadn SledOkno { get; set; }

        private List<string> _songs;

        public List<string> Songs
        {
            get { return _songs; }
            set
            {
                _songs = value;
                OnPropertyChanged();
            }
        }


        private Uri _mediaSource;
        public Uri MediaSource
        {
            get { return _mediaSource; }
            set
            {
                _mediaSource = value;
                OnPropertyChanged(nameof(MediaSource));
            }

        }


        public void Play()
        {

            MediaSource = new Uri(Songs[0]);



        }
        public void SledOk()
        {
            
            Window1 second_window = new Window1();
            
            second_window.Show();
            
            
            

        }
       
        public void Pausee()
        {

            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                mediaPlayer.Pause();
                IsPlaying = false;
            }
        }


    
    

        
        public void Naz()
        {
            if (MediaSource == new Uri(Songs[0]))
            {
                MediaSource = new Uri(Songs[2]);
            }
            else if (MediaSource == new Uri(Songs[1]))
            {
                MediaSource = new Uri(Songs[0]);

            }
            else if (MediaSource == new Uri(Songs[2]))
            {
                MediaSource = new Uri(Songs[1]);
            }

        }
        public void Dal()
        {
            if (MediaSource == new Uri(Songs[0]))
            {
                MediaSource = new Uri(Songs[1]);
            }
            else if (MediaSource== new Uri(Songs[1]))
            {
                MediaSource = new Uri(Songs[2]);

            }
            else if (MediaSource == new Uri(Songs[2]))
            {
                MediaSource = new Uri(Songs[0]);
            }
            





        }
       
       

        public MainViewModel()
        {



            SledOkno = new BindabkeCommadn(_ => SledOk());
            Dalee = new BindabkeCommadn(_ => Dal());
            Pause = new BindabkeCommadn(_ => Pausee());
           



            Songs = new List<string>();

            Songs.Add(a);
            Songs.Add(b);
            Songs.Add(c);
            mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;



            PlayCommand = new BindabkeCommadn(_=> Play());
            Nazad = new BindabkeCommadn(_ => Naz());
            
            


        }

        private void TimerTick(object? sender, EventArgs e)
        {
            
            SliderValue = MediaElement.Position.TotalSeconds;
            

            
          
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            IsPlaying = false;
        }

        private void MediaPlayer_MediaOpened(object sender, EventArgs e)
        {
            IsPlaying = true;
        }
    }
}



        
  
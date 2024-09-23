using Microsoft.Win32;
using Put_v_Valhalu_5.Model;
using Put_v_Valhalu_5.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Put_v_Valhalu_5.ViewModel
{
     class TherdViewModel : BindingHelper
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

        private MediaPlayer mediaSource;
        public MediaPlayer MediaSource
        {
            get { return mediaSource; }
            set
            {
                mediaSource = value;
                OnPropertyChanged(nameof(MediaSource));
            }

        }
        
       


        public TherdViewModel()
        {

            
        }

    }
}
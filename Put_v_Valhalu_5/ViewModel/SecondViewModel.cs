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
   class SecondViewModel : BindingHelper
    {
        private ObservableCollection<string> songsList = new ObservableCollection<string>();
        public ObservableCollection<string> SongsList
    {
        get { return songsList; }
        set
        {
            songsList = value;
            OnPropertyChanged(nameof(SongsList));
        }
    }
        public BindabkeCommadn Vugruz { get; set; }
        public BindabkeCommadn NazadNazad { get; set; }
        public BindabkeCommadn SledSled { get; set; }
        
        public void Vug()
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var fileName in openFileDialog.FileNames)
                {
                    SongsList.Add(fileName);
                }


            }
        }
        public void Nazadd()
        {
            MainWindow wid = new MainWindow();
            wid.Show();
            
            
            
        }
        public void Sle()
        {
            Window2 window = new Window2();
            window.Show();
        }
        public SecondViewModel() 
        {
            NazadNazad = new BindabkeCommadn(_ => Nazadd());
            Vugruz = new BindabkeCommadn (_ => Vug());
            SledSled = new BindabkeCommadn(_ => Sle());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAutomatas.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            NosotrosViewModel = new();
            MainViewModel = new();
            AyudaViewModel = new();

        }

        public NosotrosViewModel NosotrosViewModel { get; set; }
        public MainViewModel MainViewModel { get; set; }

        public AyudaViewModel AyudaViewModel { get; set; }


        private bool _IsNosotrosChecked = true;
        public bool IsNosotrosChecked
        {
            get
            {
                return _IsNosotrosChecked;
            }
            set
            {
                _IsNosotrosChecked = value;
                if (value == true) NosotrosViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else NosotrosViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsNosotrosChecked));
            }
        }


        private bool _IsMainViewChecked = false;
        public bool IsMainViewChecked
        {
            get
            {
                return _IsMainViewChecked;
            }
            set
            {
                _IsMainViewChecked = value;
                if (value == true) MainViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else MainViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsMainViewChecked));
            }
        }


        private bool _IsAyudaChecked = false;
        public bool IsAyudaChecked
        {
            get
            {
                return _IsAyudaChecked;
            }
            set
            {
                _IsAyudaChecked = value;
                if (value == true) AyudaViewModel.ControlVisibility = System.Windows.Visibility.Visible;
                else AyudaViewModel.ControlVisibility = System.Windows.Visibility.Collapsed;
                OnPropertyChanged(nameof(IsAyudaChecked));
            }
        }

    }
}

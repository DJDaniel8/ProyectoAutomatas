using ProyectoAutomatas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoAutomatas.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
			_Tokens = new();
        }

        private Visibility _ControlVisibility = Visibility.Collapsed;
        public Visibility ControlVisibility
        {
            get
            {
                return _ControlVisibility;
            }
            set
            {
                _ControlVisibility = value;
                OnPropertyChanged(nameof(ControlVisibility));
            }
        }

        private ObservableCollection<Token> _Tokens;
		public IEnumerable<Token> Tokens => _Tokens;

		private string _Texto = string.Empty;
		public string Texto
		{
			get
			{
				return _Texto;
			}
			set
			{
				_Texto = value;
				if(value.Contains("\\Begin") && value.Contains("\\End"))
				{
                    Texto2 = value;
                }
				else Texto2 = "\\";
				CargarTokens();
				OnPropertyChanged(nameof(Texto));
			}
		}

		private string _Texto2;
		public string Texto2
		{
			get
			{
				return _Texto2;
			}
			set
			{
				_Texto2 = value.Replace("\\Begin","").Replace("\\End","");
				OnPropertyChanged(nameof(Texto2));
			}
		}

		public void CargarTokens()
		{
			_Tokens.Clear();
			;
            foreach (var item in AnalizadorLexico.principal(Texto))
			{
				_Tokens.Add(item);
			}
		}
	}
}

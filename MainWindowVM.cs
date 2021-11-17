using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTeste1
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<string> lista { get; set; }
        public string nome { get; set; }

        public ICommand comando { get; private set; }
        public ICommand comandodel { get; private set; }
        public MainWindowVM()
        {
            lista = new ObservableCollection<string>();
            lista.Add("Ana");
            nome = "";
            comando = new RelayCommand((object param) =>
            {
                lista.Add(nome);
                Notifica("nome");
            });
            
            comandodel = new RelayCommand((object param) =>
            {
                lista.RemoveAt(0);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void Notifica(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

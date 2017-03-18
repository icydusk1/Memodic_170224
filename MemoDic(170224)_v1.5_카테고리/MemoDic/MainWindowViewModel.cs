using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDic
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                Debug.WriteLine("Password: " + value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
            }
        }
    }
}
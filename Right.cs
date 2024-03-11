using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    internal class Right : INotifyPropertyChanged
    {
        public Thread thread;

        private string date = string.Format($"{DateTime.Now:T}");
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                NotifyPropertyChanged("Date");
                
            }
        }

        public bool Work = true;

        public void SetThread()
        {
            while (Work)
            {
                Date = string.Format($"{DateTime.Now:HH:mm:ss:fff}");
            }
        }

        public Right()
        {
            thread = new Thread(SetThread);
            thread.IsBackground = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

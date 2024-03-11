using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Lab_4
{
    public class Left:INotifyPropertyChanged
    {
        DispatcherTimer Timer = new DispatcherTimer();
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

        public void StartTimer()
        {
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Timer.Tick += (o, t) => { Date = string.Format($"{DateTime.Now:HH:mm:ss:fff}"); };
            Timer.Start();
        }

        public Left()
        {
            thread = new Thread(StartTimer);
            thread.IsBackground = true;
            Date = string.Format($"{ DateTime.Now:T}");
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

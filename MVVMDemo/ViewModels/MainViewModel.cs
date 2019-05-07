using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Properties
        public MyICommand NavigateView1 { get; set; }

        public MyICommand NavigateView2 { get; set; }

        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; RaisePropertyChanged(nameof(SelectedViewModel)); }
        }

        // Constructor
        public MainViewModel()
        {
            SelectedViewModel = this;
            NavigateView1 = new MyICommand(OnNavigateView1, CanNavigateView1);
            NavigateView2 = new MyICommand(OnNavigateView2, CanNavigateView2);
        }

        // Methods
        public void OnNavigateView1()
        {
            SelectedViewModel = new StudentViewModel();
        }

        public bool CanNavigateView1()
        {
            return true;
        }

        public void OnNavigateView2()
        {
            SelectedViewModel = new RandomViewModel();
        }

        public bool CanNavigateView2()
        {
            return true;
        }

        // PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}

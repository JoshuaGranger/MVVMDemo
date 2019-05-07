using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Properties
        private MyICommand _navigateView1;
        public MyICommand NavigateView1
        {
            get { return _navigateView1; }
            set { _navigateView1 = value; RaisePropertyChanged("NavigateView1"); }
        }

        private MyICommand _navigateView2;
        public MyICommand NavigateView2
        {
            get { return _navigateView2; }
            set { _navigateView2 = value; RaisePropertyChanged("NavigateView2"); }
        }

        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; RaisePropertyChanged("SelectedViewModel"); }
        }

        // Constructor
        public MainViewModel()
        {
            SelectedViewModel = new MainViewModel();
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

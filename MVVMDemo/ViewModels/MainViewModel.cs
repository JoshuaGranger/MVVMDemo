using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<string> People { get; set; }

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
            People = new ObservableCollection<string> { "Josh", "Not Josh" };
        }

        // Methods
        public void OnNavigateView1()
        {
            SelectedViewModel = new StudentViewModel();
            NavigateView1.RaiseCanExecuteChanged();
            NavigateView2.RaiseCanExecuteChanged();
        }

        public bool CanNavigateView1()
        {
            var temp = !(SelectedViewModel.GetType() == typeof(StudentViewModel));
            return temp;
        }

        public void OnNavigateView2()
        {
            SelectedViewModel = new RandomViewModel();
            NavigateView1.RaiseCanExecuteChanged();
            NavigateView2.RaiseCanExecuteChanged();
        }

        public bool CanNavigateView2()
        {
            var temp = !(SelectedViewModel.GetType() == typeof(RandomViewModel));
            return temp;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    public class MainViewModel
    {
        // Properties
        public MyICommand NavigateView1 { get; set; }

        public MyICommand NavigateView2 { get; set; }

        public object SelectedViewModel { get; set; }

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
    }
}

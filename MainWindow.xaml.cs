using FuncProgrammingProjectDOTNET.LessonsViews;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FuncProgrammingProjectDOTNET
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }
    }
}

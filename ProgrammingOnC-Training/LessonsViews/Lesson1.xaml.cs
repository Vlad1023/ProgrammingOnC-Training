using FuncProgrammingProjectDOTNET.LessonsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FuncProgrammingProjectDOTNET.LessonsViews
{
    /// <summary>
    /// Interaction logic for Lesson1.xaml
    /// </summary>
    public partial class Lesson1 : Window
    {
        public Lesson1()
        {
            DataContext = new Lesson1ViewModel();
            InitializeComponent();
        }
    }
}

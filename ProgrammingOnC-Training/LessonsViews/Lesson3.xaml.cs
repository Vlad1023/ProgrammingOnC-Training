using FuncProgrammingProjectDOTNET.LessonsViewModels;
using System.Windows;

namespace FuncProgrammingProjectDOTNET.LessonsViews
{
    /// <summary>
    /// Interaction logic for Lesson3.xaml
    /// </summary>
    public partial class Lesson3 : Window
    {
        public Lesson3()
        {
            DataContext = new Lesson3ViewModel();
            InitializeComponent();
        }
    }
}

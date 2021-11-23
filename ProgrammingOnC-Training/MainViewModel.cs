using FuncProgrammingProjectDOTNET.LessonsViews;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuncProgrammingProjectDOTNET
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            OpenFirstLessonCommand = new RelayCommand(OpenFirstLesson);
            OpenSecondLessonCommand = new RelayCommand(OpenSecondLesson);
            OpenThirdLessonCommand = new RelayCommand(OpenThirdLesson);
            OpenFourthLessonCommand = new RelayCommand(OpenFourthLesson);
        }
        public ICommand OpenFirstLessonCommand { get; set; }
        public ICommand OpenSecondLessonCommand { get; set; }
        public ICommand OpenThirdLessonCommand { get; set; }
        public ICommand OpenFourthLessonCommand { get; set; }
        public void OpenFirstLesson()
        {
            Lesson1 lsWindow = new Lesson1();
            lsWindow.Show();
        }
        public void OpenSecondLesson()
        {
            Lesson2 lsWindow = new Lesson2();
            lsWindow.Show();
        }
        public void OpenThirdLesson()
        {
            Lesson3 lsWindow = new Lesson3();
            lsWindow.Show();
        }
        public void OpenFourthLesson()
        {
            Lesson4 lsWindow = new Lesson4();
            lsWindow.Show();
        }
    }
}

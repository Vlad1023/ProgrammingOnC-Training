using GalaSoft.MvvmLight.Command;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FuncProgrammingProjectDOTNET.LessonsViewModels
{
    public class Lesson3ViewModel : INotifyPropertyChanged
    {
        public Lesson3ViewModel()
        {

        }

        #region -- INotifyPropertyChanged implementation --

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region -- Public properties --

        public string ExampleOneCode => Constants.ExampleOneCode;

        public string ExampleTwoCode => Constants.ExampleTwoCode;

        public string ExampleThreeCode => Constants.ExampleThreeCode;

        public string ExampleFourCode => Constants.ExampleFourCode;

        public string ExampleFiveCode => Constants.ExampleFiveCode;

        private PlotModel _plotExampleOne;
        public PlotModel PlotExampleOne
        {
            get => _plotExampleOne;
            set => SetProperty(ref _plotExampleOne, value);
        }

        private PlotModel _plotExampleTwo;
        public PlotModel PlotExampleTwo
        {
            get => _plotExampleTwo;
            set => SetProperty(ref _plotExampleTwo, value);
        }

        private PlotModel _plotExampleThree;
        public PlotModel PlotExampleThree
        {
            get => _plotExampleThree;
            set => SetProperty(ref _plotExampleThree, value);
        }

        private PlotModel _plotExampleFour;
        public PlotModel PlotExampleFour
        {
            get => _plotExampleFour;
            set => SetProperty(ref _plotExampleFour, value);
        }

        private PlotModel _plotExampleFive;
        public PlotModel PlotExampleFive
        {
            get => _plotExampleFive;
            set => SetProperty(ref _plotExampleFive, value);
        }

        public ICommand ExampleOneCommnad => new RelayCommand(OnExampleOneCommnad);

        public ICommand ExampleTwoCommnad => new RelayCommand(OnExampleTwoCommnad);

        public ICommand ExampleThreeCommnad => new RelayCommand(OnExampleThreeCommnad);

        public ICommand ExampleFourCommnad => new RelayCommand(OnExampleFourCommnad);

        public ICommand ExampleFiveCommnad => new RelayCommand(OnExampleFiveCommnad);

        #endregion

        #region -- Private helpers --

        private void OnExampleFiveCommnad()
        {
            var steps = (int)((Math.Abs(-Math.PI) + Math.Abs(Math.PI)) / 0.1);

            var sinData = new DataPoint[steps];
            for (int i = 0; i < steps; ++i)
            {
                var x = -Math.PI + 0.1 * i;
                sinData[i] = new DataPoint(x, Math.Sin(x));
            }

            var stem = new StemSeries
            {
                MarkerStroke = OxyColors.Green,
                MarkerType = MarkerType.Circle
            };
            stem.Points.AddRange(sinData);

            var model = new PlotModel();
            model.Series.Add(stem);

            PlotExampleFive = model;
        }

        private void OnExampleFourCommnad()
        {
            var singleData = Enumerable.Range(0, 100)
                             .Select(x => Math.Exp(-1.0 / 2.0 * Math.Pow((x - 50.0) / 20.0, 2.0)))
                             .ToArray();

            var data = new double[100, 100];
            for (int x = 0; x < 100; ++x)
            {
                for (int y = 0; y < 100; ++y)
                {
                    data[y, x] = singleData[x] * singleData[(y + 30) % 100] * 100;
                }
            }

            var heatMap = new HeatMapSeries
            {
                X0 = 0, X1 = 99, Y0 = 0, Y1 = 99,
                Interpolate = true,
                RenderMethod = HeatMapRenderMethod.Bitmap,
                Data = data
            };

            var model = new PlotModel();
            model.Axes.Add(new LinearColorAxis { Palette = OxyPalettes.Rainbow(100) });
            model.Series.Add(heatMap);

            PlotExampleFour = model;
        }

        private void OnExampleThreeCommnad()
        {
            var pie = new PieSeries()
            {
                Title = "Pie Series",
                StrokeThickness = 1
            };

            pie.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
            pie.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            pie.Slices.Add(new PieSlice("Asia", 4157) { IsExploded = true });
            pie.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            pie.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            var model = new PlotModel();
            model.Series.Add(pie);

            PlotExampleThree = model;
        }

        private void OnExampleTwoCommnad()
        {
            var bar = new BarSeries()
            {
                Title = "Bar Series",
                StrokeColor = OxyColors.Black,
                FillColor = OxyColors.Red,
                StrokeThickness = 1
            };

            bar.Items.Add(new BarItem(10));
            bar.Items.Add(new BarItem(5));
            bar.Items.Add(new BarItem(1));
            bar.Items.Add(new BarItem(3));

            var model = new PlotModel();
            model.Series.Add(bar);

            PlotExampleTwo = model;
        }

        private void OnExampleOneCommnad()
        {
            var line = new LineSeries()
            {
                Title = $"Line Series",
                Color = OxyColors.Black,
                StrokeThickness = 1,
                MarkerSize = 2,
                MarkerType = MarkerType.Circle
            };

            line.Points.Add(new DataPoint(10, 10));
            line.Points.Add(new DataPoint(5, 5));
            line.Points.Add(new DataPoint(1, 12));
            line.Points.Add(new DataPoint(3, 4));

            var model = new PlotModel();
            model.Series.Add(line);

            PlotExampleOne = model;
        }

        private void SetProperty<T>(ref T oldValue, T newValue, [CallerMemberName] string prop = null)
        {
            if (oldValue == null || !oldValue.Equals(newValue))
            {
                oldValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        #endregion

        private static class Constants
        {
            public static string ExampleOneCode = @"var line = new LineSeries()
{
    Title = $""Line Series"",
    Color = OxyColors.Black,
    StrokeThickness = 1,
    MarkerSize = 2,
    MarkerType = MarkerType.Circle
};

line.Points.Add(new DataPoint(10, 10));
line.Points.Add(new DataPoint(5, 5));
line.Points.Add(new DataPoint(1, 12));
line.Points.Add(new DataPoint(3, 4));";

            public static string ExampleTwoCode = @"var bar = new BarSeries()
{
    Title = ""Bar Series"",
    StrokeColor = OxyColors.Black,
    FillColor = OxyColors.Red,
    StrokeThickness = 1
};

bar.Items.Add(new BarItem(10));
bar.Items.Add(new BarItem(5));
bar.Items.Add(new BarItem(1));
bar.Items.Add(new BarItem(3));";

            public static string ExampleThreeCode = @"
var pie = new PieSeries()
{
    Title = ""Pie Series"",
    StrokeThickness = 1
};

pie.Slices.Add(new PieSlice(""Africa"", 1030) { IsExploded = false, Fill = OxyColors.PaleVioletRed });
pie.Slices.Add(new PieSlice(""Americas"", 929) { IsExploded = true });
pie.Slices.Add(new PieSlice(""Asia"", 4157) { IsExploded = true });
pie.Slices.Add(new PieSlice(""Europe"", 739) { IsExploded = true });
pie.Slices.Add(new PieSlice(""Oceania"", 35) { IsExploded = true });

var model = new PlotModel();
model.Series.Add(pie);";

            public static string ExampleFourCode = @"
var singleData = Enumerable.Range(0, 100)
                 .Select(x => Math.Exp(-1.0 / 2.0 * Math.Pow((x - 50.0) / 20.0, 2.0)))
                 .ToArray();

var data = new double[100, 100];
for (int x = 0; x < 100; ++x)
{
    for (int y = 0; y < 100; ++y)
    {
        data[y, x] = singleData[x] * singleData[(y + 30) % 100] * 100;
    }
}

var heatMap = new HeatMapSeries
{
    X0 = 0, X1 = 99, Y0 = 0, Y1 = 99,
    Interpolate = true,
    RenderMethod = HeatMapRenderMethod.Bitmap,
    Data = data
};

var model = new PlotModel();
model.Axes.Add(new LinearColorAxis { Palette = OxyPalettes.Rainbow(100) });
model.Series.Add(heatMap);";

            public static string ExampleFiveCode = @"
var steps = (int)((Math.Abs(-Math.PI) + Math.Abs(Math.PI)) / 0.1);

var sinData = new DataPoint[steps];
for (int i = 0; i < steps; ++i)
{
    var x = -Math.PI + 0.1 * i;
    sinData[i] = new DataPoint(x, Math.Sin(x));
}

var stem = new StemSeries
{
    MarkerStroke = OxyColors.Green,
    MarkerType = MarkerType.Circle
};
stem.Points.AddRange(sinData);

var model = new PlotModel();
model.Series.Add(stem);";
        }
    }
}

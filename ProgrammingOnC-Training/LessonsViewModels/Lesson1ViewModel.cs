using GalaSoft.MvvmLight.Command;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FuncProgrammingProjectDOTNET.LessonsViewModels
{
    public class Lesson1ViewModel : INotifyPropertyChanged
    {
        private IEnumerable<string> selectResult;
        private IEnumerable<string> whereResult;
        private PlotModel orderByResult;
        private PlotModel aggregateResult;
        private IEnumerable<CompanyPhonesViewModel> groupByResult;
        private readonly string selectCodeString =
                @"string[] teams = {""Бавария"", ""Боруссия"", ""Реал Мадрид"", ""Манчестер Сити"", ""ПСЖ"", ""Барселона""};
 
                var selectedTeams = from t in teams // определяем каждый объект из teams как t
                                    select t;
                foreach (string s in selectedTeams)
                    Console.WriteLine(s);
                }";
        private readonly string whereCodeString =
           @"string[] teams = {""Бавария"", ""Боруссия"", ""Реал Мадрид"", ""Манчестер Сити"", ""ПСЖ"", ""Барселона""};
 
                var selectedTeams = from t in teams // определяем каждый объект из teams как t
                                    where t.ToUpper().StartsWith(""Б"") //фильтрация по критерию
                                    select t;
                foreach (string s in selectedTeams)
                    Console.WriteLine(s);
                }";
        private readonly string orderByString =
        @"class Pet
         {
            public string Name { get; set; }
            public int Age { get; set; }
         }

          Pet[] pets = { new Pet { Name=""Barley"", Age=8 },
                           new Pet { Name=""Mash'"", Age=9 },
                           new Pet { Name=""Cobel'"", Age=10 },
                           new Pet { Name=""Boots"", Age=4 },
                           new Pet { Name=""Whiskers"", Age=1 } };

        IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);
        ";
        private readonly string aggregateString =
            @"class Person
            {
                public int Age { get; set; }
                public double Sallary { get; set; }
            }
            var people = new List<Person>()
            {
                new Person { Age = 18, Sallary = 300 },
                new Person { Age = 19, Sallary = 150 },
                new Person { Age = 23, Sallary = 228 },
                new Person { Age = 30, Sallary = 1489 },
                new Person { Age = 45, Sallary = 1800 },
            };
            var peopleSallaries = people.Select(p => p.Sallary);
            double totalSallary = peopleSallaries.Aggregate((x, y) => x + y);
            ";
        private readonly string groupByString =
            @"List<Phone> phones = new List<Phone>
            {
            new Phone {Name=""Lumia 430"", Company=""Microsoft"" },
            new Phone {Name""Mi 5"", Company=""Xiaomi"" },
            new Phone {Name=""LG G 3"", Company=""LG"" },
            new Phone { Name = ""iPhone 5"", Company = ""Apple"" },
            new Phone { Name = ""Lumia 930"" Company = ""Microsoft"" },
            new Phone { Name = ""iPhone 6"", Company = ""Apple"" },
            new Phone { Name = ""Lumia 630"", Company = ""Microsoft"" },
            new Phone { Name = ""LG G 4"", Company = ""LG"" }
            };

            var phoneGroups = from phone in phones
                              group phone by phone.Company;

            foreach (IGrouping<string, Phone> g in phoneGroups)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.Name);
                Console.WriteLine();
            }
";
        public Lesson1ViewModel()
        {
            this.RunSelectCode = new RelayCommand(ExecuteSelectCode);
            this.RunWhereCode = new RelayCommand(ExecuteWhereCode);
            this.RunOrderByCode = new RelayCommand(ExecuteOrderByCode);
            this.RunAggregateCode = new RelayCommand(ExecuteAggregateCode);
            this.RunGroupByCode = new RelayCommand(ExecuteGroupByCode);
        }
        public ICommand RunSelectCode { get; set; }
        public ICommand RunWhereCode { get; set; }
        public ICommand RunOrderByCode { get; set; }
        public ICommand RunAggregateCode { get; set; }
        public ICommand RunGroupByCode { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void ExecuteSelectCode()
        {
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            var selectedTeams = from t in teams
                                select t;
            this.SelectResult = selectedTeams;
        }

        private void ExecuteWhereCode()
        {
            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            var selectedTeams = from t in teams
                                where t.ToUpper().StartsWith("Б") //фильтрация по критерию
                                select t;
            this.WhereResult = selectedTeams;
        }

        private void ExecuteOrderByCode()
        {

            Pet[] pets = { new Pet { Name="Barley", Age=8 },
                           new Pet { Name="Mash", Age=9 },
                           new Pet { Name="Cobel", Age=10 },
                           new Pet { Name="Boots", Age=4 },
                           new Pet { Name="Whiskers", Age=1 } };

            IEnumerable<Pet> query = pets.OrderBy(pet => pet.Age);

            var plotModel = new PlotModel();
            var xAxis = new LinearAxis
            { Title = "Pet age", Position = AxisPosition.Bottom };
            plotModel.Axes.Add(xAxis);

            var yAxis = new CategoryAxis
            { Title = "Pet name", Position = AxisPosition.Left };
            var petNames = query.Select(b => b.Name);
            yAxis.Labels.AddRange(petNames);
            plotModel.Axes.Add(yAxis);

            var series = new BarSeries();
            var items = query.Select(b => new BarItem(b.Age));
            series.ItemsSource = items;
            plotModel.Series.Add(series);

            this.OrderByResult = plotModel;
        }


        public void ExecuteAggregateCode()
        {
            var people = new List<Person>()
            {
                new Person { Age = 18, Sallary = 300 },
                new Person { Age = 19, Sallary = 150 },
                new Person { Age = 23, Sallary = 228 },
                new Person { Age = 30, Sallary = 1489 },
                new Person { Age = 45, Sallary = 1800 },
            };
            var peopleSallaries = people.Select(p => p.Sallary);
            double totalSallary = peopleSallaries.Aggregate((x, y) => x + y);

            var plotModel = new PlotModel();
            var xAxis = new LinearAxis
            {
                Title = "Step",
                Position = AxisPosition.Bottom,
                MinorStep = 1,
                MajorStep = 1
            };
            plotModel.Axes.Add(xAxis);

            var yAxis = new LinearAxis
            { Title = "Cuurent aggregated sallary", Position = AxisPosition.Left };
            plotModel.Axes.Add(yAxis);

            var dataPointsSeries = new LineSeries();
            dataPointsSeries.Points.Add(new DataPoint(1, 300));
            dataPointsSeries.Points.Add(new DataPoint(2, 450));
            dataPointsSeries.Points.Add(new DataPoint(3, 678));
            dataPointsSeries.Points.Add(new DataPoint(4, 2167));
            dataPointsSeries.Points.Add(new DataPoint(5, 3967));

            plotModel.Series.Add(dataPointsSeries);

            this.AggregateResult = plotModel;
        }

        public void ExecuteGroupByCode()
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone {Name="Lumia 430", Company="Microsoft" },
                new Phone {Name="Mi 5", Company="Xiaomi" },
                new Phone {Name="LG G 3", Company="LG" },
                new Phone {Name="iPhone 5", Company="Apple" },
                new Phone {Name="Lumia 930", Company="Microsoft" },
                new Phone {Name="iPhone 6", Company="Apple" },
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="LG G 4", Company="LG" }
            };

            var phoneGroups = from phone in phones
                              group phone by phone.Company;
            var result = new List<CompanyPhonesViewModel>();
            foreach (IGrouping<string, Phone> g in phoneGroups)
            {
                var companyPhones = new CompanyPhonesViewModel();
                companyPhones.CompanyName = g.Key;
                StringBuilder phoneModels = new StringBuilder();
                foreach (var t in g)
                    phoneModels.Append(t.Name += ", ");
                companyPhones.phoneModels = phoneModels.ToString();
                result.Add(companyPhones);
            }
            this.GroupByResult = result;
        }

        public string SelectCodeString => selectCodeString;
        public string WhereCodeString => whereCodeString;
        public string OrderByCodeString => orderByString;
        public string AggregateCodeString => aggregateString;
        public string GroupByCodeString => groupByString;

        public IEnumerable<string> SelectResult
        {
            get
            {
                return this.selectResult;
            }
            set
            {
                this.selectResult = value;
                OnPropertyChanged("SelectResult");
            }
        }

        public IEnumerable<string> WhereResult
        {
            get
            {
                return this.whereResult;
            }
            set
            {
                this.whereResult = value;
                OnPropertyChanged("WhereResult");
            }
        }

        public PlotModel OrderByResult
        {
            get
            {
                return this.orderByResult;
            }
            set
            {
                this.orderByResult = value;
                OnPropertyChanged("OrderByResult");
            }
        }

        public PlotModel AggregateResult
        {
            get
            {
                return this.aggregateResult;
            }
            set
            {
                this.aggregateResult = value;
                OnPropertyChanged("AggregateResult");
            }
        }

        public IEnumerable<CompanyPhonesViewModel> GroupByResult
        {
            get
            {
                return this.groupByResult;
            }
            set
            {
                this.groupByResult = value;
                OnPropertyChanged("GroupByResult");
            }
        }

        class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        class Person
        {
            public int Age { get; set; }
            public double Sallary { get; set; }
        }
        class Phone
        {
            public string Name { get; set; }
            public string Company { get; set; }
        }

        public class CompanyPhonesViewModel
        {
            public string CompanyName { get; set; }
            public string phoneModels { get; set; }
        }
    }
}

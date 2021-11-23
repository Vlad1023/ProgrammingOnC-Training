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
    public class Lesson2ViewModel : INotifyPropertyChanged
    {
        private IEnumerable<string> selectResult;
        private IEnumerable<string> whereResult;
        private IEnumerable<string> orderByResult;
        private IEnumerable<string> aggregateResult;
        private IEnumerable<CompanyPhonesViewModel> groupByResult;
        private readonly string selectCodeString =
                @"let hello name = ""Hello "" + name
                //usage
                hello ""Maxim""
                hello ""Vlad""";
        private readonly string whereCodeString =
           @"// define the square function
            let square x = x * x

            let sumOfSquares n =
            [1..n] |> List.map square |> List.sum

            // try it
            sumOfSquares 5
            sumOfSquares 6
            sumOfSquares 10";
        private readonly string orderByString =
        @"// define the square function
            let squareF x:float = x * x

            // try it
            squareF 10.5
            squareF 22.8
            squareF 13.1
        ";
        private readonly string aggregateString =
            @"let list1 = [ 1 .. 10 ]

            let addToList n = list1::n

            //usage
            addToList 15
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
        public Lesson2ViewModel()
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
            var result1 = FSharpSampleLibrary.FSharpExamples.hello("Maxim");
            var result2 = FSharpSampleLibrary.FSharpExamples.hello("Vlad");
            this.SelectResult = new List<string> { result1.ToString(), result2.ToString() };
        }

        private void ExecuteWhereCode()
        {
            int result1 = FSharpSampleLibrary.FSharpExamples.sumOfSquares(5);
            int result2 = FSharpSampleLibrary.FSharpExamples.sumOfSquares(6);
            int result3 = FSharpSampleLibrary.FSharpExamples.sumOfSquares(10);
            this.WhereResult = new List<string> { result1.ToString(), result2.ToString(), result3.ToString() };
        }

        private void ExecuteOrderByCode()
        {
            double result1 = FSharpSampleLibrary.FSharpExamples.squareF(10.5);
            double result2 = FSharpSampleLibrary.FSharpExamples.squareF(22.8);
            double result3 = FSharpSampleLibrary.FSharpExamples.squareF(13.1);
            this.OrderByResult = new List<string> { result1.ToString(), result2.ToString(), result3.ToString() };
        }


        public void ExecuteAggregateCode()
        {
            //var result = FSharpSampleLibrary.FSharpExamples.addToList(15);
            //this.AggregateResult = result;
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

        public IEnumerable<string> OrderByResult
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

        public IEnumerable<string> AggregateResult
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

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
        private IEnumerable<string> groupByResult;
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

            let list2 = [ 2; 3; 5]

            let list3 = 40::list1

            let list4 = list1 @ list2

            let rec sum list =
               match list with
               | head :: tail -> head + sum tail
               | [] -> 0

            //usage
            printf list3
            printf list4
            printf sum [1;3;9;7]
            ";
        private readonly string groupByString =
            @"let squares =
                seq {
                    for i in 1..3 -> i * i
                }

            let cubes =
                seq {
                    for i in 1..3 -> i * i * i
                }

            let squaresAndCubes =
                seq {
                    yield! squares
                    yield! cubes
                }

        //usage
        squaresAndCubes
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
            var list3 = string.Join(",", FSharpSampleLibrary.FSharpExamples.list3.ToList());
            var list4 = string.Join(",", FSharpSampleLibrary.FSharpExamples.list4.ToList());

            var sum = string.Join(",", FSharpSampleLibrary.FSharpExamples.sum(CreateFSharpList(new List<int>() { 1, 3, 9, 7 }, 0)));
            this.AggregateResult = new List<string> { list3, list4, sum }; ;
        }

        private static Microsoft.FSharp.Collections.FSharpList<T> CreateFSharpList<T>(IList<T> input, int index)
        {
            if (index >= input.Count)
            {
                return Microsoft.FSharp.Collections.FSharpList<T>.Empty;
            }
            else
            {
                return Microsoft.FSharp.Collections.FSharpList<T>.Cons(input[index], CreateFSharpList(input, index + 1));
            }
        }

        public void ExecuteGroupByCode()
        {
            var result1 = string.Join(",", FSharpSampleLibrary.FSharpExamples.squaresAndCubes);
            this.GroupByResult = new List<string> { result1 };
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

        public IEnumerable<string> GroupByResult
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
    }
}

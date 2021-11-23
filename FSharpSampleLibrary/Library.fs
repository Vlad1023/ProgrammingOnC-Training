namespace FSharpSampleLibrary

module FSharpExamples =
    let hello name = "Hello " + name

    let square x = x * x

    let sumOfSquares n =
        [1..n] |> List.map square |> List.sum

    let squareF x:float = x * x

    let sumOfSquaresF n =
        [1.0..n] |> List.map squareF |> List.sum
    
    let list1 = [ 1 .. 10 ]

    let list2 = [ 2; 3; 5]

    let list3 = 40::list1

    let list4 = list1 @ list2

    let rec sum list =
       match list with
       | head :: tail -> head + sum tail
       | [] -> 0
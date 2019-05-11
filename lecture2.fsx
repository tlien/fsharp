open System

// #2.1
let f = function
    | x when x%5 = 0 -> false
    | x when x%2 = 0 || x%3 = 0 -> true
    | _ -> false

f(27);;
f(29);;
f(30);;
f(12);;

let rec pow = function
    | (_, 0) -> ""
    | (s, n) -> s + pow(s, n-1)

pow("Hej ", 5);;

let rec evenL = function
    | [] -> []
    | x::xs when x%2 = 0 && x > 0 -> x::evenL(xs)
    | _::xs -> evenL(xs)

evenL([2; 5; 7; 8; 5; 10; 18; 5; 3; 17]);;

let rec evenN = function
   | 0 -> []
   | x when x%2 = 0 && x > 0 -> x::evenN(x-1)
   | x -> evenN(x-1)

evenN(10);;

let rec split = function
    | [] -> ([], [])
    | x::y::xs -> 
    let (x1, y1) = split(xs)
    (x::x1, y::y1)
    | _ -> ([], [])

split([1..8])
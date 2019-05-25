open System

// 2.1
let f = function
    | x when x%5 = 0 -> false
    | x when x%2 = 0 || x%3 = 0 -> true
    | _ -> false

f(27);;
f(29);;
f(30);;
f(12);;

// 2.2
let rec pow = function
    | (_, 0) -> ""
    | (s, n) -> s + pow(s, n-1)

pow("Hej ", 5);;

let rec evenL = function
    | [] -> []
    | x::xs when x%2 = 0 && x > 0 -> x::evenL(xs)
    | _::xs -> evenL(xs)

evenL([2; 5; 7; 8; 5; 10; 18; 5; 3; 17]);;

// 4.3
let rec evenN = function
   | 0 -> []
   | x when x%2 = 0 && x > 0 -> x::evenN(x-1)
   | x -> evenN(x-1)

evenN(10);;

// 4.8
let rec split = function
    | [] -> ([], [])
    | x::y::xs -> 
    let (x1, y1) = split(xs)
    (x::x1, y::y1)
    | _ -> ([], [])

split([1..8])

// 4.9
let rec zip = function
   | [], [] -> []
   | _, [] -> raise <| ArgumentException("Listerne har ikke samme længde")
   | [], _ -> raise <| ArgumentException("Listerne har ikke samme længde")
   | x::xs, y::ys -> (x, y)::zip(xs, ys)

zip([1; 2; 3;], [1; 2; 3]);;
zip([1; 5; 7; 89; 4; 3; 2; 4;], [1; 5; 6; 3; 5; 6; 23; 6]);;
zip([1; 2; 3;], [1; 2; 3; 4;]);;
zip([1; 2; 3; 4;], [1; 2; 3;]);;

// 4.12
// Sum of integers satisfying predicate P
let rec sumP = function
   | _, [] -> 0
   | p, x::xs when p(x) -> x + sumP(p, xs)
   | p, _::xs -> sumP(p, xs)

let p(x) = x > 5;;
sumP(p, [2; 6; 8; 4; 3; 10; 6; 15;]);; // = 45
sumP(p, [5; 6]);; // = 6
sumP(p, [10; 3; 29; 7]);; // = 46

// Paper & Pencil
// 4.16 Find the types
// Found in notes under Type Inference
let rec q = function
| (x, []) -> []
| (x, y::ys) -> (x+y)::q(x-1, ys);;

q(5, [1; 2; 3; 3; 3; 3; 3; 3; 3; 3; 3; 3; 10; 7;]);;

let rec g = function
| [] -> []
| (x,y)::s -> (x,y)::(y,x)::g s;;

let rec h = function
| [] -> []
| x::xs -> x::(h xs)@[x];;

//
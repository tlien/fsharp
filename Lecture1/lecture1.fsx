open System

// #1

let rec f = function
    | 0 -> 0
    | n -> n + f(n-1)

// #2
let rec sum = function
    | (m,0) -> m
    | (m,n) -> m + n + sum(m, n-1)

// #3
let rec pasc = function
    | (n, k) when n = k -> 1
    | (_, 0) -> 1
    | (n, k) -> pasc(n-1, k-1) + pasc(n-1, k)

// #4
let rec multiplicity = function
    | (_, []) -> 0
    | (x, y::ys) when x = y -> 1 + multiplicity(x, ys)
    | (x, _::ys) -> multiplicity(x, ys)

// #5
let rec mulC = function
    | (_, []) -> []
    | (x, y::ys) ->  x*y::mulC(x, ys)

// #6
let rec addE = function
    | ([], ys) -> ys
    | (xs, []) -> xs
    | (x::xs, y::ys) -> x+y::addE(xs, ys)

// #7
let rec mulX = function
    | ys -> 0::ys

// #8
let rec mul = function
    | ([], _) -> [];
    | (x::xs, ys) -> addE(mulC(x, ys), mulX(mul(xs, ys)))

// #9
let rec toText = function
    | [], _ -> ""
    | [x], y -> String.Format("{0}x^{1}", x, y)
    | x::xs, y when y = 0 -> String.Format("{0} + {1}", x, toText(xs, y+1))
    | x::xs, y -> String.Format("{0}x^{1} + {2}", x, y, toText(xs, y+1))

let test9 = toText([2; 7; 12; 10; 2; 3], 0);;
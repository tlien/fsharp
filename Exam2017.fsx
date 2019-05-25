let rec f1 a b = 
    if a > b then f1 (a-b) b else a ;;


let rec f2 a b = 
    if a > b then 1 + f2 (a-b) b else 0

let rec f3 a b c = 
    if a > b then f3 (a-b) b (c+1) else c


f1 23 3;;
f1 21 3;;
f2 23 3;;
f3 23 3 0

let rec sumC xs k = 
    match xs with
    | [] -> k 0
    | x::rst -> sumC rst (fun v -> k(x+v))

sumC [1..4] (fun v -> 0 + v)

let rec sum xs = 
    match xs with
    | [] -> 0
    | x::rst -> x + sum rst
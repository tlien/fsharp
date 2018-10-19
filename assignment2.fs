module assignment2

type Term = | V of string | C of int | F of string * Term list

let t1 = V "x"
let t2 = C 3
let t3 = F("f0", [])
let t4 = F("f1",[C 3;F("f0",[])])
let t5 = F("max",[V "x";C 3])

let rec isGround = function
    | V s -> false
    | C i -> true
    | F(s,a) -> List.forall isGround a

printfn "t1 isGround: %b" (isGround t1)
printfn "t2 isGround: %b" (isGround t2)
printfn "t3 isGround: %b" (isGround t3)
printfn "t4 isGround: %b" (isGround t4)
printfn "t5 isGround: %b" (isGround t5)


let rec listHelper = function
        | [] -> ")"
        | [a] -> toString a
        | F(_, a::rest)::b -> "," + toString a + listHelper rest + listHelper b
        | _ -> ""
  
and toString = function
        | V s -> s
        | C i -> string i
        | F(s, a) -> s + "(" + listHelper a


// let rec toString = function
//     | V s -> s
//     | C i -> string i
//     | F(s, a::rest) when rest.Length > 1 -> s + "(" + toString a + "," + ")" + List.fold(rest) toString
//     | _ -> ""

// let rec toString =
//         function
//         | V s -> s
//         | C i -> string i
//         | F(s, a) -> List.foldBack(fun (s, a) -> toString s) toString a

 

    // | F(s, a::rest)  -> s + "(" +

[<EntryPoint>]
let main argv =
    printfn "%s" (toString t4)
    0 // return an integer exit code

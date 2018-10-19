//#######################################
//##### ASSIGNMENT 1
//##### Author: s165242,
//#####         Thomas Lien Christensen
//#######################################

module assignment1

// ########
// Task 2.1
// ########
type Species = string 
type Location = string
type Time = int
type Interval = Time * Time
type Observation = Species * Location * Time
type Count<'a when 'a:equality> = ('a*int) list

let os = [("Owl","L1",3); ("Sparrow","L2",4); ("Eagle","L3",5); 
            ("Falcon","L2",7); ("Sparrow","L1",9); ("Eagle","L1",14)]

let rec locationsOf s (os: Observation list) =
    match os with
        | (x,y,_)::rest ->
             if s = x then y::locationsOf s rest
             else locationsOf s rest
        | [] -> []

let locTest1 = locationsOf "Owl" os // Expected: ["L1"]
let locTest2 = locationsOf "Sparrow" os // Expected: ["L2"; "L1"]
let locTest3 = locationsOf "Eagle" os // Expected: ["L3"; "L1"]
let locTest4 = locationsOf "" os // Expected: []
let locTest5 = locationsOf "SpeciesThatDoesNotExist" os // Expected: []

// ########
// Task 2.2 
// ########
let rec insert a (occ:Count<Species>):Count<Species> =
    match occ with
    | (s,c)::rest -> 
            if s = a then (s,c+1)::rest
            else (s,c)::insert a rest
    | [] when a > " " -> [(a,1)]
    | [] -> []


let insertTestList = [("Eagle",2); ("Sparrow", 1); ("Owl", 2)]
let insertTest1 = insert "Owl" insertTestList // Expected: [("Eagle", 2); ("Sparrow", 1); ("Owl", 3)]
let insertTest2 = insert "Lion" insertTestList // Expected: [("Eagle", 2); ("Sparrow", 1); ("Owl", 3); ("Lion", 1)] 
let insertTest3 = insert "" insertTestList // Expected: [("Eagle", 2); ("Sparrow", 1); ("Owl", 2)]

// ########
// Task 2.3 
// ########
let rec toCount = function
    | ([]:Observation list) -> ([]:Count<Species>)
    | (x,_,_)::rest -> (insert x (toCount rest))


let toCountTestList = [("Owl","L1",3); ("Sparrow","L2",4); ("Eagle","L3",5); 
            ("Falcon","L2",7); ("Sparrow","L1",9); ("Eagle","L1",14); ("Sparrow","L2",2); ("Falcon","L2",4);]
let toCountTest1 = toCount toCountTestList // Expected: [("Falcon", 2); ("Sparrow", 3); ("Eagle", 2); ("Owl", 1)]
let toCountTest2 = toCount [] // Expected: []

// ########
// Task 2.4
// ########
let rec select f intv = 
        let (t1,t2) = intv
        function
        | ([]:Observation list) -> []
        | (s,l,t)::rest
          -> if t1 <= t && t <= t2
             then f((s,l,t):Observation)::select f intv rest
             else select f intv rest
// ########
// Task 2.5
// ########
let e = select (fun (s,l,t) -> (s,l)) (4,9) os

// ##################
// ### END TASK 2 ###
// ##################

// ############
// Task 3 (2.1)
// ############

// I'm using List.choose, as I need its extended filter function
// to exclusively return a list of locations like in 2.1.
let locationsOfHO s (os:Observation list) = 
            List.choose (fun obs ->
            match obs with
            | (s1,l,t) when s1 = s -> Some(l)
            | _ -> None) os

// ############
// Task 3 (2.3)
// ############

// I'm using List.fold, as it performs computations on all list-elements,
// and the inbuilt accumulator puts out a new list with the desired elements.
let toCountHO (os:Observation list):Count<Species> =
            List.fold (fun count obs ->
            let (s,_,_) = obs 
            insert s count) [] os



[<EntryPoint>]

let main argv =
    printfn "%A" argv
    0 // return an integer exit code

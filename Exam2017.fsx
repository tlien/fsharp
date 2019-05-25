let rec f1 a b = 
    if a > b then f1 (a-b) b else a ;;


let rec f2 a b = 
    if a > b then 1 + f2 (a-b) b else 0

f1 23 3;;
f1 21 3;;
f2 23 3;;
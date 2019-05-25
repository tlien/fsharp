# FSharp Exam Notes

## Type Inference

### Examples

#### 1. 
**Consider the declarations:**

```fsharp
// 1
let rec f = function
| (x, []) -> []
| (x, y::ys) -> (x+y)::f(x-1, ys);;

// 2
let rec g = function
| [] -> []
| (x,y)::s -> (x,y)::(y,x)::g s;;

// 3
let rec h = function
| [] -> []
| x::xs -> x::(h xs)@[x];;
```

**Find the types for f, g and h and explain the value of the expressions:**
1. f(x, [y0,y1, . . . ,yn−1]), n ≥ 0
2. g[(x0, y0),(x1, y1), . . . ,(xn−1, yn−1)], n ≥ 0
3. h[x0,x1, . . . ,xn−1], n ≥ 0

<hr/>

**Function 1** 

1.  ```Function``` indicates that the type of ```q``` is $\tau -> \tau '$.  
2.  The tuple means that $\tau$ must have the form $t_1 * t_2$ for some types $t_1$ and $t_2$
3.  $x-1$ means that $t_1$ must be of type ```int``` since $1$ is of type ```int```.
4.  $x+y$ means that $t_2$ must also be of type ```int```. Since $t_2$ is a list, $t_2$ is of type ```int list```.
5.  Since $\tau'$ is a list of products of $t_1$ and $t_2$ computations, it must also me of type ```int list```
6.  The type of ```q``` is ```int * int list -> int list```

**Function 2**

1. ```Function``` indicates that the type of ```g``` is $\tau -> \tau'$.
2. The function takes one argument meaning that $\tau$ must have the form $t_1$ for some type $t_1$.
3. $t_1$ is presented by ```(x,y)::s``` so $t_1$ must be a list of tuples.
4. The product is also a list of tuples, and there are no indications of strong typing. Due to the product being ```(x,y)::(y,x)::g s;;``` where ```x``` and ```y``` share the same spots in the tuple, ```x``` and ```y``` must be of the same type.
5. We know that $\tau$ and $\tau'$ are both lists of tuples, that the tuple units must be of the same type **and** that there has been no sign of strong typing. The tuples are therefore of types ```('a * 'a)```, and both $\tau$ and $\tau'$ are of types ```('a * 'a) list```.
6. ```g``` is of type ```('a * 'a) list -> ('a * 'a) list```

**Function 3**
1. ```Function``` indicates that the type of ```h``` is $\tau -> \tau'$.
2. The function takes one argument meaning that $\tau$ must have the form $t_1$ of some type $t_1$.
3. ```[]``` and ```x::xs``` means that $t_1$ must be a list of some type ```'a```.
4. ```x::(h xs)@[x]``` means that $\tau'$ must also be a list of some type ```'a```.
5. We know that $\tau$ and $\tau'$ are both of type ```a' list``` **and** there are no indications of ```'a``` being strongly typed.
6. ```h``` is of type ```'a list -> 'a list```.


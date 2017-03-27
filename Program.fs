module String 
open Microsoft.FSharp.Collections
open System

let constructTree sup =
    let opened : int array = [|for i in 0..sup -> Int32.MaxValue|]
    opened.[0] <- 0
    opened.[1] <- 0
    let rec createNodes (path : int list) length  =
        let current = path.Head
        if current <= sup && length <= opened.[current] then
            opened.[current] <- length
            let all = fun x -> createNodes (current + x :: path)  (length + 1)
            List.iter all path
    createNodes [1] 0
    Array.sum opened
                    
                    

[<EntryPoint>]
let main argv = 
    printf "%d \n" (constructTree 200)
    0

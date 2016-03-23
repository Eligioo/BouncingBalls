open System
open Velocity

let simulation_step list =
    let list' = list |> List.map(fun ((lx, ly),(vx,vy)) ->
        let ly',vy' =
            compute_y_velocity(ly, vy)
        let lx', vx' =
            compute_x_velocity(lx, vx)
        (lx', ly'),(vx',vy')
        )
    list'

let print_scene (x,y,v) =
    do Console.Clear()
    let x,y,v = int x, int y, int v
    for j = 10 downto 0 do
        for i = 0 to 30 do
            if (y+1) = j && i = x then
                Console.Write("o")
            elif j = 0 || i = 0 || j = 10 || i = 30 then
                Console.Write("*")
            else
                Console.Write(" ")
        Console.Write("\n")
    ignore(Console.ReadKey())

let rec simulation list =
    list |> List.iter(fun ((lx,ly),(vx,vy)) -> print_scene(lx,ly,vy))
    let list' =  simulation_step list
    if list'.IsEmpty = false then
        simulation list'

//List as parameter contains 2 tuples per element.
//Containing de x and y location. And the velocity.
let balls = [(5.0,15.0),(16.0,-2.0)]

do simulation balls    
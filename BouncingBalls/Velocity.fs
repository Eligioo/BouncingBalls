module Velocity

let dt  = 0.1
let g   = -9.81
let friction = 0.999

let compute_x_velocity(lx, vx) =
    if lx < 0.0 then
            (1.0,-vx*0.7)
    elif lx > 30.0 then
        (29.0,-vx*0.7)
    else
        (lx+vx*dt, vx * friction)

let compute_y_velocity(ly, vy) =
    if ly < 0.0 then
        (0.0,-vy*0.7)
    else
        (ly+vy*dt, vy+g*dt)    
# homwwork5


the main problem was the shooting machanics and the line drawing, all the other stuff was fine we used coliders and rigid body
so most of the stuff was made for us, the next level moving was by checking if there are enemy object using the count methode
the dissappear.cs is for deleting the birds when they stop moving,
the collision.cs is for killing the enemy when bird and farmer collide,
the slingshot.cs is all the mechanics of the game you set pigs amount there and more such thing
if you win you move to next level if no pigs are left you lose and restart the level
the lines algorithem work by checking if mouse is clicked you check the x,y and create the second points of the lines(line81-84)
to there then you spawn the bird there, if you stop i kept the points to be a point of my choose(it was a problem to define where and I overcome
it by creating an empty object and put it where i want and then give it to the script) i also needed to turn off the bird collider while it aint pressed(cause some non-scence because the collisions with the mouse box collider) the shooting was done by giving it some force at the velocity(phycics yay!) and by using the vector thats created from the distance of where the you stop pressed and the center point(fron above) and then multiplay by some force(line 108 all the func)
all the other objects was easy just colliders and reigid bodys


the git with all the files is at


[GitHub](https://github.com/game-dev-course/pigs_can_fly)


[itch](https://gamedevcourse.itch.io/pigs-can-fly)


unity 2021.3.21f1 LTS


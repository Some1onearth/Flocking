using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviour : ScriptableObject
{
    //virtual = allows us to override
    //Abstract = this class cannot be intialised, it has to be inherited to be used.

    //Children REQUIRE this method
    
    public abstract Vector2 CalculateMove(FlockAgent agent, Flock flock);
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FlockBehaviour
{
    //new = hides base class method
    //override = replace base class method
    public override Vector2 CalculateMove(FlockAgent currentAgent, Flock flock)
    {
        Vector2 cohesionMove = Vector2.zero;
        int count = 0;
        foreach(FlockAgent item in flock.agents)
        {
            if (Vector2.Distance(item.transform.position, currentAgent.transform.position) < 5)
            {
                cohesionMove += (Vector2)item.transform.position;
                count++;
            }
        }
        cohesionMove /= count;
        //at this point, we have calculated the average position of all agents within a radius of 5

        //to get the direction from A to B, we do B - A
        cohesionMove = cohesionMove - (Vector2)currentAgent.transform.position;

        //this will return the direction to the average agent position
        return cohesionMove;
    }
}

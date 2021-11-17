using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FilteredFlockBehaviour
{
    //new = hides base class method
    //override = replace base class method
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        Vector2 cohesionMove = Vector2.zero;

        List<Transform> filteredContext = context;
        if (filter != null)
        {
            filteredContext = filter.Filter(currentAgent, context);
        }
        int count = 0;
        foreach(Transform item in filteredContext)
        {
            if (Vector2.Distance(item.transform.position, currentAgent.transform.position) < flock.neighbourRadius)
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

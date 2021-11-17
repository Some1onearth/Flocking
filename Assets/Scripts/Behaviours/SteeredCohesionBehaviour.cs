using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/Behaviour/Steered Cohesion")]
public class SteeredCohesionBehaviour : FilteredFlockBehaviour
{
    Vector2 currentVelocity;
    public float agentSmoothTime = 0.5f;

    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        if(context.Count == 0)
        {
            return Vector2.zero;
        }
        Vector2 cohesionMove = Vector2.zero;
        
        List<Transform> filteredContext = context;
        if (filter == null)
        {
            filteredContext = filter.Filter(currentAgent, context);
        }

        int count = 0;

        foreach (Transform item in filteredContext)
        {
            if ((item.position - currentAgent.transform.position).sqrMagnitude <= flock.squareNeighbourRadius)
            {
                cohesionMove += (Vector2)item.position;
                count++;
            }
        }

        if (count != 0)
        {
            cohesionMove /= count;
        }
        //right now cohesion is the average direction we want to move in
        cohesionMove = cohesionMove - (Vector2)currentAgent.transform.position;
        // right now cohesion is the direction towards that position;
        cohesionMove = Vector2.SmoothDamp(currentAgent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        //now instead of jumping towards the directionw e want ot move in, we take a small step in that direction instead
        return cohesionMove;
    }
}

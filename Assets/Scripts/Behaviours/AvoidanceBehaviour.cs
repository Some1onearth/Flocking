using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
public class AvoidanceBehaviour : FlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent currentAgent, Flock flock)
    {
        Vector2 avoidanceMove = Vector2.zero;

        int count = 0;

        foreach (FlockAgent item in flock.agents)
        {
            if (Vector2.Distance(item.transform.position, currentAgent.transform.position) < 5)
            {
                count++;
                avoidanceMove += (Vector2)(currentAgent.transform.position - item.transform.position);
            }
        }

        avoidanceMove /= count;

        return avoidanceMove;
    }
}

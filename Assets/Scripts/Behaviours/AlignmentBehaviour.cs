using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent currentAgent, Flock flock)
    {
        Vector2 alignmentMove = Vector2.zero;
        int count = 0;
        foreach (FlockAgent item in flock.agents)
        {
            if (Vector2.Distance(item.transform.position, currentAgent.transform.position) < 5)
            {
                alignmentMove += (Vector2)item.transform.up; //<--- .UP here
                count++;
            }
        }

        alignmentMove = alignmentMove / count;

        return alignmentMove;
    }
}

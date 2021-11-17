using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FilteredFlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent currentAgent, List<Transform> context, Flock flock)
    {
        if (context.Count == 0)
        {
            return currentAgent.transform.up;
        }

        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filteredContext = context;
        if (filter != null)
        {
            filteredContext = filter.Filter(currentAgent, context);
        }
        int count = 0;
        foreach (Transform item in filteredContext)
        {
            if (Vector2.Distance(item.transform.position, currentAgent.transform.position) < flock.neighbourRadius)
            {
                alignmentMove += (Vector2)item.transform.up; //<--- .UP here
                count++;
            }
        }

        alignmentMove = alignmentMove / count;

        return alignmentMove;
    }
}

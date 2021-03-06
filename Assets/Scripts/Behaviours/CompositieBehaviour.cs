using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Composite")]
public class CompositieBehaviour : FlockBehaviour
{
    [System.Serializable]
    public struct BehaviourGroup
    {

        public FlockBehaviour behaviour;
        public float weight;
    }

    public BehaviourGroup[] behaviours;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector2 move = Vector2.zero;

        foreach(BehaviourGroup currentBehaviour in behaviours)
        {
            Vector2 partialMove = currentBehaviour.behaviour.CalculateMove(agent, context, flock);
            partialMove.Normalize();
            partialMove *= currentBehaviour.weight;

            move += partialMove;
        }

        //TODO: We might need to average this out or normalise or limit
        return move;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    //new = hides base class method
    //override = replace base class method

    //virtual = allows us to override
    //Abstract = this class cannot be intialised,
        //it has to be inherited to be used.
        //Children REQUIRE this method
    public FlockAgent agentPrefab;
    //public int agentCount;
    public FlockBehaviour behaviour;
    [Range(1,500)]
    public int startingCount = 20;
    float agentDensity = 0.08f;

    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    //[Range(0f, 1f)]
    //public float avoidanceRadiusMultiplier = 0.5f;

    public float squareMaxSpeed;
    public float squareNeighbourRadius;
    //public float squareAvoidanceRadius;

    public List<FlockAgent> agents = new List<FlockAgent>();
    // Start is called before the first frame update
    private void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        //squareAvoidanceRadius

        for (int n = 0; n < startingCount; n++)
        {
            Vector2 newPosition = ((Vector2)transform.position) + Random.insideUnitCircle * startingCount * agentDensity;
            Quaternion newRotation = Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f));
            FlockAgent newAgent = Instantiate(agentPrefab, newPosition, newRotation, transform);
            

            newAgent.Initialize(this); //'this' passes itself, no need for anything else to be passed
            newAgent.name = "Agent" + n;
            agents.Add(newAgent);
        }
    }
    private void Update()
    {
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            //testing
            agent.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, context.Count/6f);
            Vector2 move = behaviour.CalculateMove(agent, this);

            //if above max speed, set it back to max speed
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed; //for now everything is just running at max speed
            }

            agent.Move(move);
        }
    }
    public List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbourRadius);
        foreach (Collider2D c in contextColliders)
        {
            //we are changing this in a second
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}

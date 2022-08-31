using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public AIWaypoint firstWaypoint;
    Transform player;

    public Light spotlight;
    public float viewDistance;
    public LayerMask viewMask;
    float viewAngle;

   
    void Start()
    {
        navMeshAgent.SetDestination(firstWaypoint.transform.position); //(object).transform.position says where the object is and what it's position/rotation is
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
    }

    
    void Update()
    {
        if(CanSeePlayer())
        {
            spotlight.color = Color.red;
            navMeshAgent.speed = 6;
            navMeshAgent.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AIWaypoint>())
        {
            navMeshAgent.SetDestination(other.GetComponent<AIWaypoint>().nextWaypoint.transform.position);
        }
    }

    bool CanSeePlayer() //this will pop out a true or false statement for us
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance) //this is checking to see if the player is in the guard's view distance
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle/2f) //is the player within guard's viewing angle
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask)) //if there's nothing in the guard's way
                {
                    return true;
                }
            }
        }
        return false;
    }
}

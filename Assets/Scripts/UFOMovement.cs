using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : Enemy
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    void Update()
    {
        MoveAlongPath();
    }
    void MoveAlongPath()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}

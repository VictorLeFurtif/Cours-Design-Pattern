using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public Transform startWayPoint;
    public Transform destinationWayPoint;

    public List<Transform> pathPoints = new List<Transform>();
    public float speed = 5f;

    private int currentIndex = 0;

    private void Start()
    {
        pathPoints = Pathfinding_Dijkstra.Instance.GetPath(startWayPoint, destinationWayPoint,false);
    }
    void Update()
    {
        if (pathPoints == null || pathPoints.Count == 0) return;

        Transform target = pathPoints[currentIndex];
        Vector3 direction = target.position - transform.position;

        if (direction.magnitude <= speed * Time.deltaTime)
        {
            transform.position = target.position;
            currentIndex++;
            if (currentIndex >= pathPoints.Count)
            {
                enabled = false; //le script se d�sactive une fois arriv�
            }
        }
        else
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}

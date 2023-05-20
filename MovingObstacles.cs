using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    public float speed;
    Vector3 targgetPos;

    public GameObject ways;
    public Transform[] waypoints;
    int pointIndex;
    int pointCount;
    int direction;


    private void Awake()
    {
        waypoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            waypoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }


    private void Start()
    {
        pointCount = waypoints.Length;
        pointIndex = 1;
        targgetPos = waypoints[pointIndex].transform.position;
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targgetPos, step);

        if (transform.position == targgetPos)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }
        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targgetPos = waypoints[pointIndex].transform.position;
    }
}

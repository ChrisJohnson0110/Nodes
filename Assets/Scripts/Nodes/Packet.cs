using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet : MonoBehaviour
{
    public Vector2 startingPos;
    public Vector2 TargetPos;
    public GameObject TargetObject;
    public float speed;
    private float progress = 0f;
    private bool packetArrived = false;

    private void OnEnable()
    {
        if (TargetObject != null)
        {
            TargetPos = TargetObject.transform.position;
            startingPos = transform.position;
        }
    }

    private void Update()
    {
        progress += speed * Time.deltaTime;
        transform.position = Vector3.Lerp(startingPos, TargetPos, progress);
        if (Vector2.Distance(transform.position, TargetObject.transform.position) < 0.001f)
        {
            transform.position = TargetPos;
            if (packetArrived == false)
            {
                TargetObject.GetComponent<Node>().PacketArrived(this);
                packetArrived = true;
            }
        }
    }

    //TODO might be worth moving to package manager
    public void UpdateTarget(GameObject a_targetObject)
    {
        TargetObject = a_targetObject;
        TargetPos = TargetObject.transform.position;
        startingPos = transform.position;
        progress = 0f;
        packetArrived = false;
    }
}

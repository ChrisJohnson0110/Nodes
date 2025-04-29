using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet : MonoBehaviour
{
    [HideInInspector] public Vector2 startingPos;
    [HideInInspector] public Vector2 TargetPos;
    [HideInInspector] public GameObject TargetObject;
    [HideInInspector] public float speed;

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
        transform.position = Vector3.Lerp(startingPos, TargetPos, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == TargetObject)
        {
            Debug.Log("packet reached target");
            gameObject.GetComponent<Node>().PacketArrived(this.gameObject);
        }
    }

    public void UpdateTarget(GameObject a_targetObject)
    {
        TargetObject = a_targetObject;
        TargetPos = TargetObject.transform.position;
        startingPos = transform.position;
    }
}

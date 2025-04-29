using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public NodeData nodeData { get; private set; }
    public GameObject nodeObject;
    public List<Upgrade> upgrades;
    protected Queue<GameObject> connections = new Queue<GameObject>();

    public bool timerRunning = false;
    private float timer;
    
    public void Initialize(NodeData a_nodeData)
    {
        nodeData = a_nodeData;
        StartTimer();
    }

    private void Update()
    {
        if (timerRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                ResetTimer();
                OnTimerComplete();
            }
        }
    }

    #region TIMER
    public void StartTimer()
    {
        timer = nodeData.transmittionSpeed;
        timerRunning = true;
    }
    public void StopTimer()
    {
        timerRunning = false;
    }
    public void ResetTimer()
    {
        timer = nodeData.transmittionSpeed;
    }
    protected virtual void OnTimerComplete()
    {
    }
    #endregion

    public virtual void PacketArrived(Packet a_packet)
    {

    }


    protected GameObject AddTarget(GameObject target)
    {
        connections.Enqueue(target);
        return target;
    }

    public GameObject GetNextTarget()
    {
        if (connections != null)
        {
            if (connections.Count > 0)
            {
                return connections.Dequeue();
            }
        }

        return null;
    }

    protected float GetSpeed()
    {
        //TODO increase by any upgrades
        return nodeData.transferSpeed;
    }

    public void AddTargetNode(GameObject a_targetNode)
    {
        connections.Enqueue(a_targetNode);
    }

}

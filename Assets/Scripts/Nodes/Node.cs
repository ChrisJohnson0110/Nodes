using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public NodeData nodeData { get; private set; }
    public GameObject nodeObject;
    public List<Upgrade> upgrades;
    public List<Node> connections;
    public Queue StoredData;

    public bool timerRunning = false;
    private float timer;
    

    public Node(NodeData a_nodeData)
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
                OnTimerComplete();
                StartTimer();
            }
        }
    }

    #region TIMER
    public void StartTimer()
    {
        timer = nodeData.transferSpeed;
        timerRunning = true;
    }
    public void StopTimer()
    {
        timerRunning = false;
    }
    public void ResetTimer()
    {
        timer = nodeData.transferSpeed;
    }
    protected virtual void OnTimerComplete()
    {
        Debug.Log("Timer Fin");
    }
    #endregion



}

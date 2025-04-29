using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : Node
{
    public Queue<GameObject> StoredPackets = new Queue<GameObject>();

    protected override void OnTimerComplete()
    {
        if (connections.Count >= 1 && StoredPackets.Count >= 1)
        {
            if (StoredPackets != null)
            {
                Debug.Log(connections.ToString());
                //Packet packet = StoredPackets.Dequeue().GetComponent<Packet>();
                //packet.UpdateTarget(AddTarget(GetNextTarget()));
            }
        }
    }

    public override void PacketArrived(GameObject a_packet)
    {
        StoredPackets.Enqueue(a_packet);
    }
}

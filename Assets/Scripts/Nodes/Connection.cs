using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : Node
{
    public Queue<GameObject> StoredPackets;

    public Connection(NodeData a_nodeData) : base(a_nodeData)
    {

    }

    protected override void OnTimerComplete()
    {
        if (StoredPackets != null)
        {
            Packet packet = StoredPackets.Dequeue().GetComponent<Packet>();
            packet.UpdateTarget(AddTarget(GetNextTarget()));
        }
    }

    public override void PacketArrived(GameObject a_packet)
    {
        StoredPackets.Enqueue(a_packet);
    }
}

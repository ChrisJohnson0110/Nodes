using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : Node
{
    public Queue<Packet> StoredPackets = new Queue<Packet>();

    protected override void OnTimerComplete()
    {
        if (connections.Count >= 1 && StoredPackets.Count >= 1)
        {
            if (StoredPackets != null)
            {
                Packet packet = StoredPackets.Dequeue();
                GameObject nextTarget = connections.Dequeue();
                packet.UpdateTarget(nextTarget);
                connections.Enqueue(nextTarget);
            }
        }
    }

    public override void PacketArrived(Packet a_packet)
    {
        StoredPackets.Enqueue(a_packet);
    }
}

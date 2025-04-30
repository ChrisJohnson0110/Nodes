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
                //check if the packets last object is the next connection, if it is check the next
                //if both are last then there must

                Packet packet = StoredPackets.Dequeue();

                GameObject nextTarget = connections.Dequeue();
                if (packet.LastObject == nextTarget)
                {
                    connections.Enqueue(nextTarget);
                    GameObject target = connections.Dequeue();
                    if (packet.LastObject == target)
                    {
                        connections.Enqueue(target);
                        return;
                    }
                    packet.UpdateTarget(target);
                    connections.Enqueue(target);
                    return;
                }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : Node
{
    protected override void OnTimerComplete()
    {
        base.OnTimerComplete();
    }

    public override void PacketArrived(Packet a_packet)
    {
        a_packet.gameObject.SetActive(false);
    }
}

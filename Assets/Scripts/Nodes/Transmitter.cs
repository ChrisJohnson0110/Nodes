using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmitter : Node
{

    protected override void OnTimerComplete()
    {
        if (connections.Count >= 1)
        {
            GameObject PacketObject = NodePacketManager.instance.GetPacket();//get a new inactive packet object
            if (PacketObject != null)
            {
                //setup packet
                Packet packet = PacketObject.GetComponent<Packet>(); //get the packet class
                                                                     //packet.TargetObject = AddTarget(GetNextTarget()); //set the target and requeue it
                packet.speed = GetSpeed();
                packet.UpdateTarget(AddTarget(GetNextTarget()));
                PacketObject.transform.position = transform.position;

                PacketObject.SetActive(true);
            }
        }
    }

    public override void PacketArrived(Packet a_packet)
    {
        Debug.LogError($"ERROR: PACKET ARRIVED AT TRANSMITTER {a_packet} ");
    }

}

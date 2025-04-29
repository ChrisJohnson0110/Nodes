using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmitter : Node
{
    public Transmitter(NodeData a_nodeData) : base(a_nodeData)
    {

    }

    protected override void OnTimerComplete()
    {
        GameObject PacketObject = NodePacketManager.instance.GetPacket();//get a new inactive packet object
        //setup packet
        Packet packet =  PacketObject.GetComponent<Packet>(); //get the packet class
        packet.TargetObject = AddTarget(GetNextTarget()); //set the target and requeue it
        packet.speed = GetSpeed();
        PacketObject.transform.position = transform.position;
        PacketObject.SetActive(true);
    }

    public override void PacketArrived(GameObject a_packet)
    {
        Debug.LogError($"ERROR: PACKET ARRIVED AT TRANSMITTER {a_packet} ");
    }

}

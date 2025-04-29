using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeTypes { Connection, Reciever, transmitter}

[CreateAssetMenu(fileName = "Node", menuName = "ScriptableObjects/Node", order = 1)]
public class NodeData : ScriptableObject
{
    public NodeTypes nodeType;
    public GameObject prefab;
    public float connectionRange;
    public float transferSpeed;
    public float transmittionSpeed;
    public float capacity;
}

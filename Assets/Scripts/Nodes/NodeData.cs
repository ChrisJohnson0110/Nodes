using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeTypes { Connection, Reciever, Spawner}

[CreateAssetMenu(fileName = "Node", menuName = "ScriptableObjects/Node", order = 1)]
public class NodeData : ScriptableObject
{
    public NodeTypes nodeType;
    public GameObject prefab;
    public float transferSpeed;
    public float capacity;
}

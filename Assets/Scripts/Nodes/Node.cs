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

    public Node(NodeData a_nodeData)
    {
        nodeData = a_nodeData;
    }


}

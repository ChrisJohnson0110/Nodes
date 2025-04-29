using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public static NodeManager instance;
    [HideInInspector] public Dictionary<Vector2, Node> nodes { get; private set; } = new Dictionary<Vector2, Node>();

    private Dictionary<NodeTypes, HashSet<NodeTypes>> connectionRules = new Dictionary<NodeTypes, HashSet<NodeTypes>> //rules for connections
    {
        { NodeTypes.transmitter, new HashSet<NodeTypes> { NodeTypes.Connection, NodeTypes.Reciever } },
        { NodeTypes.Connection,  new HashSet<NodeTypes> { NodeTypes.Connection, NodeTypes.Reciever } },
        { NodeTypes.Reciever,    new HashSet<NodeTypes> { NodeTypes.Connection } }
    };


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void CreateNewNode(NodeData a_nodeData, Vector2 a_position)
    {
        GameObject nodeObject = Instantiate(a_nodeData.prefab); ;
        Node node = null;

        switch (a_nodeData.nodeType)
        {
            case NodeTypes.transmitter: node = nodeObject.AddComponent<Transmitter>(); break;
            case NodeTypes.Connection: node = nodeObject.AddComponent<Connection>(); break;
            case NodeTypes.Reciever: node = nodeObject.AddComponent<Reciever>(); break;
        }
        node.Initialize(a_nodeData);
        node.nodeObject = nodeObject;
        node.nodeObject.layer = LayerMask.NameToLayer("Node");
        node.nodeObject.transform.SetParent(this.gameObject.transform);
        node.nodeObject.transform.position = a_position;

        //establish connections between nearby nodes
        AddNodeConnections(node);

        //add to existing nodes
        nodes[a_position] = node;

        //update placement visual
        RangeIndicator.instance.HideRangeIndicator();
    }

    public Node GetNode(GameObject a_gameObject)
    {
        return nodes[a_gameObject.transform.position];
    }

    private void AddNodeConnections(Node a_node)
    {
        foreach (Node node in nodes.Values)
        {
            if (node == a_node)
            {
                continue;
            }

            //should there be a connection
            if (Vector2.Distance(a_node.transform.position, node.transform.position) < a_node.nodeData.connectionRange)
            {
                //does a connection rule apply for the nodedata type
                if (connectionRules.TryGetValue(a_node.nodeData.nodeType, out var allowedTargets)) 
                {
                    //if the node is allowed to connect
                    if (allowedTargets.Contains(node.nodeData.nodeType))
                    {
                        FormConnection(a_node, node);
                    }
                }
               
            }

            //should there be a connection established back
            if (Vector2.Distance(a_node.transform.position, node.transform.position) < node.nodeData.connectionRange)
            {
                if (connectionRules.TryGetValue(node.nodeData.nodeType, out var allowedTargetss)) 
                {
                    //if the node is allowed to connect
                    if (allowedTargetss.Contains(a_node.nodeData.nodeType))
                    {
                        FormConnection(node, a_node);
                    }
                }
            }

        }
    }

    //add connections between nodes
    private void FormConnection(Node a_nodeOne, Node a_nodeTwo)
    {
        a_nodeOne.AddTargetNode(a_nodeTwo.nodeObject); //add node two as a target for node 
    }
}

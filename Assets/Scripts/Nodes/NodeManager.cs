using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public static NodeManager instance;
    [HideInInspector] public Dictionary<Vector2, Node> nodes { get; private set; } = new Dictionary<Vector2, Node>();

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

        node.nodeObject = nodeObject;
        node.nodeObject.layer = LayerMask.NameToLayer("Node");
        node.nodeObject.transform.SetParent(this.gameObject.transform);
        node.nodeObject.transform.position = a_position;

        //add connections
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

    private void UpdateNeatbyNodes(Node a_node)
    {
        //add all nearby nodes into node queue
        //update all nearby nodes adding new node to the queue
    }

    private void AddNodeConnections(Node a_node)
    {
        float range = a_node.nodeData.connectionRange;

        foreach (Node node in nodes.Values)
        {
            if (node == a_node)
            {
                continue;
            }
            if (Vector2.Distance(a_node.transform.position, node.transform.position) < range)
            {
                switch (a_node.nodeData.nodeType)
                {
                    case NodeTypes.transmitter: Transmitter(a_node, node); break;
                    case NodeTypes.Connection: Connection(a_node, node); break;
                    case NodeTypes.Reciever: Reciever(a_node, node); break;
                }
            }
        }
    }

    //nodeOne is the tpye of node that has just been created
    //nodeTwo is the node that has been checked and needs to be connected
    //this is the transmitter function so has been called because nodeOne is a transmitter node
    //depending on nodeTwo the objects that can be connected change
    private void Transmitter(Node a_nodeOne, Node a_nodeTwo)
    {
        switch (a_nodeTwo.nodeData.nodeType)
        {
            case NodeTypes.transmitter: Debug.Log("cant connect to transmitter"); break;
            case NodeTypes.Connection: FormConnection(a_nodeOne, a_nodeTwo); break;
            case NodeTypes.Reciever: FormConnection(a_nodeOne, a_nodeTwo); break;
        }
    }
    private void Connection(Node a_nodeOne, Node a_nodeTwo)
    {
        switch (a_nodeTwo.nodeData.nodeType)
        {
            case NodeTypes.transmitter: FormConnection(a_nodeOne, a_nodeTwo); break;
            case NodeTypes.Connection: FormConnection(a_nodeOne, a_nodeTwo); break;
            case NodeTypes.Reciever: FormConnection(a_nodeOne, a_nodeTwo); break;
        }
    }
    private void Reciever(Node a_nodeOne, Node a_nodeTwo)
    {
        switch (a_nodeTwo.nodeData.nodeType)
        {
            case NodeTypes.transmitter: FormConnection(a_nodeOne, a_nodeTwo); break;
            case NodeTypes.Connection: FormConnection(a_nodeOne, a_nodeTwo); break;
            case NodeTypes.Reciever: Debug.Log("cant connect to reciever"); break;
        }
    }



    private void FormConnection(Node a_nodeOne, Node a_nodeTwo)
    {
        a_nodeOne.AddTargetNode(a_nodeTwo.nodeObject); //add nearby to self
        a_nodeTwo.AddTargetNode(a_nodeOne.nodeObject); //add self to nearby
    }
}

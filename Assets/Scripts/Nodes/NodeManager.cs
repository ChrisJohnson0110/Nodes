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
        //node creation
        GameObject nodeObject = Instantiate(a_nodeData.prefab);
        Node node = nodeObject.AddComponent<Node>();
        node.nodeObject = nodeObject;
        node.nodeObject.layer = LayerMask.NameToLayer("Node");
        node.nodeObject.transform.SetParent(this.gameObject.transform);
        node.nodeObject.transform.position = a_position;

        //add to existing nodes
        nodes[a_position] = node;

        //update placement visual
        RangeIndicator.instance.HideRangeIndicator();
    }

    public Node GetNode(GameObject a_gameObject)
    {
        return nodes[a_gameObject.transform.position];
    }
}

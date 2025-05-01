using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeInfomationMenu : MonoBehaviour
{
    public static NodeInfomationMenu instance;

    private Node nodeToDisplay;

    [SerializeField] private TMP_Text nodeType;
    //line renderer for connections


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

    public void UpdateNodeToDisplay(Node a_node)
    {
        nodeToDisplay = a_node;
        PopulateInfomation();
    }

    private void PopulateInfomation()
    {
        nodeType.text = nodeToDisplay.nodeData.nodeType.ToString();
    }
}
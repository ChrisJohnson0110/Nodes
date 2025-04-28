using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfomationMenu : MonoBehaviour
{
    public static NodeInfomationMenu instance;

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

    public void PopulateMenu(Node a_node)
    {

    }
}
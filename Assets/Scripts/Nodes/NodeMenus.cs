using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMenus : MonoBehaviour
{
    public static NodeMenus instance;

    [SerializeField] private GameObject NodeCreationMenuObject;
    [SerializeField] private GameObject NodeInfomationMenuObject;

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

    public void ShowNodeCreationMenu()
    {
        NodeInfomationMenuObject.SetActive(false);
        NodeCreationMenuObject.SetActive(true);
    }

    public void HideNodeCreationMenu()
    {
        NodeCreationMenuObject.SetActive(false);
    }

    public void ShowNodeInfomationMenu(Node a_node)
    {
        HideNodeCreationMenu();
        NodeInfomationMenuObject.SetActive(true);
        NodeInfomationMenu.instance.PopulateMenu(a_node);
    }

    public void HideNodeInfomationMenu()
    {
        NodeInfomationMenuObject.SetActive(false);
    }
}

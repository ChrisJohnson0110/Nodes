using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNode : MonoBehaviour
{
    [SerializeField] private NodeData NodeToCreate;

    public void CreateNodeButton()
    {
        NodeManager.instance.CreateNewNode(NodeToCreate, ClickedPos.instance.LastClickedPosition);
        NodeMenus.instance.HideNodeCreationMenu();
    }
}

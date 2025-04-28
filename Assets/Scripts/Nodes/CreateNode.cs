using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private NodeData NodeToCreate;
    [SerializeField] private Color32 RangedIndicatorColor = new Color32();

    public void OnPointerEnter(PointerEventData eventData)
    {
        RangeIndicator.instance.UpdateRangeIndicator(NodeToCreate, RangedIndicatorColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RangeIndicator.instance.HideRangeIndicator();
    }

    public void CreateNodeButton()
    {
        NodeManager.instance.CreateNewNode(NodeToCreate, ClickedPos.instance.LastClickedPosition);
        NodeMenus.instance.HideNodeCreationMenu();
    }
}

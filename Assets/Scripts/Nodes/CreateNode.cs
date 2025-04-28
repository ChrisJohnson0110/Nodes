using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateNode : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private NodeData NodeToCreate;
    [SerializeField] private GameObject rangeIndicatorPrefab;
    [SerializeField] private Color32 RangedIndicatorColor = new Color32();
    private GameObject rangeIndicator;


    private void Awake()
    {
        rangeIndicator = Instantiate(rangeIndicatorPrefab);
        rangeIndicator.GetComponent<SpriteRenderer>().color = RangedIndicatorColor;
        rangeIndicator.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rangeIndicator.SetActive(true);
        rangeIndicator.transform.localScale = new Vector2(1, 1) * NodeToCreate.connectionRange;
        rangeIndicator.transform.position = ClickedPos.instance.LastClickedPosition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rangeIndicator.SetActive(false);
    }

    public void CreateNodeButton()
    {
        NodeManager.instance.CreateNewNode(NodeToCreate, ClickedPos.instance.LastClickedPosition);
        NodeMenus.instance.HideNodeCreationMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickedPos : MonoBehaviour
{
    public static ClickedPos instance;

    public Vector2 LastClickedPosition = new Vector2();
    [SerializeField] private GameObject PlaceHolder;

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
        HidePlaceHolder();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                ProcessClick(clickedObject, mouseWorldPos);
            }
        }
    }

    private void ProcessClick(GameObject clickedObject, Vector2 a_mouseWorldPos)
    {
        HidePlaceHolder();
        NodeMenus.instance.HideNodeCreationMenu();
        NodeMenus.instance.HideNodeInfomationMenu();

        LayerMask layer = clickedObject.layer;

        switch (LayerMask.LayerToName(layer))
        {
            case "Node" : NodeClick(clickedObject); break;
            case "Background" : BackgroundClick(a_mouseWorldPos); break;
        }
    }

    private void BackgroundClick(Vector2 a_mouseWorldPos)
    {
        LastClickedPosition = a_mouseWorldPos;
        PlaceHolder.transform.position = LastClickedPosition;
        PlaceHolder.GetComponent<SpriteRenderer>().enabled = true;

        NodeMenus.instance.ShowNodeCreationMenu();
    }

    private void NodeClick(GameObject a_node)
    {
        Node node = NodeManager.instance.GetNode(a_node);
        NodeMenus.instance.ShowNodeInfomationMenu(node);
    }

    public void HidePlaceHolder()
    {
        PlaceHolder.GetComponent<SpriteRenderer>().enabled = false;
        PlaceHolder.transform.position = new Vector2(-1,-1);
    }

}

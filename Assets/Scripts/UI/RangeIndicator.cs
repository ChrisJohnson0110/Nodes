using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    public static RangeIndicator instance;

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
        gameObject.transform.position = new Vector2(-10, -10);
    }

    public void UpdateRangeIndicator(NodeData a_NodeData, Color32 a_IndicatorColor)
    {
        gameObject.GetComponent<SpriteRenderer>().color = a_IndicatorColor;
        gameObject.transform.localScale = new Vector2(1, 1) * (a_NodeData.connectionRange * 2);
        gameObject.transform.position = ClickedPos.instance.LastClickedPosition;
    }

    public void HideRangeIndicator()
    {
        gameObject.transform.position = new Vector2(-10,-10);
    }
}

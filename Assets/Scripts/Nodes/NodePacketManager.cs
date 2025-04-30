using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePacketManager : MonoBehaviour
{
    public static NodePacketManager instance;

    private List<GameObject> packets = new List<GameObject>();
    [SerializeField] private GameObject packetPrefab;
    [SerializeField] private int numberOfPacketsToPool;

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

    private void Start()
    {
        GameObject temp;
        for (int i = 0; i < numberOfPacketsToPool; i++)
        {
            temp = Instantiate(packetPrefab);
            temp.transform.SetParent(this.transform);
            temp.SetActive(false);
            packets.Add(temp);
        }
    }

    public GameObject GetPacket()
    {
        for (int i = 0; i < numberOfPacketsToPool; i++)
        {
            if (packets[i].activeInHierarchy == false)
            {
                return packets[i];
            }
        }
        return null;
    }
}

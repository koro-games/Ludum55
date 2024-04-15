using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem instance;
    public List<Purchase> intheshop = new List<Purchase>();
    public Purchase[] pprefab;
    public GameObject[] penalty;
    public Transform itemholder;
    private void Awake()
    {
        instance = this;
    }
    public void AddItem(int count)
    {
        for (int i=0; i<count; i++)
        {
            AddItem();
        }
    }
    public void AddItem()
    {
        if (intheshop.Count >= 6)
        {
            Purchase puchasetodestoy= intheshop[0];
            intheshop.RemoveAt(0);
            Destroy(puchasetodestoy.gameObject);
            Instantiate(penalty[Random.Range(0, penalty.Length)],Vector3.zero,Quaternion.identity);
        }
        intheshop.Add(Instantiate(pprefab[Random.Range(0, pprefab.Length)], itemholder));
    }
}

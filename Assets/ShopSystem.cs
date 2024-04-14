using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem instance;
    public List<Purchase> intheshop = new List<Purchase>();
    public Purchase[] pprefab;
    public Transform itemholder;
    private void Awake()
    {
        instance = this;
    }
    public void AddItem()
    {
        if (intheshop.Count<6)
        {
            intheshop[0].gameObject.SetActive(false);
            intheshop.Add(Instantiate(pprefab[Random.Range(0,pprefab.Length)], itemholder));
        }
    }
}

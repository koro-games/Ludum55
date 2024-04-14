using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public GameObject objtoSpawn;
    public int cost;
    public TMP_Text costtext;
    SpawnDice spawn;
    private void Start()
    {
        costtext.text = "$" + cost;
        spawn = FindObjectOfType<SpawnDice>();
    }
    public void Buy()
    {
        RoundSystem rs = RoundSystem.instance;
        if (rs.score > cost && !spawn.hole.activeSelf)
        {
            rs.score -= cost;
            spawn.Spawn(objtoSpawn);
            ShopSystem.instance.intheshop.Remove(this);
            Destroy(gameObject);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public GameObject objtoSpawn;
    public int cost;
    public TMP_Text costtext;
    private void Start()
    {
        costtext.text = "$" + cost;
    }
    public void Buy()
    {
        RoundSystem rs = RoundSystem.instance;
        if (rs.score> cost)
        {
            rs.score -= cost;
        }
        if (objtoSpawn.tag=="Cube") Instantiate(objtoSpawn,GameObject.Find("<Dices>").transform);
    }
}

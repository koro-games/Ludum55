using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public List<DiceUI> diceUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(DiceUI dice in diceUI)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            dice.rect.transform.position = Camera.main.WorldToScreenPoint(dice.dice.transform.position);
        }
    }
}

public class DiceUI
{
    public DiceBehaviour dice;
    public GameObject rect;
}

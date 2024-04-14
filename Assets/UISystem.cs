using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public static UISystem UI;
    public RectTransform rect;
    [SerializeField] 
    Transform diceUIs;
    [SerializeField] 
    DiceUI diceUIprefab;
    public List<DiceUI> diceUIList=new List<DiceUI>();
    void Awake()
    {
        UI= this;
        rect = GetComponent<RectTransform>();
    }

    public void AddDice(DiceBehaviour newDice)
    {
        DiceUI newDiceUI = Instantiate(diceUIprefab, diceUIs);
        newDiceUI.dice = newDice;
        newDiceUI.uiSystem = this;
        diceUIList.Add(newDiceUI);
    }
    void Update()
    {

    }
}


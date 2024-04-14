using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    public static UISystem UI;
    public RectTransform rect;
    [SerializeField] 
    Transform diceUIs;
    [SerializeField] 
    DiceUI diceUIprefab;
    public List<DiceUI> diceUIList=new List<DiceUI>();

    [Header("UI")] 
    public ValueHandler roundText;
    public ValueHandler quotaText;
    public ValueHandler deadlineText;
    public ValueHandler scoreText;
    public TMP_Text ruleText;
    public Button rerollButton;
    RoundSystem roundSystem;
    public ComboText comboText;

    void Awake()
    {
        roundSystem = FindObjectOfType<RoundSystem>();
        UI = this;
        rect = GetComponent<RectTransform>();
        GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
    }
    public void UpdateScoreValues()
    {
        if (roundText.value != roundSystem.cRound) roundText.ChangeValue(roundSystem.cRound);
        if (quotaText.value != roundSystem.quota) quotaText.ChangeValue(roundSystem.quota);
        if (deadlineText.value != roundSystem.deadline) deadlineText.ChangeValue(roundSystem.deadline);
        if (scoreText.value != roundSystem.score) scoreText.ChangeValue(roundSystem.score);

    }


    public void AddDice(DiceBehaviour newDice)
    {
        DiceUI newDiceUI = Instantiate(diceUIprefab, diceUIs);
        newDiceUI.dice = newDice;
        newDice.diceui = newDiceUI;
        newDiceUI.uiSystem = this;
        diceUIList.Add(newDiceUI);
    }
    public void SpawnComboText(string c, string t,float col)
    {
        ComboText combo = Instantiate(comboText, diceUIs);
            combo.SetValues(c, t, col);
        combo.transform.localPosition = Random.insideUnitCircle * 300;
    }
}


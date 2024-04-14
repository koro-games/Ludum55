using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    public static RoundSystem instance;
    public int cRound=1;
    public int quota=300;
    public int deadline=4;
    public int maxdeadline=4;
    public int score=0;

    void Awake()
    {
        instance = this;
    }
    public void Reroll()
    {
        deadline--;
        UISystem.UI.UpdateScoreValues();
        UISystem.UI.rerollButton.interactable=false;
        DiceManager.diceManager.Throw();

    }
    IEnumerator CheckNextRound()
    {
        yield return new WaitForSeconds(1.6f);
        UISystem.UI.rerollButton.interactable = true;
        if (deadline <= 0)
        {
            if (score >= quota)
            {
                score -= quota;
                deadline = maxdeadline;
                cRound++;
                UISystem.UI.UpdateScoreValues();
                //NextRound
            }
            else
            {
                //lose
            }
        }
    }
    public void RollResult(int result)
    {
        
        score+= result;
        UISystem.UI.UpdateScoreValues();
        StartCoroutine(CheckNextRound());

    }
}

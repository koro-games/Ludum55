using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDice : MonoBehaviour
{
    public DiceBehaviour parentDice;
    public void CopyNearest()
    {
        List<DiceBehaviour> dices = DiceManager.diceManager.dices;
        float dist = 1000;
        DiceBehaviour dicetocopy = null;
        foreach (DiceBehaviour dice in dices)
        {
            if (dice != parentDice)
            {
                float d = Vector3.Distance(transform.position, dice.transform.position);
                if (d < dist)
                {
                    dist = d;
                    dicetocopy = dice;
                }
            }
        }
        if (dicetocopy != null)
        {
            parentDice.result = dicetocopy.result*2;
        }
        else parentDice.result = 0;
    }

}

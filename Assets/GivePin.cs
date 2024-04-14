using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePin : MonoBehaviour
{
    public DiceBehaviour parentDice;
    public void Trick()
    {
        if (parentDice.result==1)
        {
            parentDice.result=1;
            FindObjectOfType<PinSystem>().ChangePinCount(1);
        }
    }

}

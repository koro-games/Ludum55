using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopplerDice : MonoBehaviour
{
    public DiceBehaviour parentDice;
    public GameObject copy;
    public MeshRenderer mat;
    public void CopyNearest()
    {
        List<DiceBehaviour> dices = DiceManager.diceManager.dices;
        float dist = 1000;
        DiceBehaviour dicetocopy= null;
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
            parentDice.visual.SetActive(false);
            copy = Instantiate(dicetocopy.visual, transform);
            copy.transform.rotation = dicetocopy.visual.transform.rotation;
            mat.transform.rotation = copy.transform.rotation;
            copy.transform.position = transform.position;
            parentDice.result = dicetocopy.result;
        }
        else parentDice.result = 0;
    }
    public void ResetVisual()
    {
        Destroy(copy);
        parentDice.visual.SetActive(true);
        mat.transform.localRotation = Quaternion.identity;
    }
    void FixedUpdate()
    {
        mat.material.mainTextureOffset = Vector2.right * Random.value + Vector2.up * Random.value;
    }
}

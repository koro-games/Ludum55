using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class ChanceCalc : MonoBehaviour
{
    public int dicecount=5;
    public int sides=6;
    public int iterations=1000;
    public Comb[] combination;
    List<int> dices =new List<int>();
    int correct=0;
    int chance;

    void Start()
    {

        /*for (int a = 0; a < dicecount; a++)
            dices.Add(0);
        foreach (Comb comb in combination)
        {
            for (int a = 0; a < dicecount; a++)
                dices[a] = 0;
            for (int i = 0; i < iterations; i++)
            {
                for (int j = 0; j < dicecount; j++)
                {
                    dices[j] = Random.Range(1, sides + 1);
                }
                for (int c = 0; c < comb.combination.Length; c++)
                {
                    for (int d = 0; d < dicecount; d++)
                    {
                        if (dices[d] == comb.combination[c])
                        {
                            dices[d] = -1;
                            correct++;
                            break;
                        }
                    }
                }
                if (correct >= comb.combination.Length)
                    chance++;
                correct = 0;
            }
            string txt = "comb.";
            foreach (int z in comb.combination)
            txt +=z;

            Debug.Log(txt+"="+((float)chance / (float)iterations) * 100 + "%");
            chance = 0;
        }*/
    }
}
[System.Serializable]
public class Comb
{
    public int[] combination;
}

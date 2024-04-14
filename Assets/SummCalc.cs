using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.PostProcessing.HistogramMonitor;

public class SummCalc : MonoBehaviour
{
    public Combinations Combinations;
    public List<int> dice = new List<int>();
    int maxvalue = 6;
    public int iterations = 100;
    UISystem uiSystem;

    void Start()
    {
        uiSystem=FindObjectOfType<UISystem>();
        ResetDices();
    }

    void ResetDices()
    {
        for (int i = 0; i < dice.Count; i++)
        {
            dice[i] = Random.Range(1, maxvalue + 1);
        }
    }
    public void CheckCombinations(List<Vector2Int> results)
    {
        foreach (Combination comb in Combinations.combination)
        {
            int correct = 0;
            List<int> used = new List<int>();
            List<int> selected = new List<int>();
            

            foreach (Vector2Int sq in comb.sequence)
            {
                if (sq.x == 0)
                {

                    for (int r = 0; r < results.Count; r++)
                    {
                        if (!used.Contains(results[r].x) && results[r].y >= sq.y)
                        {
                            
                            correct++;
                            used.Add(results[r].x);
                            for (int c = 0;c< sq.y; c++) selected.Add(results[r].x);
                            break;
                        }
                    }
                }
                else if (sq.x > 0)
                {
                    for (int r = 0; r < results.Count; r++)
                    {
                        if (!used.Contains(results[r].x)&&results[r].x == sq.x && results[r].y >= sq.y)
                        {
                            
                            correct++;
                            used.Add(results[r].x);
                            break;
                        }
                    }
                }
                else if (sq.x < 0)
                {
                    for (int r = 0; r < results.Count; r++)
                    {
                        if (results[r].x == used[used.Count-1]-1 && results[r].y >= sq.y)
                        {

                            correct++;
                            used.Add(results[r].x);
                            break;
                        }
                    }
                }
            }
            if (correct >= comb.sequence.Length)
            {
                string txt = comb.name + " ";
                foreach (int sl in selected)
                {
                    txt += sl;
                }
                Debug.Log(txt);
            }
            /*//debug
            if (correct >= comb.sequence.Length)
            {
                //Combinations.combination[combin].score++;
                //Debug.Log(comb.name);
                
                string txt = comb.name + "(";
                foreach (Vector2Int sq in comb.sequence)
                {
                    for (int i = 0; i < sq.y; i++) txt += sq.x;
                }
                Debug.Log(txt + ") rew.$" + comb.score);
            }
            */
                //debug
        }

    }
}

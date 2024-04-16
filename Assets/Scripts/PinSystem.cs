using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSystem : MonoBehaviour
{
    public int pinscount=2;
    public int pinsavailable=2;
    public Image[] images;
    void Start()
    {
        ChangeUI();
    }
    public void UsePin(bool inuse)
    {
        if (inuse) pinscount--;
        else pinscount++;
        Mathf.Clamp(pinscount,0, pinsavailable);
        ChangeUI();
    }
    public void ChangeUI()
    {
        Color col = images[0].color;
        col.a = 1;
        Color acol = col;
        acol.a = 0.5f;
        for (int p = 0; p < images.Length; p++)
        {

            images[p].gameObject.SetActive(p < pinsavailable);
            images[p].color = p < pinscount ? col : acol;
        }
    }
    public void ChangePinCount(int i)
    {
        pinsavailable = Mathf.Clamp(pinsavailable+i,0, images.Length);
        ChangeUI();
    }
}

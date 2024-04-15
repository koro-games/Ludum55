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
        for (int p = 0; p < images.Length; p++)
        {
            if (p < pinsavailable) images[p].gameObject.SetActive(true);
            else images[p].gameObject.SetActive(false);
        }

    }
    public void UsePin(bool inuse)
    {
        if (inuse) pinscount--;
        else pinscount++;
        Mathf.Clamp(pinscount,0, pinsavailable);
        for (int p = 0; p < pinsavailable; p++)
        {
            Color col = images[p].color;
            if (p < pinscount) 
            { 
                col.a = 1;
                images[p].color = col;
            }
            else
            {
                col.a = 0.5f;
                images[p].color = col;
            }
        }
    }
    // Update is called once per frame
    public void ChangePinCount(int i)
    {
        pinsavailable = Mathf.Clamp(pinsavailable+i,0, images.Length);

            for (int p=0;p< images.Length; p++)
            {
                if (p<pinsavailable) images[p].gameObject.SetActive(true);
                else images[p].gameObject.SetActive(false);
            }
        
    }
}

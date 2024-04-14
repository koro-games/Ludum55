using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSystem : MonoBehaviour
{
    public int pinscount;
    public int pinsavailable;
    public Image[] images;
    void Start()
    {
        
    }

    // Update is called once per frame
    void ChangePinCount(int i)
    {
        pinsavailable = Mathf.Clamp(pinsavailable+i,0, images.Length);

            for (int p=0;p< pinsavailable; p++)
            {
                images[p].enabled = true;
            }
        
    }
}

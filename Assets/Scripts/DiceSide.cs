using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
        public int value;
        [HideInInspector] public SpriteRenderer sr;
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }
}

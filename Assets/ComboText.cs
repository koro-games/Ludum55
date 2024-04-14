using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboText : MonoBehaviour
{
    public TMP_Text combo;
    public TMP_Text reward;
    public Gradient color;
    void Start()
    {
        Destroy(gameObject, 3);
    }

    public void SetValues(string c, string t,float col)
    {
        combo.text = c;
        reward.text = t;
        combo.color = color.Evaluate( col);
    }
}

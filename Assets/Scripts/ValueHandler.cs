using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValueHandler : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public float value;
    [SerializeField] string format= "${0}";
    [SerializeField] string plusformat= "+$";
    [SerializeField] string minformat= "-$";
    [SerializeField] Image panel;
    Color startcolor;
    Color textstartcolor;
    [SerializeField] Color pluscolor; 
    [SerializeField] Color minuscolor; 
    public void ChangeValue(float newvalue)
    {
        if (value <= newvalue)
        {
            value = newvalue;
            text.text = string.Format(format, Mathf.Abs(value));
           // StartCoroutine(Animation());
        }
        else
        {
            value = newvalue;
            text.text = string.Format(format, Mathf.Abs(value));
        }
    }
    IEnumerator Animation(string div)
    {
        float t = 0;
        float maxt = 0.5f;
        Color targetcolor = pluscolor;
        if (value < 0) targetcolor = minuscolor;
        while (t < maxt)
        {
           if (t< 0.5f*maxt) text.transform.localScale = Vector3.one * (1-t*2 / maxt);
           else text.transform.localScale = Vector3.one * (t*2 / maxt-1);

            if (targetcolor == null) panel.color=Color.Lerp(startcolor, targetcolor, t/ maxt);
            t+=Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(maxt);
        t = 0;
        while (t < maxt)
        {
            if (t < 0.5f * maxt) text.transform.localScale = Vector3.one * (1 - t * 2 / maxt);
            else text.transform.localScale = Vector3.one * (t * 2 / maxt - 1);

            panel.color = Color.Lerp(targetcolor, startcolor, t / maxt);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }

}

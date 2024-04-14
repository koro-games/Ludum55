using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceUI : MonoBehaviour
{
    public DiceBehaviour dice;
    public UISystem uiSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var position = Camera.main.WorldToScreenPoint(dice.transform.position);
        position.z = 1;
        transform.position = Camera.main.ScreenToWorldPoint(position);
        transform.localPosition = Vector3.up * transform.localPosition.y + Vector3.right * transform.localPosition.x;
        /*var position = Camera.main.ScreenToWorldPoint(dice.transform.position);
        position.z = 1;
        transform.position = Camera.main.WorldToScreenPoint(position);*/

    }

}

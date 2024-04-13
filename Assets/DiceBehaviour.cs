using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceBehaviour : MonoBehaviour
{
    public float hitforce=10;
    public TMP_Text text;
    public DiceSide[] sides;
    public int result;
    public bool stat;
    Vector3 lastpos;
    Rigidbody rb;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Cube") collision.rigidbody.AddForce(hitforce * (collision.transform.position - transform.position).normalized);
    }

    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    public void ResetCube()
    {
        transform.position =
            Vector3.up * (Random.value * 2 +9) + (Random.value * 2 - 1) * Vector3.right + (Random.value * 2 - 1) * Vector3.forward;
        transform.rotation= Random.rotation;
        stat = false;
        result = 0;
        rb.isKinematic = false;
        rb.velocity= Vector3.zero;
    }
    public void SendResult()
    {
        
        int upper = 0;
        for (int i = 1; i < sides.Length; i++)
        {
            if (sides[i].transform.position.y > sides[upper].transform.position.y) upper = i;
        }
        result = sides[upper].value;
        text.text = "$" + sides[upper].value;
        DiceManager.diceManager.CheckResult(result);
    }
    void Update()
    {
        text.transform.position = transform.position+Vector3.up;
        text.transform.LookAt(Camera.main.transform.position);
        if (!stat && rb.velocity.magnitude<0.1f) 
        {
            stat = true;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            SendResult();
        }
    }
}

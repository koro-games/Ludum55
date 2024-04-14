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
    public DiceUI diceui;
    Vector3 lastpos;
    Rigidbody rb;
    public Animation Nail;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Cube") rb.AddForce(hitforce * (-collision.transform.position + transform.position).normalized);
    }

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        UISystem.UI.AddDice(this);
        
    }

    public void ResetCube()
    {
        if (!Nail.gameObject.activeSelf)
        {
            transform.position =
                Vector3.up * (Random.value * 2 + 9) + (Random.value * 2 - 1) * Vector3.right + (Random.value * 2 - 1) * Vector3.forward;
            transform.rotation = Random.rotation;
            stat = false;
            result = 0;
            rb.isKinematic = false;
            rb.velocity = Random.onUnitSphere;
        }
        else
        {
            Nail.Stop();
            Nail.Play("Nailed");
            DiceManager.diceManager.CheckResult(result);
        }
    }
    private void OnMouseDown()
    {
        Debug.Log(gameObject.name+ " pinned: "+ Nail.gameObject.activeSelf);
        if (stat)
        {
            if (!Nail.gameObject.activeSelf)
                PinDice();
            else
            {
                StartCoroutine(UnPinDice());
            }
        }
    }

    public void PinDice()
    {
        Nail.transform.rotation = Quaternion.identity;
        Nail.gameObject.SetActive(true);
        Nail.Stop();
        Nail.Play("Nail");
    }    

   
    IEnumerator UnPinDice()
    {
        Nail.Stop();
        Nail.Play("UnNail");
        Nail.transform.rotation = Quaternion.identity;
        yield return new WaitForSeconds(1);
        Nail.gameObject.SetActive(false);
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
        diceui.AddReward(result);
    }
    IEnumerator ToKinematic()
    {
        yield return new WaitForSeconds(0.5f);
        if (stat)
        rb.isKinematic = true;
    }
    void Update()
    {
        text.transform.position = transform.position+Vector3.up;
        text.transform.LookAt(Camera.main.transform.position);
        if (!stat && rb.velocity.magnitude<0.1f&& rb.angularVelocity.magnitude<0.1f) 
        {
            stat = true;
            StartCoroutine(ToKinematic());
            rb.velocity = Vector3.zero;
            SendResult();
        }

    }
}

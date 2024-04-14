using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DiceBehaviour : MonoBehaviour
{
    public UnityEvent OnSpawn;
    public UnityEvent OnRoll;
    public UnityEvent trick;
    public GameObject visual;
    public float hitforce=10;
    public TMP_Text text;
    public DiceSide[] sides;
    public int result;
    public bool stat;
    public bool pinnable=true;
    public bool triggerlast=false;
    public DiceUI diceui;
    Vector3 lastpos;
    Rigidbody rb;
    public Animation Nail;
    public AudioPlayer heavy;
    public AudioPlayer light;
    public AudioPlayer nailaudio;
    PinSystem pinSystem;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            rb.AddForce(hitforce * (-collision.transform.position + transform.position).normalized);
            light.Play();
        }
        else heavy.Play();
    }

    void Start()
    {
        pinSystem=FindObjectOfType<PinSystem>();
        rb = GetComponent<Rigidbody>();
        OnSpawn.Invoke();
        rb.velocity=Vector3.up* 20;
        rb.AddTorque(Random.insideUnitCircle * 100);
    }
    public void StartEvent()
    {
        UISystem.UI.AddDice(this);
        DiceManager.diceManager.dices.Add(this);
    }

    public void ResetCube()
    {
        OnRoll.Invoke();
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
            AskManager();
        }
    }
    private void OnMouseDown()
    {
        if (rb.isKinematic)
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
        if (pinnable&& pinSystem.pinscount>0)
        {
            pinSystem.UsePin(true);
            Nail.transform.rotation = Quaternion.identity;
            Nail.gameObject.SetActive(true);
            Nail.Stop();
            Nail.Play("Nail");
            nailaudio.Play(0);
        }

    }


    IEnumerator UnPinDice()
    {
        pinSystem.UsePin(false);
        Nail.Stop();
        Nail.Play("UnNail");
        Nail.transform.rotation = Quaternion.identity;
        nailaudio.Play(1);
        yield return new WaitForSeconds(1);
        Nail.gameObject.SetActive(false);
    }
    public void GetHighest()
    {
        int upper = 0;
        for (int i = 1; i < sides.Length; i++)
        {
            if (sides[i].transform.position.y > sides[upper].transform.position.y) upper = i;
        }
        result = sides[upper].value;
    }
    public void SendResult()
    {
        DiceManager.diceManager.CheckResult(result);
        diceui.AddReward(result);
    }
    public void AskManager()
    {
        if (triggerlast)
        {
            DiceManager.diceManager.lastdices.Add(this);
            DiceManager.diceManager.results.Add(0);
        }
        else trick.Invoke();
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
            AskManager();
            
        }

    }
}

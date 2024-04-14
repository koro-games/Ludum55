using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDice : MonoBehaviour
{
    public DiceBehaviour[] dices;
    public GameObject hole;
    public Material floor;
    public Gradient fcolor;
    public AudioSource holeaudio;
    private void Start()
    {
        floor.color = fcolor.Evaluate(0);
    }
    public void Spawn(GameObject obj)
    {
        StartCoroutine(SpawnC(obj));
    }

    IEnumerator SpawnC(GameObject obj)
    {
        hole.SetActive(true);
        hole.transform.localScale = Vector3.zero;
        while (hole.transform.localScale.x < 1) 
        {
            floor.color = fcolor.Evaluate(hole.transform.localScale.x);
            holeaudio.volume= hole.transform.localScale.x/2;
            hole.transform.localScale += Time.deltaTime*0.5f * Vector3.one;
            yield return new WaitForEndOfFrame();
        }
        hole.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(1f);
        Instantiate(obj, GameObject.Find("<Dices>").transform);
        while (hole.transform.localScale.x > 0)
        {
            floor.color = fcolor.Evaluate(hole.transform.localScale.x);
            holeaudio.volume = hole.transform.localScale.x / 2;
            hole.transform.localScale -= Time.deltaTime * Vector3.one;
            yield return new WaitForEndOfFrame();
        }
        floor.color = fcolor.Evaluate(0);
        hole.transform.localScale = Vector3.zero ;
        hole.SetActive(false);
    }

}

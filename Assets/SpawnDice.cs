using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDice : MonoBehaviour
{
    public DiceBehaviour[] dices;
    public GameObject hole;
    public AudioSource holeaudio;
    public void Spawn(GameObject obj)
    {
        StartCoroutine(SpawnC(obj));
    }

    IEnumerator SpawnC(GameObject obj)
    {
        hole.SetActive(true);
      
        while (hole.transform.localScale.x < 1) 
        {
            holeaudio.volume= hole.transform.localScale.x/2;
            hole.transform.localScale += Time.deltaTime * 2 * Vector3.one;
            yield return new WaitForEndOfFrame();
        }
        hole.transform.localScale = Vector3.one;
        Instantiate(obj, GameObject.Find("<Dices>").transform);
        yield return new WaitForSeconds(0.2f);
        while (hole.transform.localScale.x > 1)
        {
            holeaudio.volume = hole.transform.localScale.x / 2;
            hole.transform.localScale -= Time.deltaTime * 3 * Vector3.one;
            yield return new WaitForEndOfFrame();
        }
        hole.transform.localScale = Vector3.zero ;
        hole.SetActive(false);
    }

}

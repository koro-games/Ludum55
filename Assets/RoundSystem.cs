using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundSystem : MonoBehaviour
{
    public static RoundSystem instance;
    public int cRound=1;
    public int maxRound=10;
    public int quota=300;
    public int deadline=4;
    public int maxdeadline=4;
    public int score=0;

    public GameObject loseMenu;
    public GameObject winMenu;
    public AudioSource music;
    private void Update()
    {
        if (loseMenu.activeSelf)
        {
            music.pitch = Mathf.Lerp(music.pitch, 0.2f, Time.deltaTime*0.2f);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Link(string link)
    {
        Application.OpenURL(link);
    }
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ShopSystem.instance.AddItem(2);
    }
    public void Reroll()
    {
        deadline--;
        UISystem.UI.UpdateScoreValues();
        UISystem.UI.rerollButton.interactable=false;
        DiceManager.diceManager.Throw();
    }
    IEnumerator CheckNextRound()
    {
        yield return new WaitForSeconds(1.6f);
        UISystem.UI.rerollButton.interactable = true;
        if (deadline <= 0)
        {
            if (score >= quota)
            {
                score -= quota;
                deadline = maxdeadline;
                ShopSystem.instance.AddItem(Mathf.Clamp(cRound,1,3));
                cRound++;
                quota = (int)Mathf.Pow(2f,cRound) * 100;
                UISystem.UI.UpdateScoreValues();
                if (cRound==maxRound)
                {
                    winMenu.SetActive(true);
                }
                //NextRound
            }
            else
            {
                loseMenu.SetActive(true);
            }
        }
    }
    public void RollResult(int result)
    {
        
        score+= result;
        UISystem.UI.UpdateScoreValues();
        StartCoroutine(CheckNextRound());

    }
}

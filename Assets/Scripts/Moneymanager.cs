using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Moneymanager : MonoBehaviour
{

    public Text moneytext;
    public int money;

    public ScoreManager sb;

    public Timer tm;
    public GameObject GetSkill;
    private void Start()
    {
        money += 50;
        moneytext.text = "" + money + "$";
        sb = FindObjectOfType<ScoreManager>();
        tm = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        moneytext.text = "" + money + "$";
    }
    public void DealerMike() 
    {
        sb.IncreaseScore(50);
        money -= 50;
    }

    public void ReadBook() 
    {
        GetSkill.SetActive(true);
        sb.IncreaseScore(-20);
        tm.AddTime(3600f);
    }

    //Events that Increase/Decrease the amount of Money
}

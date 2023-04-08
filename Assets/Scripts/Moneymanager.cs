using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Moneymanager : MonoBehaviour
{

    public Text moneytext;
    public int money;
    private void Start()
    {
        moneytext.text = "" + money + "$";
    }

    //Events that Increase/Decrease the amount of Money
}

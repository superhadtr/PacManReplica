using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    public static int coin=0;
    public static int specialCoin = 0;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = coin.ToString();
    }
}

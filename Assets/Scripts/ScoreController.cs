using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text enemyCount;
    public Text coinCount;

    private void Update()
    {
        enemyCount.text = GameState.enemyKilledCount.ToString();
        coinCount.text = GameState.coinsCount.ToString();
    }
}

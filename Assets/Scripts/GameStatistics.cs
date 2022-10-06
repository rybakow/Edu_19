using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatistics : MonoBehaviour
{
    public Text totalEmenyCount;
    public Text totalCoinsGotted;

    private void Awake()
    {
        totalEmenyCount.text = GameState.enemyKilledCount.ToString();
        totalCoinsGotted.text = GameState.coinsCount.ToString();
    }
}

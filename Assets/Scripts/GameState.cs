using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int enemyKilledCount;
    public static int coinsCount;

    public static int totalLevelsInGame = 3;

    public static void SetDefault()
    {
        enemyKilledCount = 0;
        coinsCount = 0;
    }
}

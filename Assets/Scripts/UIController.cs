using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text levelNameText;

    private void Awake()
    {
        int levelN = SceneManager.GetActiveScene().buildIndex + 1;
        levelNameText.text = "Уровень " + levelN;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _coinText, _livesText;

    public void UpdateCoinDisplay(int coins)
    {
        _coinText.text = "x" + coins.ToString("00");
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives x" + lives.ToString();

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void UpdateScore(float val)
    {
        scoreText.text = "Time: " + Mathf.Floor(val / 60) + ":" + ((val % 60) < 10 ? "0" : "") + Mathf.Floor((val % 60));
    }
    public void EndGame(bool victory)
    {
        gameObject.SetActive(false);
    }
}
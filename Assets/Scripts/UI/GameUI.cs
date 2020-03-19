using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    protected Text labelScores;

    [SerializeField]
    protected string strScores = "Scores";

    private void Awake()
    {
        GameScores.OnScoresChanged += OnScoresChanged;
        UpdateUI();
    }
    private void OnDestroy()
    {
        GameScores.OnScoresChanged -= OnScoresChanged;
    }

    private void OnScoresChanged(int scores)
    {
        UpdateUI();
    }


    private void UpdateUI()
    {
        labelScores.text = string.Format("{0}: {1}", strScores, GameScores.Scores);
    }
}

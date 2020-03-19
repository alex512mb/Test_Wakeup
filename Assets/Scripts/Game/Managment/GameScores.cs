using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameScores
{
    private static int scores;

    public static int Scores
    {
        get => scores;
        set
        {
            if (scores != value)
            {
                scores = value;
                OnScoresChanged?.Invoke(value);
            }
        }
    }

    public static event Action<int> OnScoresChanged;
}

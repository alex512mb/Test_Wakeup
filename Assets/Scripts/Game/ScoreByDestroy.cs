using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreByDestroy : MonoBehaviour
{
    [SerializeField]
    protected int scores =1;


    private void OnDestroy()
    {
        GameScores.Scores += scores;
    }
}

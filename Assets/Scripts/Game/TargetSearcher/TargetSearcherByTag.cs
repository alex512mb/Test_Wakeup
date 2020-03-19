using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSearcherByTag : TargetSearcherBase
{
    [SerializeField]
    protected string targetTag = "Enemy";

    protected override GameObject[] FindGameObjects()
    {
        return GameObject.FindGameObjectsWithTag(targetTag);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightChecker : MonoBehaviour
{
    [SerializeField]
    protected LayerMask maskObstacle;


    public bool IsTargetOnSight(GameObject target)
    {
        if (target == null)
            return false;
        return !Physics.Linecast(transform.position, target.transform.position, maskObstacle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineOfSightChecker))]
public abstract class MoveTaskBase : MonoBehaviour
{
    [SerializeField]
    protected float distanceMove = 1;

    protected LineOfSightChecker sightChecker;



    protected virtual void Awake()
    {
        sightChecker = GetComponent<LineOfSightChecker>();
    }
    public virtual IEnumerator MovingToBetterPosition(GameObject target)
    {
        Vector3 startMovePos = transform.position;
        float movedDistance = 0;
        StartMoving(target);
        while (true)
        {
            yield return null;
            if (sightChecker.IsTargetOnSight(target) || movedDistance >= distanceMove)
            {
                StopMoving();
                break;
            }
            movedDistance = Vector3.Distance(startMovePos, transform.position);
        }
    }
    protected abstract void StartMoving(GameObject target);
    protected abstract void StopMoving();
}

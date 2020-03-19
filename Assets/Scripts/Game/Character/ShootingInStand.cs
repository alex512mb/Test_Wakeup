using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotateToTarget))]
[RequireComponent(typeof(Gun))]
[RequireComponent(typeof(MovingStateNotifier))]
[RequireComponent(typeof(LineOfSightChecker))]
public class ShootingInStand : MonoBehaviour
{
    private TargetSearcherBase targetSearcher;
    private RotateToTarget rotateToTarget;
    private Gun gun;
    private MovingStateNotifier movingStateNotifier;
    private LineOfSightChecker sightChecker;



    private void Awake()
    {
        targetSearcher = GetComponent<TargetSearcherBase>();
        rotateToTarget = GetComponent<RotateToTarget>();
        gun = GetComponent<Gun>();
        movingStateNotifier = GetComponent<MovingStateNotifier>();
        sightChecker = GetComponent<LineOfSightChecker>();


        movingStateNotifier.OnMovingStateChanged += OnMovingStateChanged;
    }

    private void OnMovingStateChanged(bool isMoving)
    {
        if (isMoving)
        {
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(AttackEnemyLoop());
        }
    }


    private IEnumerator AttackEnemyLoop()
    {
        GameObject target = null;
        while (true)
        {
            target = targetSearcher.Find();
            if (target != null)
            {
                rotateToTarget.target = target.transform;
                yield return rotateToTarget.Rotate();
                if (sightChecker.IsTargetOnSight(target))
                {
                    yield return gun.Shoting();
                }
            }

            yield return null;
        }



    }
}

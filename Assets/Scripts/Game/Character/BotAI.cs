using System.Collections;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(LineOfSightChecker))]
public class BotAI : MonoBehaviour
{
    [SerializeField]
    protected float durationShooting = 2;


    private TargetSearcherBase targetSearcher;
    private LineOfSightChecker sightChecker;
    private MoveTaskBase moveTask;

    private GameObject target;


    private void Awake()
    {
        sightChecker = GetComponent<LineOfSightChecker>();
        moveTask = GetComponent<MoveTaskBase>();
        targetSearcher = GetComponent<TargetSearcherBase>();
    }
    private IEnumerator Start()
    {
        while (true)
        {
            target = targetSearcher.Find();
            if (target != null)
            {
                if (!sightChecker.IsTargetOnSight(target))
                {
                    yield return moveTask.MovingToBetterPosition(target);
                }
                yield return new WaitForSeconds(durationShooting);
            }
            yield return null;
        }
    }

}

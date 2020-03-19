using System.Collections;
using UnityEngine;

public class MoveTaskFree : MoveTaskBase
{
    [SerializeField]
    protected float speed = 3;
    [SerializeField]
    protected bool freez_x;
    [SerializeField]
    protected bool freez_y;
    [SerializeField]
    protected bool freez_z;
    private Vector3 startPosition;

    protected override void Awake()
    {
        base.Awake();
        startPosition = transform.position;
    }

    protected override void StartMoving(GameObject target)
    {
        StartCoroutine(ProgrammMoving(target));
    }

    protected override void StopMoving()
    {
        StopAllCoroutines();
    }

    private IEnumerator ProgrammMoving(GameObject target)
    {
        while (target != null)
        {
            Vector3 directionToTarget = target.transform.position - transform.position;

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position , speed * Time.deltaTime);

            ApplyFreezes();

            yield return null;
        }
    }

    private void ApplyFreezes()
    {
        if (freez_x)
        {
            transform.position = new Vector3(startPosition.x, transform.position.y, transform.position.z);
        }

        if (freez_y)
        {
            transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
        }

        if (freez_z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, startPosition.z);
        }
    }
}

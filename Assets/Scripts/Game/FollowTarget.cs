using System.Collections;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    protected TargetSearcherBase searcherTarget;
    [SerializeField]
    protected float speed;

    private GameObject target;

    private IEnumerator Start()
    {
        while (target == null)
        {
            yield return null;
            target = searcherTarget.Find();
        }
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        }
    }
}

using System.Collections;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [HideInInspector]
    public Transform target;


    [SerializeField]
    protected float stoppingAngle = 5;
    [SerializeField]
    private float angularSpeed = 100;


    public IEnumerator Rotate()
    {
        if (target != null)
        {
            float angle = GetAngleToTarget();
            while (angle > stoppingAngle && target != null)
            {
                Vector3 directionToTarget = GetDirectionToTarget();
                float step = angularSpeed * Time.deltaTime;
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
                angle = GetAngleToTarget();
                yield return null;

            }
        }
    }


    private float GetAngleToTarget()
    {
        Vector3 directionToTarget = GetDirectionToTarget();
        float angle = Vector3.Angle(transform.forward, directionToTarget);
        return angle;
    }
    private Vector3 GetDirectionToTarget()
    {
        return target.position - transform.position;
    }
}

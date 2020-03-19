using System;
using UnityEngine;

public class MovingStateNotifier : MonoBehaviour
{
    private Vector3 previousPos;

    bool isMoving;
    bool IsMoving
    {
        get => isMoving;
        set
        {
            if (isMoving != value)
            {
                OnMovingStateChanged?.Invoke(value);
                isMoving = value;
            }
        }
    }


    public event Action<bool> OnMovingStateChanged;


    private void Update()
    {
        IsMoving = transform.position != previousPos;
        previousPos = transform.position;
    }
}

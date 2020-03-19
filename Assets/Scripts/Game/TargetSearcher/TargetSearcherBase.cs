using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetSearcherBase : MonoBehaviour
{
    [SerializeField]
    protected float maxDistance = float.MaxValue;
    protected abstract GameObject[] FindGameObjects();


    public GameObject Find()
    {
        GameObject[] foundObjects = FindGameObjects();

        GameObject nearestObject = FindNearestObject(foundObjects);

        return nearestObject;
    }

    private GameObject FindNearestObject(GameObject[] objects)
    {
        if (objects == null)
        {
            return null;
        }
        else
        {
            if (objects.Length == 0)
                return null;

            float minDistance = float.MaxValue;
            GameObject nearestObject = objects[0];
            for (int i = 0; i < objects.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, objects[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestObject = objects[i];
                }
            }
            return nearestObject;
        }
        
    }
}

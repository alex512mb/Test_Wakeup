using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToOut : MonoBehaviour
{
    [SerializeField]
    protected string playerTag = "Player";
    [SerializeField]
    protected string nextLevel = "level 0";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}

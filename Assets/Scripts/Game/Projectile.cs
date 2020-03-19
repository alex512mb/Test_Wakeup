using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float speed = 5;

    private void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}

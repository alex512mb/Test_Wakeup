using UnityEngine;

public class DamageImpact : MonoBehaviour
{
    public float damage;
    [SerializeField]
    protected bool destroyAfterApply = true;
    [SerializeField]
    protected bool isTrigger = false;



    private void OnTriggerEnter(Collider other)
    {
        if (isTrigger)
        {
            ApplyImpact(other.gameObject);
            TryDestroyMe();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!isTrigger)
        {
            ApplyImpact(collision.gameObject);
            TryDestroyMe();
        }

    }

    public void ApplyImpact(GameObject target)
    {
        HealthComponent healthComponent = target.GetComponent<HealthComponent>();
        if (healthComponent != null)
        {
            healthComponent.Health -= damage;
        }
    }
    private void TryDestroyMe()
    {
        if (destroyAfterApply)
        {
            Destroy(gameObject);
        }
    }
}

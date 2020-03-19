using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    protected float health = 100;
    public float Health
    {
        get => health;
        set
        {
            if (health > 0)
            {
                health = value;

                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    protected float shotPerSecond = 1;
    [SerializeField]
    protected float damage = 10;
    [SerializeField]
    protected GameObject prefabProjectile;
    [SerializeField]
    protected Transform shotPoint;


    private float deleyAimToShot;
    private Collider myCollider;



    private void Awake()
    {
        deleyAimToShot = 1f / shotPerSecond;
        if (shotPoint == null)
            shotPoint = transform;

        myCollider = GetComponentInChildren<Collider>();
    }


    public IEnumerator Shoting()
    {
        yield return new WaitForSeconds(deleyAimToShot);
        Shot();
    }


    private void Shot()
    {
        var projectile = Instantiate(prefabProjectile, shotPoint.position, shotPoint.rotation);
        var impact = projectile.GetComponent<DamageImpact>();
        impact.damage = damage;

        //to avoid hit by owner of gun add Physics ingore
        Collider projectileCollider = projectile.GetComponentInChildren<Collider>();
        Physics.IgnoreCollision(myCollider, projectileCollider, true);
    }
}

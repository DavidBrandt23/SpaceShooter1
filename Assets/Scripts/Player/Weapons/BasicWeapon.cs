using UnityEngine;
using System.Collections;

public class BasicWeapon : PeriodicWeapon
{

    public Transform shootOrigin;

    void Start()
    {
    }

    void FixedUpdate()
    {
        incrementCooldown(); 
    }

    public override void shootPressed()
    {
        if (offCooldown())
        {
            GameObject projectile = Instantiate(projectilePrefab, shootOrigin.position, shootOrigin.rotation);
            Vector2 shootDirection = new Vector2(0, -1);
            float projectileForceMagnitude = 2.0f;
            projectile.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * projectileForceMagnitude);
            playShootNoise();
            resetCooldown();
        }
    }
}

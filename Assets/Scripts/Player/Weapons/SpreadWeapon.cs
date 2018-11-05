using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpreadWeapon : PeriodicWeapon
{

    public List<Transform> shootOrigins;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
            createShot(shootOrigins[0], new Vector2(-0.4f, 1));
            createShot(shootOrigins[1], new Vector2(-0.2f, 1));
            createShot(shootOrigins[2], new Vector2(0, 1));
            createShot(shootOrigins[3], new Vector2(0.2f, 1));
            createShot(shootOrigins[4], new Vector2(0.4f, 1));
            playShootNoise();
            resetCooldown();
        }
    }
    private void createShot(Transform shootOrigin, Vector2 shootDirection)
    {
        GameObject projectile = Instantiate(projectilePrefab, shootOrigin.position, shootOrigin.rotation);
        projectile.GetComponent<MoveInLine>().direction = shootDirection.normalized;
        projectile.GetComponent<MoveInLine>().speed = 0.2f;
    }
}

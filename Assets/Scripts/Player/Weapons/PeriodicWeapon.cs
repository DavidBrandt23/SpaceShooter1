using UnityEngine;
using System.Collections;

public class PeriodicWeapon : PlayerWeapon
{

    public float cooldown;
    private float cooldownTimer;

    // Use this for initialization
    void Start()
    {
        cooldownTimer = 0;
    }
    

    protected bool offCooldown()
    {
        if (cooldownTimer <= 0)
        {
            return true;
        }
        return false;
    }

    protected void resetCooldown()
    {
        cooldownTimer = cooldown;
    }

    protected void incrementCooldown()
    {
        cooldownTimer -= (Time.fixedDeltaTime);
    }

    public override void shootPressed()
    {
        throw new System.NotImplementedException();
    }
}

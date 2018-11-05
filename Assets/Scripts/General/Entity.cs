using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour
{
    private Health health;
    protected void onStart()
    {
        health = this.GetComponent<Health>();
        health.SetDeathCallback(onDeath);
        health.SetHurtCallback(onHurt);
    }
    protected virtual void onDeath() { }
    protected virtual void onHurt() { flash(); }

    // Update is called once per frame
    void Update()
    {

    }

    private void flash()
    {
       // this.GetComponent<SpriteRenderer>().color = Color.red;
    }
}

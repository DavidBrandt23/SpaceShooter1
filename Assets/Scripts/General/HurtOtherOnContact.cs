using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOtherOnContact : MonoBehaviour
{
    [Tooltip("Damage done to other object on contact")]
    public float damage;
    [Tooltip("Only objects with this tag can be damaged")]
    public string hurtsObjectsWithTag;

    // Use this for initialization
    void Start()
    {
        //myCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //myCollider.
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Health otherHealthScript = other.gameObject.GetComponent<Health>();
        if (otherHealthScript != null && other.gameObject.tag == hurtsObjectsWithTag)
        {
            otherHealthScript.hurt(damage);
        }
    }
}

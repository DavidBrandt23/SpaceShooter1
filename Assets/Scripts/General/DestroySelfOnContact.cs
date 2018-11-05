using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfOnContact : MonoBehaviour
{
    public string[] tags; //if this object hits an object with one of these tags, it is destroyed
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < tags.Length; i++)
        {
            if (other.tag.Equals(tags[i]))
            {
                Destroy(this.gameObject);
            }
        }
    }
}

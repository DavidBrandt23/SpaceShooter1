using UnityEngine;
using System.Collections;

public class MovementScripts : MonoBehaviour
{
    Transform transform;
    // Use this for initialization
    void Start()
    {
        transform = this.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveInDirection(Vector2 direction, float speed = 0.2f)
    {
        transform.Translate(direction.normalized * speed);
    }
}

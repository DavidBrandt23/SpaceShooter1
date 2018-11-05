using UnityEngine;
using System.Collections;

public class MoveInLine : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public Vector2 direction;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Transform transform = this.GetComponent<Transform>();
        transform.Translate(direction.normalized * speed);
    }
}

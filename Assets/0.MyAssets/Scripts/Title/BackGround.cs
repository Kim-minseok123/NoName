using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform Left;
    public Transform Right;
    public float speed = .1f;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);

        if (transform.position.x < Left.position.x)
        {
            transform.position = new Vector2(Right.position.x, transform.position.y);
        }
    }
}

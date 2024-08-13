using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private float speed = 3;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}

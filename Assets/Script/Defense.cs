using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.CompareTag("Weapone"))
        {
            Destroy(other.gameObject, 0.8f);
        }
    }
}

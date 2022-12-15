using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryNote : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
            Destroy(collision.gameObject);
    }
}

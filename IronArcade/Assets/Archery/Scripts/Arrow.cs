using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Arrow : MonoBehaviour
{
    void Update()
    {
        //Destroy arrow 
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "target")
        {
            //Destroy arrow on hit
            Destroy(gameObject, 2f);

            // Freeze after hitting target
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    private Collider2D coll;
    private SpriteRenderer rd;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rd = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rd.enabled = true;
            coll.isTrigger = false;
        }
        
    }
}

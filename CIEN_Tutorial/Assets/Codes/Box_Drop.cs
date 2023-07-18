using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Drop : MonoBehaviour
{
    private GameObject box;
    private Collider2D coll;
    private Rigidbody2D rb;
    [SerializeField] private float dropSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        box = transform.parent.gameObject;
        rb = box.GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            box.tag = "Enemy";
            MoveDown();
        }
        
    }
    public void MoveDown()
    {
        rb.velocity = new Vector2(0, -1*dropSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Floor")//적에게 피격시
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameoverScene");
        }
    }

    void Update()
    {
        //방향키로 이동
        float h = Input.GetAxis("Horizontal");

        if (h < 0)
        {
            rb.velocity = new Vector2(-1 * maxSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if(h > 0)
        {
            rb.velocity = new Vector2( maxSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

    }
}

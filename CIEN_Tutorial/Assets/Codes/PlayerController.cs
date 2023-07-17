using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private bool IsDead = false;
    private enum State { idle,running,jumping,falling}
    private State state = State.idle;
    [SerializeField] private GameManager gm;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")//적에게 피격시
        {
            if(state == State.falling)
            {
                Jump();
                Destroy(collision.gameObject);
            }
            else
            {
                Death();
            
            }
            
        }
        else if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("IsDead", true);
            rb.velocity = new Vector2(0, 40);
            Invoke("Death", 0.5f);
    

        }
    }

    void Update()
    {
        //방향키로 이동
        float h = Input.GetAxis("Horizontal");
        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector2(rb.velocity.normalized.x * 0.5f, rb.velocity.y);
        }
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

        else
        {

            
        }

        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
        }

        VelocityState();
        anim.SetInteger("state", (int)state);

    }

    private void Jump()
    {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            state = State.jumping;
    }
    private void VelocityState()
    {
        if (state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }

    

    private void Death()
    {
        gm.health -= 1;
        rb.bodyType = RigidbodyType2D.Static;
        IsDead = true;
        anim.SetBool("IsDead", IsDead);
        Invoke("MoveScene", 2);
    }

    private void MoveScene()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameoverScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoEnemy : MonoBehaviour
{
    [Header ("변경 가능 속성")]
    [Tooltip ("왼쪽 이동 범위")]
    [SerializeField] private float leftCap;
    [Tooltip("오른쪽 이동 범위")]
    [SerializeField] private float rightCap;
    [Tooltip("점프 길이")]
    [SerializeField] private float jumpLength = 10f;
    [Tooltip("점프 높이")]
    [SerializeField] private float jumpHeight = 15f;

    [Space(10f)]
    [SerializeField] private LayerMask ground;

    private bool facingLeft = true;
    private Collider2D coll;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (facingLeft)
        {
            if(transform.position.x> leftCap)
            {

                if(transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                }
        }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {

                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
        
    }
}

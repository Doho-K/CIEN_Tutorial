using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearEnemyController : MonoBehaviour
{
    public float speed;
    public float distance;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //날 따라오게 함
        if (Mathf.Abs(transform.position.x - player.position.x) < distance)
        {
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
        }
        Direction();
    }

    void Direction()
    {
        //방향 전환
        if (transform.position.x - player.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}

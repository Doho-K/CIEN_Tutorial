using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlock : MonoBehaviour
{
    GameObject enemy;
    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.enemy = GameObject.Find("BearEnemy");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //아래에서 치면 적 생성
        if (other.contacts[0].normal.y > 0 && num == 0)
        {
            GameObject item = Instantiate(enemy);
            item.transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
            num++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

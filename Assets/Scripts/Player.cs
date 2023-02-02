using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject goTarget;
    public GameObject goGameOver;

    float speed = 1;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed; // 유령이 움직이는 방향을 위한 코드

        //collision.gameObject.SetActive(false);

        // 부딪힌게 내가 지정한게 맞냐 안맞냐

        if (collision.gameObject.name == goTarget.name)
        {
            //collision.gameObject.SetActive(false);
            //collision.gameObject.transform.Translate(5, 0, 0);

            
            goGameOver.SetActive(true);
            this.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

}

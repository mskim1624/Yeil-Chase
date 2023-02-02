using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    bool fCollision = false;
    float speed = 1;
    Rigidbody2D rigid;

    public GameObject goTarget;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(speed, 0);
    }

    private void FixedUpdate()
    {        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed;
        this.GetComponent<SpriteRenderer>().flipX = (speed < 0);

        //if (collision.gameObject.name == "LBlock")
        if (collision.gameObject.name == goTarget.name)
        {
            GameObject _goTarget = GameObject.Find(collision.gameObject.name);
            if (_goTarget != null)
            {
                _goTarget.SetActive(false);
            }

            //Time.timeScale = 0;
        }
        
    }

}

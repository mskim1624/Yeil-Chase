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
        speed = -speed; // ������ �����̴� ������ ���� �ڵ�

        //collision.gameObject.SetActive(false);

        // �ε����� ���� �����Ѱ� �³� �ȸ³�

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

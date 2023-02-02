using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 충돌하면 표시한다 
public class OnCollision_Show : MonoBehaviour
{
    public GameObject goTarget; // Player 오브젝트를 인스펙트에서 지정해준다.
    public GameObject goShowMsg; // GameOver 오브젝트를 인스펙트에서 지정해준다.

    void Start() 
    {
        goShowMsg.SetActive(false); // GameOver 이미지는 게임 시작시 나타나지 않는다.
    }

    void OnCollisionEnter2D(Collision2D collision)// 충돌했을 때
    { 
        // 만약 충돌한 것의 이르이 목표 오브젝트면 
        if (collision.gameObject.name == goTarget.name)
        {
            goShowMsg.SetActive(true);
        }
    }
}

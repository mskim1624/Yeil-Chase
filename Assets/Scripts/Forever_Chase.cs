using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 계속 뒤쫓아 간다
public class Forever_Chase : MonoBehaviour
{

    public GameObject goTarget;
    string targetObjectName; // 목표 오브젝트 이름 : Inspector에 지정
    public float speed = 1; // 속도：Inspector에 지정

    Rigidbody2D rbody;

    void Start()
    { // 처음에 시행한다
      // 목표 오브젝트를 찾아낸다

        if (goTarget == null)
        {
            Debug.LogError("쫒아갈 타겟 오브젝트를 찾을수 없습니다.");
            //targetObject = GameObject.Find("Player");
        }
        targetObjectName = goTarget.name;
        
        // 중력을 0으로 해서 충돌 시에 회전시키지 않는다
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    { // 계속 시행한다(일정 시간마다)
      // 목표 오브젝트의 방향을 조사해서
        Vector3 dir = (goTarget.transform.position - this.transform.position).normalized;
        // 그 방향에 지정한 양으로 나아간다
        float vx = dir.x * speed;
        float vy = dir.y * speed;
        rbody.velocity = new Vector2(vx, vy);
        // 이동 방향에서 왼쪽 오른쪽으로 방향을 바꾼다
        this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 속도 변수 선언
    public float speed;
    // target을 물리적으로 따라갈 것이기 때문에 Rigidbody2D 변수 선언
    public Rigidbody2D target;

    // 몬스터가 살아있는지 죽어있는지 구별해주는 변수 선언
    // 아직 테스트 상태이미로 미리 isLive = true 적용해주기
    bool isLive = true;

    // Rigidbody 2D를 위한 변수 선언
    Rigidbody2D rigid;
    // SpriteRenderer를 위한 변수 선언
    SpriteRenderer spriter;

    // Awake 함수에서 초기화 진행
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    // 물리적인 이동이기 때문에 FixedUpdate 함수 사용
    void FixedUpdate()
    {
        // 몬스터가 살아있는 동안에만 움직이도록 조건 추가
        if(!isLive)
            return;

        // 몬스터가 Player에게 가기 위한 위치는 벡터의 연산으로 쉽게 구할 수 있음
        // 위치 차이 = 타겟 위치 - 나의 위치
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        /* Vector2 nextVec의 설명
             1. 앞으로 가야할 다음 위치 지역변수로 만들기
             - 방향의 크기는 1이 아니기 때문에 Normalized 사용
             - 방향 = 위치 차이의 정규화 (Normalized)
             - 프레임의 영향으로 결과가 달라지지 않도록 FixedDeltaTime 사용

             2. nextVec의 의미
             - Player의 키입력 값을 더한 이동 = Enemy의 방향 값을 더한 이동
        */

        // 물리 속도가 이동에 영향을 주지 않도록 속도 제거
        rigid.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        // 목표의 X축 값과 자신의 X축 값을 비교하여 작으면 true가 되도록 설정
        spriter.flipX = target.position.x < rigid.position.x;
    }

    // OnEnable : 스크립트가 활성화 될 때, 호출되는 이벤트 함수
    void OnEnable()
    {
        // OnEnable에서 타겟 변수에 GameManager를 활용하여 player 할당
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}


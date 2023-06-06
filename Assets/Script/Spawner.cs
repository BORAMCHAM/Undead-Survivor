using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 자식 오브젝트의 트랜스폼을 담을 배열 변수 선언
    public Transform[] spawnPoint;

    // 소환 타이머를 위한 변수 선언
    float timer;

    /* 초기화 */
    void Awake()
    {
        // GetComponentsInChildren 함수로 초기화
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        // timer 변수에 deltaTime을 계속 더하기
        timer += Time.deltaTime;

        // timer가 일정 시간 값에 도달하면 소환하도록 작성
        if (timer > 0.2f)
        {
            timer = 0;
            Spawn();
        }

        /*
        // 테스트를 위해 Update 안에서 점프 버튼 입력 조건 추가
        if (Input.GetButtonDown("Jump"))
        {
            // GameManager의 인스턴스까지 접근하여 풀링의 함수 호출
            GameManager.instance.pool.Get(1);
        }
        */
    }

    /* 소환 함수 */
    void Spawn()
    {
        // GameManager의 인스턴스까지 접근하여 풀링의 함수 호출 (풀 함수에는 랜덤 인자 값을 넣도록 변경)
        // Instantiate 반환 값을 enemy 변수에 넣어두기
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));

        // 만들어둔 소환 위치(spawnPoint) 중 하나로 배치되도록 작성
        // 자식 오브젝트에서만 선택되도록 랜덤 시작은 1부터
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 자식 오브젝트의 트랜스폼을 담을 배열 변수 선언
    public Transform[] spawnPoint;
    // 만든 클래스를 그대로 타입으로 활용하여 배열 변수 선언
    public SpawnData[] spawnData;

    // 레벨 담당 변수 선언
    int level;
    // 소환 타이머를 위한 변수 선언
    float timer;

    /* 초기화 함수 */
    void Awake()
    {
        // GetComponentsInChildren 함수로 초기화
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    /* 업데이트 함수 */
    void Update()
    {
        // timer 변수에 deltaTime을 계속 더하기
        timer += Time.deltaTime;
        // 적절한 숫자로 나누어 시간에 맞춰 레벨이 올라가도록
        // FloorToInt : 소수점 아래는 버리고 Int형으로 바꾸는 함수
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);

        /*
        // timer가 일정 시간 값에 도달하면 소환하도록 작성
        if (timer > 0.2f)
        {
            timer = 0;
            Spawn();
        }
        */

        /*
        // 레벨을 활용해 소환 타이밍 변경하기
        if (timer > (level == 0 ? 0.5f : 0.2f))
        {
            timer = 0;
            Spawn();
        }
        */

        // 소환 시간 조건을 소환데이터로 변경
        if (timer > spawnData[level].spawnTime)
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
        /*
        // GameManager의 인스턴스까지 접근하여 풀링의 함수 호출 (풀 함수에는 랜덤 인자 값을 넣도록 변경)
        // Instantiate 반환 값을 enemy 변수에 넣어두기
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));
        */

        /*
        // 풀링에서 가져오는 함수에도 레벨 적용
        GameObject enemy = GameManager.instance.pool.Get(level);
        */

        // PoolManager에서 호출하는함수 인자 값을 0으로 변경
        GameObject enemy = GameManager.instance.pool.Get(0);

        // 만들어둔 소환 위치(spawnPoint) 중 하나로 배치되도록 작성
        // 자식 오브젝트에서만 선택되도록 랜덤 시작은 1부터
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        
        // 오브젝트 풀에서 가져온 오브젝트에서 Enemy 컴포넌트로 접근
        // 새롭게 작성한 함수(Init)를 호출하고 소환 데이터 인자값 전달
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

/* 소환 데이터를 담당하는 클래스 */
// System.Serializable 속성 부여 → 직렬화
[System.Serializable]
public class SpawnData
{
    // 추가할 속성 : 스프라이트 타입, 소환 시간, 체력, 속도
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}


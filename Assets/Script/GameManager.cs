using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* static
        - 정저으로 사용하겠다는 키워드 (바로 메모리에 얹어버림)
        - static으로 선언된 변수는 Inspector에 나타나지 않음
        - 정적(static) 변수는 즉시 클래스에서 부를 수 있다는 편리함이 있음
    */
    public static GameManager instance;

    // 게임 시간을 담당할 변수 선언
    public float gameTime;
    // 최대 게임 시간을 담당할 변수 선언 (예 : 5분 → 5 * 60f, 20초 → 2 * 10f)
    public float maxGameTime = 2 * 10f;

    // 다양한 곳에서 쉽게 접근할 수 있도록 GameManager에 PoolManager 추가
    public PoolManager pool;
    public Player player;   // Player 타입의 공개 변수 선언

    /* 초기화 함수 */
    void Awake()
    {
        // Awake 생명주기에서 Instance 변수를 자기자신 this로 초기화
        instance = this;
    }

    void Update()
    {
        // Update에서 deltaTime 더하기
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}


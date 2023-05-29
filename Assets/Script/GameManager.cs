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
    public Player player;   // Player 타입의 공개 변수 선언

    void Awake()
    {
        // Awake 생명주기에서 Instance 변수를 자기자신 this로 초기화
        instance = this;
    }
}
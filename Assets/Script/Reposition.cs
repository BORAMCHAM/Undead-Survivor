using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    // Collider2D 변수 생성 및 초기화
    Collider2D coll;

    void Awake()
    {
        // Collider2D는 기본 도형의 모든 콜라이더2D를 포함
        coll = GetComponent<Collider2D>();
    }

    // OnTriggerExit2D : Trigger와 체크된 Collider에서 나갔을 때 발생하는 함수
    void OnTriggerExit2D(Collider2D collision)
    {
        // OnTriggerExit2D의 매개변수(collision)과 상대방 Collider의 Tag를 조건으로
        if (!collision.CompareTag("Area"))
            // return 키워드를 만나면 더 이상 실행하지 않고 함수 탈출
            return;

        // 거리를 구하기 위해 Player 위치와 Tilemap 위치를 미리 저장
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        // Player 위치 - Tilemap 위치 계산으로 거리 구하기
        // Mathf.Abs : 음수도 양수로 만들어주는 절대값 함수
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        // Player의 이동 방향을 저장하기 위한 변수 추가
        Vector3 playerDir = GameManager.instance.player.inputVec;

        // 대각선일 때는 Normalized에 의해 1보다 작은 값이 되어버림
        // 3항 연산자 : (조건) ? (true일 때 값) : (false일 때 값)
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        // switch - case : 값의 산태에 따라 로직을 나눠주는 키워드
        switch (transform.tag)
        {
            case "Ground":
                // 두 Object의 거리 차이에서 X축이 Y축보다 크면 수평 이동
                if (diffX > diffY)
                {
                    // Translate : 지정된 값 만큼 현재 위치에서 이동
                    transform.Translate(Vector3.right * dirX * 40);
                }

                // 두 Object의 거리 차이에서 X축이 Y축보다 작으면 수직 이동
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }

                break;

            case "Enemy":
                // 콜라이더가 활성화 되어있는지 조건 먼저 작성
                if(coll.enabled)
                {
                    // Player의 이동 방향에 따라 맞은 편에서 등장하도록 이동
                    // 랜덤한 위치에서 등장하도록 벡터 더하기
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }
                break;
        }
    }
}


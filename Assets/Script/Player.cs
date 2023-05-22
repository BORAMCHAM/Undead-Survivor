using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBeHaviour : 게임 로직 구성에 필요한 것들을 가진 클래스
public class Player : MonoBehaviour 
{
    /* 변수 이름은 데이터가 지닌 의미를 파악할 수 있도록 짓기 */
    public Vector2 inputVec;    // 입력 값을 저장할 변수 선언
    public float speed;     // 속도를 편리하게 관리하는 float 변수

    Rigidbody2D rigid;  // GameObject의  Rigidbody 2D를 저장할 변수 선언

    // Awake : 시작할 때 한번만 실행되는 생명주기 함수 (초기화 하는 함수)
    void Awake()
    {
        // GetComponent<T> : GameObject에서 Component를 가져오는 함수 → T자리에는 Component 이름 작성
        rigid = GetComponent<Rigidbody2D>();    // rigid 변수에 Player에 있는 Component 중 Rigidbody 2D 저장
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update : 하나의 프레임마다 한 번씩 호출되는 생명주기 함수
    void Update()
    {
        // Input ; 유니티에서 받는 모든 입력을 관리하는 클래스
        // Input.GetAxis : 입력 값이 부드럽게 바뀜
        // Input.GetAxisRaw : 더욱 명확한 컨트롤 구현 가능
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        /*
        Edit > Project Settinigs > Input Manager 에서 버튼 이름 확인
        Input Manager : 물리적인 입력을 지정된 버튼으로 연결하는 역할
      */
    }

    // FixedUpdate : 물리 연산 프레임마다 호출되는 생명주기 함수
    void FixedUpdate()
    {
        /*
        - 물리이동 첫번째 : 힘을 준다 ( = AddForce)
        rigid.AddForce(inputVec);   // 방향 크기를 줌

        - 물리이동 두번째 : 속도를 직접 제어한다 ( = Velocity)
        rigid.velocity = inputVec;  // Velocity : 물리적인 속도를 의미

        - 물리이동 세번째 : 위치를 옮긴다 ( = MovePosition)
        rigid.MovePosition(rigid.position + inputVec);
        */

        // 다른 프레임 환경에도 이동거리는 같아야 함
        // normalized : 벡터 값의 크기가 1이 되도록 좌표가 수정된 값
        // fixedDeltaTime : 물리 프레임 하나가 소비하는 시간
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        // 물리이동 중 위치이동
        // MovePosition은 위치이동이라 현재 위치(rigid.position)도 더해주어야 함
        // 위에서 계산된 변수(nextVec)를 MovePosition에 사용
        rigid.MovePosition(rigid.position + nextVec);  
    }
}
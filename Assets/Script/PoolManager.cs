using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    /* 프리펩들을 보관할 변수 */
    // 프리펩들을 저장할 배열 변수 선언
    public GameObject[] prefabs;

    /* 풀 담당을 하는 리스트 */
    // 오브젝트 풀들을 저장할 배열 변수 선언
    List<GameObject>[] pools;

    /* 초기화 함수 Awake */
    void Awake()
    {
        /* 풀을 담는 배열 초기화 */
        // 리스트 배열 변수 초기화할 때 크기는 프리펩 배열 길이 활용
        pools = new List<GameObject>[prefabs.Length];

        /* 반복문을 통해 모든 오브젝트 풀 리스트를 초기화 */
        // for(반복문) : 시작문; 조건문; 중감문
        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }

        // Debug.Log(pools.Length);
    }

    /* 게임오브젝트를 반환하는 함수 선언 */
    // 가져올 오브젝트 종류를 결정하는 매개변수 int index 추가
    // 게임오브젝트 지역변수와 리턴을 미리 작성
    public GameObject Get(int index)
    {        
        GameObject select = null;

        /* 선택한 풀의 놀고 있는(비활성화 된) 게임오브젝트 접근*/
        // foreach : 배열, 리스트들의 데이터를 순차적으로 접근하는 반복문
        foreach (GameObject item in pools[index])
        {
            // 내용물 오브젝트가 비활성화(대기 상태)인지 확인
            if (!item.activeSelf)
            {
                // 발견하면 select 변수에 할당
                select = item;
                // 비활성화(대기 상태) 오브젝트를 찾으면 SetActive 함수로 활성화
                select.SetActive(true);
                // 반복문 종료
                break;
            }
        }

        // 못 찾았으면?
        // 미리 선언한 변수가 계속 비어있으면 생성 로직으로 진입
        if (!select)
        {
            // 새롭게 생성하고 select 변수에 할당
            // Instantiate : 원본 오브젝트를 복제하여 장면에 생성하는 함수
            select = Instantiate(prefabs[index], transform);
            // 생성된 오브젝트는 해당 오브젝트 풀 리스트에 Add 함수로 추가
            pools[index].Add(select);
        }

        return select;
    }
}


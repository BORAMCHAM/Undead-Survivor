using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* static
        - �������� ����ϰڴٴ� Ű���� (�ٷ� �޸𸮿� ������)
        - static���� ����� ������ Inspector�� ��Ÿ���� ����
        - ����(static) ������ ��� Ŭ�������� �θ� �� �ִٴ� ������ ����
    */
    public static GameManager instance;
    public Player player;   // Player Ÿ���� ���� ���� ����

    void Awake()
    {
        // Awake �����ֱ⿡�� Instance ������ �ڱ��ڽ� this�� �ʱ�ȭ
        instance = this;
    }
}
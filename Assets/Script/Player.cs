using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBeHaviour : ���� ���� ������ �ʿ��� �͵��� ���� Ŭ����
public class Player : MonoBehaviour 
{
    /* ���� �̸��� �����Ͱ� ���� �ǹ̸� �ľ��� �� �ֵ��� ���� */
    public Vector2 inputVec;    // �Է� ���� ������ ���� ����
    public float speed;     // �ӵ��� ���ϰ� �����ϴ� float ����

    Rigidbody2D rigid;  // GameObject��  Rigidbody 2D�� ������ ���� ����

    // Awake : ������ �� �ѹ��� ����Ǵ� �����ֱ� �Լ� (�ʱ�ȭ �ϴ� �Լ�)
    void Awake()
    {
        // GetComponent<T> : GameObject���� Component�� �������� �Լ� �� T�ڸ����� Component �̸� �ۼ�
        rigid = GetComponent<Rigidbody2D>();    // rigid ������ Player�� �ִ� Component �� Rigidbody 2D ����
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update : �ϳ��� �����Ӹ��� �� ���� ȣ��Ǵ� �����ֱ� �Լ�
    void Update()
    {
        // Input ; ����Ƽ���� �޴� ��� �Է��� �����ϴ� Ŭ����
        // Input.GetAxis : �Է� ���� �ε巴�� �ٲ�
        // Input.GetAxisRaw : ���� ��Ȯ�� ��Ʈ�� ���� ����
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        /*
        Edit > Project Settinigs > Input Manager ���� ��ư �̸� Ȯ��
        Input Manager : �������� �Է��� ������ ��ư���� �����ϴ� ����
      */
    }

    // FixedUpdate : ���� ���� �����Ӹ��� ȣ��Ǵ� �����ֱ� �Լ�
    void FixedUpdate()
    {
        /*
        - �����̵� ù��° : ���� �ش� ( = AddForce)
        rigid.AddForce(inputVec);   // ���� ũ�⸦ ��

        - �����̵� �ι�° : �ӵ��� ���� �����Ѵ� ( = Velocity)
        rigid.velocity = inputVec;  // Velocity : �������� �ӵ��� �ǹ�

        - �����̵� ����° : ��ġ�� �ű�� ( = MovePosition)
        rigid.MovePosition(rigid.position + inputVec);
        */

        // �ٸ� ������ ȯ�濡�� �̵��Ÿ��� ���ƾ� ��
        // normalized : ���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ������ ��
        // fixedDeltaTime : ���� ������ �ϳ��� �Һ��ϴ� �ð�
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        // �����̵� �� ��ġ�̵�
        // MovePosition�� ��ġ�̵��̶� ���� ��ġ(rigid.position)�� �����־�� ��
        // ������ ���� ����(nextVec)�� MovePosition�� ���
        rigid.MovePosition(rigid.position + nextVec);  
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// MonoBeHaviour : ���� ���� ������ �ʿ��� �͵��� ���� Ŭ����
public class Player : MonoBehaviour 
{
    /* ���� �̸��� �����Ͱ� ���� �ǹ̸� �ľ��� �� �ֵ��� ���� */
    public Vector2 inputVec;    // �Է� ���� ������ ���� ����
    public float speed;     // �ӵ��� ���ϰ� �����ϴ� float ����

    Rigidbody2D rigid;  // GameObject��  Rigidbody 2D�� ������ ���� ����
    SpriteRenderer spriter;  // SpriteRenderer ���� ����
    Animator anim;  // Animator ���� ����

    // Awake : ������ �� �ѹ��� ����Ǵ� �����ֱ� �Լ� (������ ������ �ʱ�ȭ �ϴ� ��)
    void Awake()
    {
        // GetComponent<T> : GameObject���� Component�� �������� �Լ� �� T�ڸ����� Component �̸� �ۼ�
        rigid = GetComponent<Rigidbody2D>();    // rigid ������ Player�� �ִ� Component �� Rigidbody 2D ����
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;

        // �����̵� �� ��ġ�̵�
        // MovePosition�� ��ġ�̵��̶� ���� ��ġ(rigid.position)�� �����־�� ��
        // ������ ���� ����(nextVec)�� MovePosition�� ���
        rigid.MovePosition(rigid.position + nextVec);  
    }

    void OnMove(InputValue value)
    {
        // Get<T> : �����ʿ��� ������ ��Ʈ�� Ÿ�� T���� �������� �Լ�
        inputVec = value.Get<Vector2>();
    }

    // LateUpdate : �������� ���� �Ǳ� �� ����Ǵ� �����ֱ� �Լ�
    void LateUpdate()
    {
        // �ִϸ����Ϳ��� ������ �Ķ���� Ÿ�԰� ������ �Լ� �ۼ�
        // SetFloat ù��° ���� : �Ķ���� �̸�, SetFloat �ι�° ���� : �ݿ��� float ��
        anim.SetFloat("Speed", inputVec.magnitude);  // Magnitude : ������ ������ ũ�� ��

        // if : ������ true�� ��, �ڽ��� �ڵ带 �����ϴ� Ű����
        if (inputVec.x != 0)    // != : '���ʰ� �������� ���� �ٸ��ϱ�?' �ǹ��� �� ������
        {
            // if�� �ȿ� flipX �Ӽ� �ٲٱ�
            spriter.flipX = inputVec.x < 0;    // �� �������� ����� �ٷ� ���� �� ����
        }
    }
}
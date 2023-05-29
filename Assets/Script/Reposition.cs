using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    // OnTriggerExit2D : Trigger�� üũ�� Collider���� ������ �� �߻��ϴ� �Լ�
    void OnTriggerExit2D(Collider2D collision)
    {
        // OnTriggerExit2D�� �Ű�����(collision)�� ���� Collider�� Tag�� ��������
        if (!collision.CompareTag("Area"))
            // return Ű���带 ������ �� �̻� �������� �ʰ� �Լ� Ż��
            return;

        // �Ÿ��� ���ϱ� ���� Player ��ġ�� Tilemap ��ġ�� �̸� ����
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        // Player ��ġ - Tilemap ��ġ ������� �Ÿ� ���ϱ�
        // Mathf.Abs : ������ ����� ������ִ� ���밪 �Լ�
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        // Player�� �̵� ������ �����ϱ� ���� ���� �߰�
        Vector3 playerDir = GameManager.instance.player.inputVec;

        // �밢���� ���� Normalized�� ���� 1���� ���� ���� �Ǿ����
        // 3�� ������ : (����) ? (true�� �� ��) : (false�� �� ��)
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.x < 0 ? -1 : 1;

        // switch - case : ���� ���¿� ���� ������ �����ִ� Ű����
        switch (transform.tag)
        {
            case "Ground":
                // �� Object�� �Ÿ� ���̿��� X���� Y�ຸ�� ũ�� ���� �̵�
                if (diffX > diffY)
                {
                    // Translate : ������ �� ��ŭ ���� ��ġ���� �̵�
                    transform.Translate(Vector3.right * dirX * 40);
                }

                // �� Object�� �Ÿ� ���̿��� X���� Y�ຸ�� ������ ���� �̵�
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }

                break;

            case "Enemy":

                break;
        }
    }
}
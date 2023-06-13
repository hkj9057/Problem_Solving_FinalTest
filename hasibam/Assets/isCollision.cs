using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCollision : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform ������Ʈ
    public Transform enemy; // ���� Transform ������Ʈ
    public Vector2 playerSize; // �÷��̾��� ũ��
    public Vector2 enemySize; // ���� ũ��

    private void Start()
    {
        // �÷��̾�� ���� ũ�� ��������
        playerSize = GetObjectSize(player);
        enemySize = GetObjectSize(enemy);
    }
    private Vector2 GetObjectSize(Transform obj)
    {
        // ��ü�� ũ�⸦ �������� �Լ�
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.bounds.size;
        }else
        {
            Debug.LogWarning("Object renderer not found!");
            return Vector2.zero;
        }
    }
    public bool CheckCollision(Vector2 positionA, Vector2 sizeA, Vector2 positionB, Vector2 sizeB)
    {
        // AABB �浹 ���� �Լ�
        float halfWidthA = sizeA.x / 3f;
        float halfHeightA = sizeA.y / 3f;
        float halfWidthB = sizeB.x / 3f;
        float halfHeightB = sizeB.y / 3f;

        float leftA = positionA.x - halfWidthA;
        float rightA = positionA.x + halfWidthA;
        float topA = positionA.y + halfHeightA;
        float bottomA = positionA.y - halfHeightA;

        float leftB = positionB.x - halfWidthB;
        float rightB = positionB.x + halfWidthB;
        float topB = positionB.y + halfHeightB;
        float bottomB = positionB.y - halfHeightB;

        return leftA <= rightB && rightA >= leftB && bottomA <= topB && topA >= bottomB;
    }
}
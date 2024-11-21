using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public class RotationLink
{
    // ȸ���� üũ�� transform
    public Transform linkedTransform;

    // ��ũ Ȱ��ȭ�� ���� ���Ϸ� ����
    public Vector3 activeEulerAngle;
    [Header("Path to Link")]
    public Walkable pathA;
    public Walkable pathB;
}

public class Linker : MonoBehaviour
{
    [SerializeField] public RotationLink[] rotationLinks;

    // �̿��ϴ� ť�� ���� path�� active ���¸� toggle
    public void EnableLink(Walkable pathA, Walkable pathB, bool state)
    {
        if (pathA == null || pathB == null)
            return;

        pathA.EnablePath(pathB, state);
        pathB.EnablePath(pathA, state);
    }

    // ���Ϸ� ������ ���� enable/disable
    public void UpdateRotationLinks()
    {
        foreach (RotationLink l in rotationLinks)
        {
            if (l.linkedTransform == null || l.pathA == null || l.pathB == null)
                continue;

            // ���ϴ� ������ ���� ������ ���̸� ����
            Quaternion targetAngle = Quaternion.Euler(l.activeEulerAngle);
            float angleDiff = Quaternion.Angle(l.linkedTransform.rotation, targetAngle);

            // ������ ��ġ�ϸ� ��ũ�� Ȱ��ȭ, �ƴ϶�� ��Ȱ��ȭ
            if (Mathf.Abs(angleDiff) < 0.01f)
            {
                EnableLink(l.pathA, l.pathB, true);
            }
            else
            {
                EnableLink(l.pathA, l.pathB, false);
            }
        }
    }

    // update links
    private void Update()
    {
        UpdateRotationLinks();
    }
}

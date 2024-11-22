using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public class RotationLink
{
    // 회전을 체크할 transform
    public Transform linkedTransform;

    // 링크 활성화를 위한 오일러 각도
    public Vector3 activeEulerAngle;
    [Header("Path to Link")]
    public Walkable pathA;
    public Walkable pathB;
}

public class Linker : MonoBehaviour
{
    [SerializeField] public RotationLink[] rotationLinks;

    // 이웃하는 큐브 사이 path의 active 상태를 toggle
    public void EnableLink(Walkable pathA, Walkable pathB, bool state)
    {
        if (pathA == null || pathB == null)
            return;

        pathA.EnablePath(pathB, state);
        pathB.EnablePath(pathA, state);
    }

    // 오일러 각도에 따라 enable/disable
    public void UpdateRotationLinks()
    {
        foreach (RotationLink l in rotationLinks)
        {
            if (l.linkedTransform == null || l.pathA == null || l.pathB == null)
                continue;

            // 원하는 각도와 현재 각도의 차이를 구함
            Quaternion targetAngle = Quaternion.Euler(l.activeEulerAngle);
            float angleDiff = Quaternion.Angle(l.linkedTransform.rotation, targetAngle);

            // 각도가 일치하면 링크를 활성화, 아니라면 비활성화
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

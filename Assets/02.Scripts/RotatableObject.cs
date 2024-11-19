using UnityEngine;

public class RotatableObject : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private bool isSelected = false; // 현재 오브젝트가 선택되었는지 여부

    void Update()
    {
        // 마우스 클릭 시 Raycast로 선택된 오브젝트 확인
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // 클릭된 오브젝트가 자신인지 확인
                isSelected = hit.transform == transform;
            }
        }

        // 마우스 버튼이 떼어지면 선택 해제
        if (Input.GetMouseButtonUp(0))
        {
            isSelected = false;
        }

        // 선택된 오브젝트만 회전
        if (isSelected && Input.GetMouseButton(0))
        {
            float rotationX = -Input.GetAxis("Mouse Y") * speed;
            transform.Rotate(rotationX, 0f, 0f, Space.Self);

            // Y축과 Z축 회전 고정
            Vector3 currentEulerAngles = transform.eulerAngles;
            transform.eulerAngles = new Vector3(currentEulerAngles.x, 0f, 0f);
        }
    }
}

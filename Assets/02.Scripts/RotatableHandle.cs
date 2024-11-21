using UnityEngine;

public class RotatableHandle : MonoBehaviour
{
    [SerializeField] private Transform block; 
    [SerializeField] private float rotationSpeed = 5f; 
    private bool isDragging = false; 
    private Vector3 dragStartPoint; 
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // 마우스 클릭으로 드래그 시작
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOverObject())
            {
                isDragging = true;
                dragStartPoint = Input.mousePosition; // 드래그 시작 지점 설정
            }
        }

        // 마우스 버튼 떼면 드래그 종료
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;

            SnapToNearest90Degrees();
        }

        // 드래그 중일 때 회전 처리
        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;

            // 중심 좌표
            Vector3 objectScreenPosition = mainCamera.WorldToScreenPoint(transform.position);

            // 시작 각도와 현재 각도
            float startAngle = Mathf.Atan2(dragStartPoint.y - objectScreenPosition.y, dragStartPoint.x - objectScreenPosition.x) * Mathf.Rad2Deg;
            float currentAngle = Mathf.Atan2(currentMousePosition.y - objectScreenPosition.y, currentMousePosition.x - objectScreenPosition.x) * Mathf.Rad2Deg;

            // 각도 변화량
            float angleDifference = -Mathf.DeltaAngle(startAngle, currentAngle);

            // X축 회전에 반영
            RotateHandleAndBlock(angleDifference * rotationSpeed * Time.deltaTime);

            // 드래그 시작 위치 갱신
            dragStartPoint = currentMousePosition;
        }
    }

    // 손잡이와 블록을 X축 기준으로 회전
    private void RotateHandleAndBlock(float rotationAmount)
    {
        // 손잡이 회전 (Transform)
        float newXRotation = transform.localEulerAngles.x + rotationAmount;

        transform.localEulerAngles = new Vector3(newXRotation, 0f, 90f);

        // 블록 회전 (Transform)
        if (block != null)
        {
            block.localEulerAngles = new Vector3(newXRotation, block.localEulerAngles.y, block.localEulerAngles.z);
        }
    }

    // 가장 가까운 90°로 스냅
    private void SnapToNearest90Degrees()
    {
        float currentXRotation = transform.localEulerAngles.x;

        // 가장 가까운 90° 배수로 스냅
        float snappedRotation = Mathf.Round(currentXRotation / 90f) * 90f;

        transform.localEulerAngles = new Vector3(snappedRotation, 0f, 90f);

        if (block != null)
        {
            block.localEulerAngles = new Vector3(snappedRotation, block.localEulerAngles.y, block.localEulerAngles.z);
        }
    }

    // 마우스가 오브젝트 위에 있는지 확인
    private bool IsMouseOverObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform == transform;
        }
        return false;
    }
}

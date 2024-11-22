using DG.Tweening;
using UnityEngine;

public class RotatableHandle : MonoBehaviour
{
    [SerializeField] private Transform block;
    private Camera mainCamera;
    private bool isRotating;
    private float rotX = 0f;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // 마우스 클릭으로 회전
        if (Input.GetMouseButtonDown(0))
        {
            if (isRotating)
            {
                return;
            }

            if (IsMouseOverObject())
            {
                isRotating = true;
                block.DORotate(new Vector3(90, 0, 0), 1, RotateMode.WorldAxisAdd).OnComplete(() => { isRotating = false; });
            }
        }
    }
    
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Camera mainCamera;
    private Vector3 targetPosition;
    private bool isMoving;


    private void Awake()
    {
        mainCamera = Camera.main;
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving) MoveToPoint();
    }
    
    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("마우스 클릭 이벤트");

            // Vector2 position = context.ReadValue<Vector2>();
            Vector2 position = Mouse.current.position.ReadValue();

            Ray ray = mainCamera.ScreenPointToRay(position);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPosition = hit.point;
                isMoving = true;
            }
        }
    }

    private void MoveToPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }
}

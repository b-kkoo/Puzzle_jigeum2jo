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

    private Animator animator;


    private void Awake()
    {
        mainCamera = Camera.main;
        targetPosition = transform.position;
    }
    private void Start() 
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("IsWalking", false);

        if (isMoving) 
        {
            MoveToPoint();
            RotateToTarget();
            animator.SetBool("IsWalking", true);
        }
    }
    
    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 screenPosition = Mouse.current.position.ReadValue();
            // Debug.Log(position);

            Ray ray = mainCamera.ScreenPointToRay(screenPosition);
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

    private void RotateToTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            // 목표 방향으로 회전 후 180도 추가 회전
            Quaternion targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0f, 180f, 0f);

            transform.rotation = targetRotation;
        }
    }
}

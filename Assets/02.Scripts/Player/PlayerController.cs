using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private Animator animator;

    public bool isMoving;

    public Transform currentCube;
    public Transform clickedCube;

    public List<Transform> finalPath = new List<Transform>();

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Start() 
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("IsWalking", false);

        RayCastDown();

        if (isMoving) 
        {
            animator.SetBool("IsWalking", true);
        }
    }

    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition); RaycastHit mouseHit;

            if (Physics.Raycast(mouseRay, out mouseHit))
            {
                if (mouseHit.transform.GetComponent<Walkable>() != null)
                {
                    clickedCube = mouseHit.transform;
                    finalPath.Clear();
                    GameManager.instance.Player.pathfinder.FindPath();
                }
            }
        }
    }

    public void RayCastDown()
    {

        Ray playerRay = new Ray(transform.GetChild(0).position + (Vector3.one * 0.1f), -transform.up);
        RaycastHit playerHit;

        if (Physics.Raycast(playerRay, out playerHit))
        {
            if (playerHit.transform.GetComponent<Walkable>() != null)
            {
                currentCube = playerHit.transform;
            }
        }
    }
}

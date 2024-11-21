using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCube : MonoBehaviour
{
    [SerializeField] private bool gameOverOnTrigger;
    [SerializeField] private bool gameClearOnTrigger;
    [SerializeField] private GameObject iCube;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameClearOnTrigger)
            {
                GameManager.instance.GameClear();
            }

            if (gameOverOnTrigger)
            {
                GameManager.instance.Player.controller.animator.SetBool("Death", true);

                StartCoroutine(CorDelaySetUI());
            }
        }
    }

    IEnumerator CorDelaySetUI()
    {
        yield return new WaitForSeconds(2.5f);
        GameManager.instance.GameOver();
    }
}

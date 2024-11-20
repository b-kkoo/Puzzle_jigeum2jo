using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public Pathfinder pathfinder;

    private void Start()
    {
        GameManager.instance.Player = this;
        controller = GetComponent<PlayerController>();
        pathfinder = GetComponent<Pathfinder>();
    }
}

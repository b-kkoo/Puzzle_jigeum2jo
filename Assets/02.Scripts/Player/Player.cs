using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public Pathfinder pathfinder;

    private void Awake()
    {
        GameManager.instance.Player = this;
        controller = GetComponent<PlayerController>();
        pathfinder = GetComponent<Pathfinder>();
    }
}

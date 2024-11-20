using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    [SerializeField] private GameObject bridge;
    [SerializeField] private int linkedAngle;

    public List<GameObject> linkedObject = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < linkedObject.Count; i++)
        {
            linkedObject[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckBridgeAngle();
    }

    void CheckBridgeAngle()
    {
        if (bridge.transform.rotation.x == linkedAngle)
        {
            for (int i = 0; i < linkedObject.Count; i++)
            {
                linkedObject[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < linkedObject.Count; i++)
            {
                linkedObject[i].SetActive(false);
            }
        }
    }
}

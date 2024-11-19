using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private UIManager uiManager;
    public UIManager UIManager { get; set; }
    
    private SoundManager soundManager;
    public SoundManager SoundManager { get; set; }

    //[SerializeField] private GameObject uIManagerPrefab;
    [SerializeField] private GameObject soundManagerPrefab;
    void Awake()
    {
        // 싱글톤 유지: 기존 인스턴스가 없으면 생성해주고, 스크립트를 추가해준다.
        if (instance == null )
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 삭제되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //uiManager = GetComponentInChildren<UIManager>();
        // if (uiManager == null)
        // {
        //     GameObject uiManagerObject = Instantiate(uIManagerPrefab);
        //     uiManagerObject.transform.SetParent(transform); // GameManager의 자식으로 설정
        //     uiManager = uiManagerObject.GetComponent<UIManager>();
        // }

        soundManager = GetComponentInChildren<SoundManager>();
        if (soundManager == null)
        {
            GameObject soundManagerObject = Instantiate(soundManagerPrefab);
            soundManagerObject.transform.SetParent(transform); // GameManager의 자식으로 설정
            soundManager = soundManagerObject.GetComponent<SoundManager>();
        }
    }
}

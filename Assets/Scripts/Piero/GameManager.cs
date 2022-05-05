using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [Header("Components")]
    [SerializeField] private PlayerController2 _playerController;
    [SerializeField] private Camera _camera;
    [SerializeField] private UIManager _uiManager;



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        if (_instance != this)
        {
            _instance = this;
        }
    }

    public static GameManager GetInstance
    {
        get { return _instance; }
    }
    public PlayerController2 GetPlayerController
    {
        get { return _playerController; }
    }

    public UIManager GetUIManager
    {
        get { return _uiManager; }
    }
    public Camera GetCamera
    {
        get { return _camera; }
    }
}

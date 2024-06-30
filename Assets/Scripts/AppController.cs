using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class AppController : MonoBehaviour
{
    public List<Config> configs;

    [SerializeField] InputManager inputManager;
    [SerializeField] TextMeshProUGUI pauseText;
    [SerializeField] GameObject pauseMenu;

    private bool _paused = true;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        foreach (var config in configs) { config.Init(); }

        inputManager.Throw += ClickAnyKey;
        inputManager.Jump += ClickAnyKey;

        inputManager.Escape += Pause;

        inputManager.Throw += FirstClick;
        inputManager.Jump += FirstClick;
        inputManager.Escape += FirstClick;

        Time.timeScale = 0.01f;
    }

    private void ClickAnyKey()
    {
        if (!_paused) return;
        Pause();
    }

    private void FirstClick()
    {
        inputManager.Throw -= FirstClick;
        inputManager.Jump -= FirstClick;
        inputManager.Escape -= FirstClick;

        pauseText.text = "PAUSED";
    }

    private void Pause()
    {
        _paused = !_paused;
        if (_paused)
        {
            Time.timeScale = 0.01f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        pauseMenu.SetActive(_paused);
    }
}

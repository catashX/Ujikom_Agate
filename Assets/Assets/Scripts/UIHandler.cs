using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public enum GameState
    {
        paused,
        played
    }
    [SerializeField] GameState _state;
    [SerializeField] GameObject _pausePanel;
    [SerializeField] bool isPauseMenu;
    private void Start()
    {
        changeState(GameState.played);
    }
    private void Update()
    {
        if (isPauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                switchState();
            }
        }
    }

    public void switchState()
    {
        if(_state == GameState.paused) { changeState(GameState.played); _pausePanel.SetActive(false); }
        else if(_state == GameState.played) { changeState(GameState.paused); _pausePanel.SetActive(true); }
    }

    public void ChangeSceneByName(string _name)
    {
        SceneManager.LoadScene(_name);
    }

    public void changeState(GameState state)
    {
        if(_state != state)
        {
            _state = state;
            if (state == GameState.paused) Time.timeScale = 0f;
            else Time.timeScale = 1f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] Camera GOCam;
    [SerializeField] GameStateData _data;
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _clip;
    bool isGameOver;
    private void Start()
    {
        _data.setScore(0);
        _data.setTime(60);
    }

    private void Update()
    {
        if (!isGameOver)
        {
            float currentTime = _data.getTime() - Time.deltaTime;
            _data.setTime(currentTime);
            if (_data.getTime() <= 0) GameOver();
        }
    }

    public void addScore(int _value)
    {
        _data.setScore(_data.getScore() + _value);
    }

    void GameOver()
    {
        _source.PlayOneShot(_clip);
        mainCam.enabled = false;
        GOCam.enabled = true;
        isGameOver = true;
        FindObjectOfType<PlayerHandler>().GameOver();
        FindObjectOfType<UIHandler>().GameOver();
        FindObjectOfType<SpawnerScript>().GameOver();     
    }
}

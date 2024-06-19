using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    [SerializeField] GameStateData _data;
    private void Start()
    {
        _data.setScore(0);
        _data.setTime(60);
    }

    private void Update()
    {
        float currentTime = _data.getTime() - Time.deltaTime;
        _data.setTime(currentTime);
    }

    public void addScore(int _value)
    {
        _data.setScore(_data.getScore() + _value);
    }
}

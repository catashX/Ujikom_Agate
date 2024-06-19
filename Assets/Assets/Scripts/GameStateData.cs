using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameStateData")]
public class GameStateData : ScriptableObject
{
    [SerializeField] int _score;
    [SerializeField] float _time;
    public int getScore()
    {
        return _score;
    }
    public float getTime()
    {
        return _time;
    }
    public void setScore(int _val)
    {
        _score = _val;
    }
    public void setTime(float _val)
    {
        _time = _val;
    }
}

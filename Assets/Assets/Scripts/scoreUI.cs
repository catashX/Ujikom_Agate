using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] GameStateData _data;
    private void Update()
    {
        _scoreText.text = "Score : " + _data.getScore().ToString();
        _timeText.text = "Time : " + Mathf.FloorToInt(_data.getTime());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] float interval;
    [SerializeField] Transform[] placement;
    [SerializeField] GameObject[] enemy;
    float time;
    private void Update()
    {
        if (time < interval) time += Time.deltaTime;
        else
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], placement[Random.Range(0,placement.Length)].transform.position,Quaternion.identity);
            time = 0;
        }
    }
}

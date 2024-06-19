using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    [SerializeField] float _projectileSpeed;
    [SerializeField] float _lifeTime;
    float _tickingTime;
    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,_projectileSpeed);
        _tickingTime = _lifeTime;
    }
    private void Update()
    {
        if (_tickingTime > 0) _tickingTime -= Time.deltaTime;
        else killProjectile();
    }
    void killProjectile()
    {
        Destroy(gameObject);
    }
}

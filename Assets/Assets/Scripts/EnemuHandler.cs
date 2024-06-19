using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemuHandler : MonoBehaviour
{
    [SerializeField] Transform _BarCanvas;
    [SerializeField] GameObject _Bar;
    [SerializeField] AudioClip _hitSFX;
    [SerializeField] AudioSource _hitSource;
    [SerializeField] float _speed;
    [SerializeField] float _HP;
    [SerializeField] int _score;
    scoreManager _manager;
    HPBarManager _barManager;
    float currentHP;
    GameObject thisHPBar;
    private void Start()
    {
        thisHPBar = Instantiate(_Bar, _BarCanvas);
        _barManager = thisHPBar.GetComponent<HPBarManager>();
        _barManager.set(this.transform);
        _BarCanvas = GameObject.FindGameObjectWithTag("placementBar").transform;
        _manager = FindObjectOfType<scoreManager>();
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * _speed);
        currentHP = 0;
    }

    public void Hit()
    {
        currentHP += 25;
        if(currentHP >= _HP) kill();
        _barManager.setScale(Mathf.Clamp(currentHP/_HP,0,1));
        _hitSource.PlayOneShot(_hitSFX);
    }

    void kill()
    {
        _manager.addScore(_score);
        Destroy(thisHPBar);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemuHandler : MonoBehaviour
{
    [SerializeField] Transform _BarCanvas;
    [SerializeField] GameObject _Bar;
    [SerializeField] float _speed;
    [SerializeField] float _HP;
    HPBarManager _barManager;
    float currentHP;
    GameObject thisHPBar;
    private void Start()
    {
        thisHPBar = Instantiate(_Bar, _BarCanvas);
        _barManager = thisHPBar.GetComponent<HPBarManager>();
        _barManager.set(this.transform);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * _speed);
        currentHP = _HP;
    }

    public void Hit()
    {
        currentHP += 25;
        if(currentHP >= _HP) kill();
        _barManager.setScale(Mathf.Clamp(currentHP/_HP,0,1));
    }

    void kill()
    {
        Destroy(thisHPBar);
        Destroy(gameObject);
    }
}

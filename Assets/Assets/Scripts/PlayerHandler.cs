using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] float striveSpeed;
    [SerializeField] Animator _anim;
    bool isMoving;
    Rigidbody _rb;
    float _input;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) Throw();
        _input = Input.GetAxisRaw("Horizontal");
        //isMoving = (_input == 0);
        _anim.SetBool("Moving", true);
        _anim.SetFloat("Dir", _input);
    }
    private void FixedUpdate()
    {
        move();
    }
    public void move()
    {
        _rb.velocity = new Vector3(_input * striveSpeed, 0, 0);
    }
    public void Throw()
    {
        _anim.SetTrigger("Throw");
    }
}

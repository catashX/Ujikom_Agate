using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] float striveSpeed;
    [SerializeField] Animator _anim;
    [Header("Shooting")]
    [SerializeField] GameObject _food;
    [SerializeField] GameObject _shooter;
    [SerializeField] AudioClip _shootAudio;
    [SerializeField] bool canMove;
    bool isMoving;
    Rigidbody _rb;
    float _input;
    private void Start()
    {
        canMove = true;
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) Throw();
            _input = Input.GetAxisRaw("Horizontal");
            //isMoving = (_input == 0);
            _anim.SetBool("Moving", true);
            _anim.SetFloat("Dir", _input);
        }
    }
    private void FixedUpdate()
    {
        move();
    }
    public void move()
    {
        if (!canMove) return;
        _rb.velocity = new Vector3(_input * striveSpeed, 0, 0);
    }
    public void Throw()
    {
        var projectile = Instantiate(_food,_shooter.transform.position, Quaternion.identity);
        _shooter.GetComponent<AudioSource>().PlayOneShot(_shootAudio);
        _anim.SetTrigger("Throw");
    }
    public void GameOver()
    {
        _anim.SetTrigger("GameOver");
        canMove = false;
    }
}

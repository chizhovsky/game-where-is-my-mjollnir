using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private Animator _animator;
    private float _speed;
    private float _jumpForce;
    private bool _isJumping;
    private float _moveHorizontal;
    private float _moveVertical;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _speed = 1.5f;
        _jumpForce = 35f;
        _isJumping = false;
    }

    private void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (_moveHorizontal != 0)
        {
            _animator.SetFloat("xVelocity", Math.Abs(_rb2D.linearVelocity.x));
            _rb2D.AddForce(new Vector2(_moveHorizontal * _speed, 0), ForceMode2D.Impulse);
            if (_moveHorizontal > 0)
                gameObject.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
            if (_moveHorizontal < 0)
                gameObject.GetComponent<Transform>().rotation = new Quaternion(0, 180, 0, 0);
        }

        if (_moveHorizontal == 0)
        {
            _animator.SetFloat("xVelocity", 0);
        }

        if (!_isJumping && _moveVertical > 0)
        {
            _rb2D.AddForce(new Vector2(0, _moveVertical * _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            _isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            _isJumping = true;
        }

    }
}

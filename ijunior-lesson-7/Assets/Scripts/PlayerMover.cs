using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D _playerRb;
    private bool _isGround = true;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerRb.velocity.y == 0)
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            if (TryGetComponent(out Rigidbody2D _playerRb))
            {
                _playerRb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}

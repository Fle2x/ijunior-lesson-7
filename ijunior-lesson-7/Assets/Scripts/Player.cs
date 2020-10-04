using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRb;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Animator _playeAnimator;
    private bool _isGround = true;
    public bool isGameOver = false;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playeAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
        {
            _playeAnimator.SetBool("isRunnig", true);
        }
        else
        {
            _playeAnimator.SetBool("isRunnig", false);
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
            _playerRb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            _isGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            Destroy(gameObject);
        }
    }
}

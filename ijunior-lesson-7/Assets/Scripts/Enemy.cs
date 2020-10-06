using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _platformDetection;
    [SerializeField] private Player _player;

    private Animator _enemyAnimator;
    private bool _platformEnds = true;
    private float _distance = 2.0f;

    private void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
        _enemyAnimator.SetBool("isRunnig", true);
    }

    private void Update()
    {
        Debug.Log(_player);
        RaycastHit2D platformInfo = Physics2D.Raycast(_platformDetection.position, Vector2.down, _distance);
        if (!_player.isGameOver)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
        else
        {
            _enemyAnimator.SetBool("isRunnig", false);
        }
        
        if (!platformInfo.collider)
        {
            if (_platformEnds)
            {
                transform.Rotate(0, -180, 0);
                _platformEnds = false;
            }
            else
            {
                transform.Rotate(0, 0, 0);
                _platformEnds = true;
            }
        }
    }
}

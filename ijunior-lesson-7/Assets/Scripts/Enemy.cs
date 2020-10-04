using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _platformDetection;
    private Animator _enemyAnimator;
    private bool _platformEnds = true;
    private float _distance = 2.0f;
    private Player _player;


    // Start is called before the first frame update
    void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
        _enemyAnimator.SetBool("isRunnig", true);
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
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

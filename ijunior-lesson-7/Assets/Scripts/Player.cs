using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{

    private Animator _playeAnimator;
    
    public bool isGameOver = false;

    private void Start()
    {
        _playeAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
        {
            _playeAnimator.SetBool("isRunnig", true);
        }
        else
        {
            _playeAnimator.SetBool("isRunnig", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (enemy)
        {
            isGameOver = true;
            Destroy(gameObject);
        }
    }
}

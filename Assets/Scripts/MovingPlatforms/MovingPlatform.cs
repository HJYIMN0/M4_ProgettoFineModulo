using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Movable
{
    [SerializeField] private float _distance = 5f;
    [SerializeField] private float _timer = 2f;

    private Vector3 startPos;
    private Vector3 dir;
    private bool _isMovingForward = true;
    private bool _isWaiting = false;
    private float elapsedTime = 0f;

    public void Start()
    {
        startPos = transform.position;
    }

    public void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        if (_isWaiting)
        {
            elapsedTime += Time.fixedDeltaTime;

            if (elapsedTime >= _timer)
            {
                _isWaiting = false;       // Fine pausa
                elapsedTime = 0f;         
            }
            else
            {
                return; // NON muovere la piattaforma finché non passa il tempo
            }
        }

        if (_isMovingForward)
        {
            dir = Vector3.forward;
        }
        else
        {
            dir = Vector3.back;
        }

        _rb.MovePosition(transform.position + dir * _speed * Time.fixedDeltaTime);

        if (Vector3.Distance(startPos, transform.position) > _distance)
        {
            Debug.Log($"Piattaforma ha raggiunto il limite di distanza {_distance} unità.");

            _isWaiting = true;               
            startPos = transform.position;   
            _isMovingForward = !_isMovingForward;
        }
    }
}

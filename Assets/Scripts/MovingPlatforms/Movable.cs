using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Movable : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] protected float _speed = 5f;

    protected Rigidbody _rb;
    protected Rigidbody _playerRb;
    protected PlayerController _playerController;
    public abstract void Move();

    public void SetPlayer(GameObject player)
    {
        if (player == null) return;
        if (!player.CompareTag("Player")) return;
        _player = player;
    }

    public GameObject GetPlayer() => _player;

    public virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)        
            Debug.LogError("Rigidbody component is missing on the IMovable object.");        
    }


      public virtual void OnCollisionStay(Collision collision)
      { 
          if (_playerController._isMoving)
          {
              float newXSpeed = (_playerController.GetSpeed() + _speed) * _rb.velocity.x; 
              float newZSpeed = (_playerController.GetSpeed() + _speed) * _rb.velocity.z;
              _playerRb.velocity = new Vector3(newXSpeed, _playerRb.velocity.y, newZSpeed); // Apply the platform's movement to the player
          }
          else
          {
              float newZSpeed = _rb.velocity.z;
              float newXSpeed = _rb.velocity.x;
              _playerRb.velocity = new Vector3(newXSpeed, _playerRb.velocity.y, newZSpeed); // Maintain the player's vertical velocity
          }


      }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
              _player = collision.gameObject;
              Debug.Log($"Player {_player.name} salito sulla piattaforma");

              _playerRb = _player.GetComponent<Rigidbody>();
              if (_playerRb == null)          
                  Debug.LogError("Rigidbody component is missing on the player object.");

              _playerController = _player.GetComponentInChildren<PlayerController>();
              if (_playerController == null)          
                  Debug.LogError("PlayerController component is missing on the player object.");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _playerRb.velocity = _playerRb.velocity;
        _player = null;
        _playerRb = null;
        _playerController = null;
    }

}

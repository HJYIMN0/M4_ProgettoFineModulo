using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private int _damageOnReset = 1;
    [SerializeField] private float _fallThreshold = -10f; // Threshold for falling
    private Rigidbody _playerRb;
    private LifeController _playerHP;
    private bool _isAlive;

    private void Awake()
    {
        _playerRb = _player.GetComponent<Rigidbody>();
        if (_playerRb == null)
        {
            Debug.LogError("Rigidbody component is missing on the player object.");
        }
        _playerHP = _player.GetComponentInChildren<LifeController>();
        if (_playerHP == null)
        {
            Debug.LogError("LifeController component is missing on the player object.");
        }
    }

    private void Update()
    {
        IsPlayerFalling();
    }

    public void IsPlayerFalling()
    {
        if (_player.transform.position.y < _fallThreshold) 
        {
            Debug.Log("Player is falling.");
            ResetPlayerPosition();
        }

    }

    public void ResetPlayerPosition()
    {
        if (IsALive())
        {
            _player.transform.position = Vector3.zero; // Reset to origin or a specific spawn point
            _playerRb.velocity = Vector3.zero; // Reset velocity
            _playerRb.angularVelocity = Vector3.zero; // Reset angular velocity
            _playerHP.TakeDamage(_damageOnReset);
            Debug.Log("Player position reset and damage applied.");
        }
        else
        {
            Debug.LogWarning("Player is not alive, cannot reset position.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        }
    }

    public bool IsALive()
    {
        if (_playerHP.GetHp() > 0)
        { _isAlive = true; }

        else
        { _isAlive = false; }

        return _isAlive;

    }




}

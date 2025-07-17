using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PushingObstacle : Movable
{
    [SerializeField] private float _strength = 15f;
    [SerializeField] private float _timeBeforeMove = 0.5f;
    [SerializeField] private float _resetTimer = 2.5f;
    [SerializeField] private float _timeBeforeNewAction = 5f;
    [SerializeField] private Vector3 _boxCheckerSize = new Vector3(5,5,5);
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Transform _trigger;

    UnityEvent playerOnTrigger;

    //public bool FoundPlayer()
    //{
    //    if (Physics.CheckBox(_trigger.transform.position, _boxCheckerSize, Quaternion.identity, _playerLayer))
    //    {
    //        Debug.Log($"Player Found!")
    //        return true;
    //    }
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            SetPlayer(other.gameObject);
            Debug.Log($"Player found! {other.name}");
            StartCoroutine(PushPlayer(GetPlayer()));
        }
    }
    public IEnumerator PushPlayer(GameObject player)
    {
        playerOnTrigger?.Invoke();
        yield return new WaitForSeconds(_timeBeforeMove);
        Move();
        yield return new WaitForSeconds(_resetTimer);
        Reset();
        yield return new WaitForSeconds(_timeBeforeNewAction);
    }

    public override void Move()
    {
        
    }

    public void Reset()
    {
        
    }
}

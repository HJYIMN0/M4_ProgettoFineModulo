using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerManager_UI : MonoBehaviour
{
    [SerializeField] private Image[] _hp;
    [SerializeField] private Image _hasDoubleJump;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _maxScore = 10;

    private void Start()
    {
        foreach (Image image in _hp)
            image.color = Color.green;
    }


    public void TurnOffHp()
    {
        foreach (Image hp in _hp)
        {
            if (hp != null)
            {
                if (hp.color != Color.red)
                {
                    hp.color = Color.red;
                    return;
                }
            }
        }
    }

    public void UiDoubleJump(bool hasDoubleJump)
    {        
        if (_hasDoubleJump == null) return;
        if (hasDoubleJump)
        {
            _hasDoubleJump.color = new Color(0, 1, 0, 1);
        }
        else
        {
            _hasDoubleJump.color = new Color(0, 1, 0, 0);
            
        }

    }

    public void CollectedCoins(int score)
    {
        _scoreText.text = $"{score} / {_maxScore}";
    }

    //private void Update()
    //{
    //    TurnOffHp();
    //}


}

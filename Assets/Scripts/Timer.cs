using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _maxTime;

    private float _timeLeft;
    private bool _isRunning = false;
    private Ball _ball;
    private Vector3 _direction;
    private void Awake()
    {
        _text.enabled = false;
    }

    public void StartTimer(Ball ball, Vector3 direction)
    {
        _text.enabled = true;
        _timeLeft = _maxTime;
        _isRunning = true;
        _direction = direction;
        _ball = ball;
        _ball.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void FixedUpdate()
    {
        if(_isRunning)
        {
            if(_timeLeft >0)
            {
               _timeLeft -= Time.deltaTime;
               _text.text = Mathf.Round(_timeLeft).ToString();
            }
            else
            {
                _ball.GetComponent<Rigidbody2D>().isKinematic=false;
                _ball.PushToDirection(_direction);
                _isRunning = false;
                _text.enabled = false;
            }
        }
    }
}

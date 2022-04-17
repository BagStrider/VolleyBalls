using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _p1Score;
    [SerializeField] private TextMeshProUGUI _p2Score;
    [Space]
    [SerializeField] private UnityEvent _leftSideDrop;
    [SerializeField] private UnityEvent _rightSideDrop;
    [SerializeField] private UnityEvent _ballDrop;
    [SerializeField] private UnityEvent _gameEnd;

    private int scorep1;
    private int scorep2;
    private int _rounds;

    private void Awake()
    {
        SaveSystem.Load();
        _rounds = SaveSystem.settings.rounds;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            if (ball.transform.position.x > 0)
            {
                scorep1++;
                _p1Score.text = scorep1.ToString();
                _rightSideDrop?.Invoke();
            }
            if (ball.transform.position.x < 0)
            {
                scorep2++;
                _p2Score.text = scorep2.ToString();
                _leftSideDrop?.Invoke();
            }
            _ballDrop?.Invoke();
        }

        if (collision.gameObject.TryGetComponent<Player1>(out Player1 p1) && p1.transform.position.x >0)
        {
            scorep2 += 2;
            _p2Score.text = scorep2.ToString();
            _rightSideDrop?.Invoke();
            _ballDrop?.Invoke();
        }

        if (collision.gameObject.TryGetComponent<Player2>(out Player2 p2) && p2.transform.position.x < 0)
        {
            scorep1 += 2;
            _p1Score.text = scorep1.ToString();
            _leftSideDrop?.Invoke();
            _ballDrop?.Invoke();
        }

        if(scorep1 >= _rounds || scorep2 >= _rounds)
        {
            _gameEnd?.Invoke();
        }
    }
}

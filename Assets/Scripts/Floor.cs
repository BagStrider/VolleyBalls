using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _p1Score;
    [SerializeField] private TextMeshProUGUI _p2Score;
    [Space]
    [SerializeField] private UnityEvent _gameEnd;
    [SerializeField] private TextMeshProUGUI _p1Name;
    [SerializeField] private TextMeshProUGUI _p2Name;
    [SerializeField] private EndGame _endGamePanel;
    [SerializeField] private TextMeshProUGUI _winsText;
    [Space]
    [SerializeField] private UnityEvent _leftSideDrop;
    [SerializeField] private UnityEvent _rightSideDrop;
    [SerializeField] private UnityEvent _ballDrop;

    private int _scorep1;
    private int _scorep2;
    private int _rounds;

    private void Awake()
    {
        SaveSystem.Load();
        ScoreManager.Initialize();
        _rounds = SaveSystem.settings.rounds;
        _p1Name.text = SaveSystem.settings.p1Name;
        _p2Name.text = SaveSystem.settings.p2Name;
    }

    public void ResetGame()
    {
        _endGamePanel.gameObject.SetActive(false);
        _scorep1 = 0;
        _scorep2 = 0;
        _p1Score.text = _scorep1.ToString();
        _p2Score.text = _scorep2.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            if (ball.transform.position.x > 0)
            {
                _scorep1++;
                _p1Score.text = _scorep1.ToString();
                _rightSideDrop?.Invoke();
            }
            if (ball.transform.position.x < 0)
            {
                _scorep2++;
                _p2Score.text = _scorep2.ToString();
                _leftSideDrop?.Invoke();
            }
            _ballDrop?.Invoke();
        }

        if (collision.gameObject.TryGetComponent<Player1>(out Player1 p1) && p1.transform.position.x >0)
        {
            _scorep2 += 2;
            _p2Score.text = _scorep2.ToString();
            _rightSideDrop?.Invoke();
            _ballDrop?.Invoke();
        }

        if (collision.gameObject.TryGetComponent<Player2>(out Player2 p2) && p2.transform.position.x < 0)
        {
            _scorep1 += 2;
            _p1Score.text = _scorep1.ToString();
            _leftSideDrop?.Invoke();
            _ballDrop?.Invoke();
        }

        if(_scorep1 >= _rounds || _scorep2 >= _rounds)
        {
            if (_scorep1 > _scorep2)
            {
                _winsText.text = _p1Name.text + " Wins!";
                _winsText.color = Color.red;
            }
            else
            {
                _winsText.text = _p2Name.text + " Wins!";
                _winsText.color = Color.blue;
            }
            _endGamePanel.gameObject.SetActive(true);
            ScoreManager.AddScore(new Score(_p1Name.text, _p2Name.text, _scorep1, _scorep2));
            _gameEnd?.Invoke();
        }
    }
}

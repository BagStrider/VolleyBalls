using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 _playersResetPosition;
    [Space][Space][Space]
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private Vector3 _ballResetPosition;
    [SerializeField] Timer _timer;

    private Ball _ball;
    private Player1 _player1;
    private Player2 _player2;
    private void Awake()
    {
        _ball = GetComponentInChildren<Ball>();
        _player1 = GetComponentInChildren<Player1>();
        _player2 = GetComponentInChildren<Player2>();
    }
    public void ResetBall(float dir)
    {
        Destroy(_ball.gameObject);
        _ball = Instantiate(_ballPrefab, _ballResetPosition,Quaternion.identity, transform);
        _timer.StartTimer(_ball,new Vector3(dir, 0, 0));
    }

    public void ResetPlayers()
    {
        _player1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        _player1.transform.position = new Vector3(-_playersResetPosition.x,_playersResetPosition.y,0);
        _player2.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        _player2.transform.position = new Vector3(_playersResetPosition.x,_playersResetPosition.y,0);
    }

    public void StopGame()
    {
        _player1.GetComponent<Rigidbody2D>().isKinematic = true;
        _player2.GetComponent<Rigidbody2D>().isKinematic = true;
        _ball.GetComponent<Rigidbody2D>().isKinematic=true;
    }
}

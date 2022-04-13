using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpamer : MonoBehaviour
{
    [SerializeField] private Ball _prefab;
    [SerializeField] private int _numberOfBalls;
    [SerializeField] private Vector2 _force;
    [SerializeField] private float _delay;
    [SerializeField] private Vector3 _spawnPosition;

    private List<Ball> _balls;
    private void Awake()
    {
        _balls = new List<Ball>();
        StartCoroutine(SpawnDelay());
    }
    private IEnumerator SpawnDelay()
    {
        while(true)
        {
            yield return new WaitForSeconds(_delay);
            SpawnBall();
        }
    }
    private void SpawnBall()
    {
        Vector2 randomForce = RandomForce();
        CreateBall(randomForce);
    }
    private Vector2 RandomForce()
    {
        int rand = Random.Range(0, 2);
        return rand == 0 ? _force : new Vector2(-_force.x, _force.y);     
    }
    private void CreateBall(Vector2 force)
    {
        Ball ball = Instantiate(_prefab,_spawnPosition,Quaternion.identity,transform);
        ball.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        _balls.Add(ball);
        CheckAmount();
    }
    private void CheckAmount()
    {
        if (_balls.Count > _numberOfBalls)
        {
            Destroy(_balls[0].gameObject);
            _balls.RemoveAt(0);
        }
    }
}

using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void PushToDirection(Vector3 dir)
    {
        _rb.velocity = dir;
    }

    private Vector3 CalculatingVelocity(PlayerController player)
    {
        Vector3 playerVelocity = player.GetComponent<Rigidbody2D>().velocity;
        if (player.IsGrounded && player.IsCroaching)
            return new Vector3(0, Mathf.Abs(playerVelocity.y), playerVelocity.z);
        return new Vector3(playerVelocity.x, Mathf.Abs(playerVelocity.y), playerVelocity.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out var player))
        {
            Vector3 fixedPlayerVelocity = CalculatingVelocity(player);

            _rb.AddForce(fixedPlayerVelocity * _force);
        }
    }

}

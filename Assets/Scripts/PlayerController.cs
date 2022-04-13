using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
 
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;
    [SerializeField] private KeyCode _UpKey;
    [SerializeField] private KeyCode _crouchKey;

    private Rigidbody2D _rb;
    public bool IsGrounded { get; private set; } = true;
    public bool IsCroaching { get; private set; } = false;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(_leftKey))
        {
            //new
            _rb.AddForce(Vector3.left * _speed, ForceMode2D.Impulse);
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_speed, _speed), _rb.velocity.y);
        }
        if(Input.GetKey(_rightKey))
        {
            //new
            _rb.AddForce(Vector3.right * _speed, ForceMode2D.Impulse);
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_speed, _speed), _rb.velocity.y);
        }
        if (Input.GetKey(_UpKey) && IsGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpHeight, ForceMode2D.Impulse);
            _rb.velocity = new Vector3(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -_jumpHeight,_jumpHeight));
        }
        if(Input.GetKey(_crouchKey))
        {
            IsCroaching = true;
            transform.rotation = Quaternion.Euler(0,0,90);
        }
        else
        {
            IsCroaching = false;
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor floor))
            IsGrounded = false;       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor floor))
            IsGrounded =true;  
    }
}

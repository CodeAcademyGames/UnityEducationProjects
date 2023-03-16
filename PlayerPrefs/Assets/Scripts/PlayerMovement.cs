using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    private float _horizontal, _vertical;
    private Vector3 _direction;
    [SerializeField] private float _speed = 0.3f, _currentVelocity, _turnTime = 0.2f;

    private Rigidbody _rb;

    void Start()
    {
            _rb= GetComponent<Rigidbody>();
    }
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _direction = new Vector3(_horizontal, 0, _vertical);

        if (_direction.magnitude > 0.1f)
        {
            float _targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _currentVelocity, _turnTime);
            transform.rotation = Quaternion.Euler(0, _angle, 0);
            _rb.MovePosition(transform.position + (_direction * _speed * Time.fixedDeltaTime));
        }
    }
}

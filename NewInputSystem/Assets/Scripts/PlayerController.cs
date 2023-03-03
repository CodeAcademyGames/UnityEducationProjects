using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float smoothTurnTime;
    
    private InputManager _inputManager;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 _direction;
    private float _smoothTurnVelocity;
    
    private static readonly int Run = Animator.StringToHash("Run");

    private void Awake()
    {
        _inputManager = FindObjectOfType<InputManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _direction = new Vector3(_inputManager.Horizontal, 0, _inputManager.Vertical);

        if (_direction.magnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _smoothTurnVelocity, smoothTurnTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            _rigidbody.MovePosition(transform.position + (_direction * (movementSpeed * Time.deltaTime)));
        }
        _animator.SetFloat(Run, _direction.magnitude);

    }
}

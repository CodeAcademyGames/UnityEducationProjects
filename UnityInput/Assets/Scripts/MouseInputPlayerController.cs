using UnityEngine;

/// <summary>
/// Attach this script to main camera
/// </summary>
public class MouseInputPlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private float _dist;
    private bool _isDragging;
    private Vector3 _mousePositionOffset;
    private Vector3 _drag;
    private Transform _toDrag;
    private Touch _touch;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            Vector3 position = _touch.position;

            if (_touch.phase == TouchPhase.Began)
            {
                Ray ray = _camera.ScreenPointToRay(position);

                if (Physics.Raycast(ray, out RaycastHit hit, layer))
                {
                    _toDrag = hit.transform;
                    _dist = _toDrag.position.z - _camera.transform.position.z;
                    _drag = new Vector3(position.x, position.y, _dist);
                    _drag = _camera.ScreenToWorldPoint(_drag);
                    _mousePositionOffset = _toDrag.position - _drag;
                    _isDragging = true;
                }
            }

            if (_isDragging && _touch.phase == TouchPhase.Moved)
            {
                _drag = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _dist);
                _drag = _camera.ScreenToWorldPoint(_drag);
                _toDrag.position = _drag + _mousePositionOffset;
            }
            
            if (_isDragging && _touch.phase is TouchPhase.Ended || _touch.phase is TouchPhase.Canceled)
            {
                _isDragging = false;
            }
        }
    }
}
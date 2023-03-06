using UnityEngine;

/// <summary>
/// Attach this script to player object
/// </summary>
public class TouchInputPlayerController : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 0.02f;
    [SerializeField] private float verticalSpeed = 0.5f;

    private Touch _touch;

    void Update()
    {
        transform.position += Vector3.forward * (verticalSpeed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                //                                   Get x axis from touch input. 
                float xAxis = transform.position.x + _touch.deltaPosition.x * dragSpeed;
                float yAxis = transform.position.y;
                float zAxis = transform.position.z;

                transform.position = new Vector3(xAxis, yAxis, zAxis);
            }
        }
    }
}
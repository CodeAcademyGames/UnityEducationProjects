using UnityEngine;

/// <summary>
/// Attach this script to main camera
/// </summary>
public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float moveDump = 1;
    [SerializeField] public Transform placeHolder;

    void Update()
    {
        // Smoothly moving at the camera holder position
        transform.position = Vector3.Lerp(transform.position, placeHolder.position, moveDump * Time.deltaTime);
    }
}
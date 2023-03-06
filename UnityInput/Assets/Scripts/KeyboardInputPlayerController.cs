using UnityEngine;

/// <summary>
/// Attach this script to player object
/// </summary>
public class KeyboardInputPlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    void Update()
    {
        // Get x and y axis from input. 
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xAxis, 0, yAxis);
        
        transform.position += direction * (movementSpeed * Time.deltaTime);
    }
}
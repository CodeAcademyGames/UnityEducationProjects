using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Add this component to any object at your scene. 
/// </summary>
public class InputManager : MonoBehaviour, Controls.IPlayerActions
{
    public float Horizontal { get; set; } 
    public float Vertical { get; set; } 
    
    // // You can use this instance for basic projects
    // private void Update()
    // {
    //     Horizontal = Input.GetAxis("Horizontal");
    //     Vertical  = Input.GetAxis("Vertical");
    // }
    
    private void Awake()
    {
        Controls controls = new Controls();
        
        // Sets callbacks for this class
        controls.Player.Enable();
        controls.Player.SetCallbacks(this);
    }
    
    // This callback comes from Controls.cs 
    public void OnMoving(InputAction.CallbackContext context)
    {
        // Read action values as Vector3
        Vector3 move = context.ReadValue<Vector2>();
        Horizontal = move.x;
        Vertical = move.y;
    }

}

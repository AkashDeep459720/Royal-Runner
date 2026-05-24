using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float xClamp = 3f;
    [SerializeField] float ZClamp = 3f;

    Vector2 movement;
    Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        
    }

    void HandleMovement() 
    {
       Vector3 currentPosition = rigidBody.position;
       Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);
       Vector3 newPosition = currentPosition + moveDirection * (MoveSpeed * Time.fixedDeltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -ZClamp, ZClamp);

        rigidBody.MovePosition(newPosition);
    }
}

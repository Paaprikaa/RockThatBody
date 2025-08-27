using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 500f;
    private float moveInput = 0f;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
       
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector3(moveInput * speed * Time.fixedDeltaTime, 0f,0f);
    }
        
    
}

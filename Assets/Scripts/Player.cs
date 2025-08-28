using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    public float speed = 500f;
    private float moveInput = 0f;
    public Rigidbody rb;

    void Update()
    {
        // Only horizontal movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector3(moveInput * speed * Time.fixedDeltaTime, 0f,0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("perdiste");
    }
}

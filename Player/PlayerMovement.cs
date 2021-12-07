using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    readonly float PlayerSpeed = 5f;
    Rigidbody rb;
    float X, Z;
    readonly short JumpMultiplier = 500;
    bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (GameState.currentGameState == GameState.CurrentGameState.Playing)
        {
            PlayerInput();
        }
    }
    void PlayerInput()
    {
        X = Input.GetAxis("Horizontal") * Time.deltaTime * PlayerSpeed;
        Z = Input.GetAxis("Vertical") * Time.deltaTime * PlayerSpeed;
        transform.Translate(X, 0, Z);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * JumpMultiplier, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }
}

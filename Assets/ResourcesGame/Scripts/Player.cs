using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    void Start()
    {
        if (IsOwner)
            rb = GetComponent<Rigidbody2D>();
        else
            this.enabled = false;
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (IsOwner)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            movement = movement.normalized;

            rb.velocity = movement * speed;
        }
    }
}
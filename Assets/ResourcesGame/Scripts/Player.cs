using Unity.Netcode;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private NetworkManager netManager;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        netManager = NetworkManager.Singleton;
    }

    void FixedUpdate()
    {
        if (netManager.IsClient && netManager.LocalClient != null)
            PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (!netManager.ConnectedClients.TryGetValue(netManager.LocalClientId, out NetworkClient client))
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        movement = movement.normalized;

        rb.velocity = movement * speed;
    }
}
using UnityEngine;
using System.Collections;

public class PlayerControllerStiff : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 180f;
    private Rigidbody2D player;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        var horizontalAxis = Mathf.Ceil(Input.GetAxis("Horizontal"));
        var verticalAxis = Mathf.Ceil(Input.GetAxis("Vertical"));



        Vector2 movement = Vector2.zero;

        movement.x += (transform.right).x * horizontalAxis;
        movement.y += (transform.up).y * verticalAxis;

        movement.Normalize();

        movement = movement * moveSpeed;
        player.MovePosition((Vector2)(transform.position) + movement * Time.deltaTime);

    }
}
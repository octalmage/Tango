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
        var horizontalAxis = Input.GetAxisRaw("Horizontal");
        var verticalAxis = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.zero;

        movement.x += (transform.right).x * horizontalAxis;
        movement.y += (transform.up).y * verticalAxis;

        movement.Normalize();

        GameObject circle = GameObject.Find("Circle");
        CircleController circleController = circle.GetComponent<CircleController>();

        movement = movement * circleController.moveSpeed;
        player.MovePosition((Vector2)(transform.position) + movement * Time.deltaTime);

    }
}
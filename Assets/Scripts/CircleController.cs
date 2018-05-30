using UnityEngine;
using System.Collections;

public class CircleController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 180f;
    private Rigidbody2D circle;

    void Start() {
        circle = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //var horizontalAxis = Input.GetAxis("Horizontal");
        //var verticalAxis = Input.GetAxis("Vertical");

        // Turn left or right on left/right buttons
        //transform.Rotate(0, 0, -horizontalAxis * Time.deltaTime * rotationSpeed);
        //transform.Translate(new Vector2(1, -1) * 1 * Time.deltaTime * moveSpeed);

        Vector2 movement = Vector2.zero;
        // Turn left or right on left/right buttons
        //transform.Rotate(0, 0, -horizontalAxis * Time.deltaTime * rotationSpeed);
        //transform.right* Time.deltaTime* moveSpeed

        // Move forward
        //transform.Translate(Vector3.right * verticalAxis * Time.deltaTime * moveSpeed);

        movement.x += (transform.right).x;
        movement.y -= (transform.up).y;

        movement.Normalize();

        movement = movement * moveSpeed;
        circle.MovePosition((Vector2)(transform.position) + movement * Time.deltaTime);
    }
}
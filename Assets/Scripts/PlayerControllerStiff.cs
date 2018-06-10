using UnityEngine;
using System.Collections;

public class PlayerControllerStiff : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 180f;
    private Rigidbody2D player;
    public float externalHorizontalAxis;
    public float externalVerticalAxis;
    public AudioSource source;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalAxis = Input.GetAxisRaw("Horizontal");
        var verticalAxis = Input.GetAxisRaw("Vertical");

        if (externalHorizontalAxis != 0f) {
            horizontalAxis = externalHorizontalAxis;
        }

        if (externalVerticalAxis != 0f) {
            verticalAxis = externalVerticalAxis;
        }

        Vector2 movement = Vector2.zero;

        movement.x += (Vector2.right).x * horizontalAxis;
        movement.y += (Vector2.up).y * verticalAxis;

        movement.Normalize();

        // Rotate ship to match direction.
        if (movement != Vector2.zero)
        {
            if (!source.isPlaying) {
               source.Play();   
            }
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        } else {
            source.Stop();
        }

        GameObject circle = GameObject.Find("Circle");
        CircleController circleController = circle.GetComponent<CircleController>();

        movement = movement * circleController.moveSpeed;

        player.MovePosition((Vector2)(transform.position) + movement * Time.deltaTime);

    }
}

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
        Vector2 movement = Vector2.zero;

        movement.x += (transform.right).x;
        movement.y -= (transform.up).y;

        movement.Normalize();

        movement = movement * moveSpeed;
        circle.MovePosition((Vector2)(transform.position) + movement * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
       
    }

    void OnTriggerExit2D(Collider2D other)
	{
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
	}
}
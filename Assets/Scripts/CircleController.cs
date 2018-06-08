using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

enum Direction
{
    TopLeft,
    BottomLeft,
    TopRight,
    BottomRight,
}

public class CircleController : MonoBehaviour
{   
    public float initialMoveSpeed = 10f;
    public float moveSpeed;
    public float rotationSpeed = 180f;
    public float touchBuffer = 0.2f;
    private Rigidbody2D circle;
    private Direction direction;
    public float timeToTouch = 1.0f;
    private float timeLeft;
    private int score;
    public Text scoreText;
    private float bufferTimer;
    private bool isTouching = false;

    // Health related.
    public Slider healthSlider;
    public int startingHealth = 100;
    public int currentHealth;
    public int healthRewardForDocking = 10;
    public float healthDecreaseSpeed = 0.2f;
    private float healthDecreaseTimer;

    private GameObject[] finishObjects;

    void Start() {
        Time.timeScale = 1;
        circle = GetComponent<Rigidbody2D>();
        direction = RandomDirection();
        timeLeft = timeToTouch;
        score = 0;
        scoreText.text = "0";
        moveSpeed = initialMoveSpeed;
        currentHealth = startingHealth;
        healthDecreaseTimer = healthDecreaseSpeed;
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");
        hideFinished();

        Vector2 randomPositionOnScreen = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        circle.MovePosition(randomPositionOnScreen);
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        switch (direction)
        {
            case Direction.TopLeft:
                movement.x -= (transform.right).x;
                movement.y += (transform.up).y;
                break;
            case Direction.TopRight:
                movement.x += (transform.right).x;
                movement.y += (transform.up).y;
                break;
            case Direction.BottomLeft:
                movement.x -= (transform.right).x;
                movement.y -= (transform.up).y;
                break;
            case Direction.BottomRight:
                movement.x += (transform.right).x;
                movement.y -= (transform.up).y;
                break;
            default:
                Debug.Log("Direction Unknown");
                break;
        }

        movement.Normalize();

        movement = movement * moveSpeed;
        circle.MovePosition((Vector2)(transform.position) + movement * Time.deltaTime);

        if (bufferTimer >= 0 && !isTouching) {
            bufferTimer -= Time.deltaTime;
        } 

        if (bufferTimer <= 0 && !isTouching) {
            UnDock();
        }

        if (!isTouching) {
            healthDecreaseTimer -= Time.deltaTime;
            if (healthDecreaseTimer <= 0) {
                currentHealth--;
                healthDecreaseTimer = healthDecreaseSpeed;
            }
        }
           
        // 5 is when the slider looks empty.
        if (currentHealth <= 5) {
            Time.timeScale = 0;
            showFinished();
        }

        healthSlider.value = currentHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isTouching = true;
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
       
    }

    private void OnTriggerStay2D(Collider2D other)
	{
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            SuccessfulDock();
        }

        bufferTimer = touchBuffer;
	}

	void OnTriggerExit2D(Collider2D other)
	{
        isTouching = false;
        bufferTimer = touchBuffer;
	}

    void UnDock() {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        timeLeft = timeToTouch;
    }

    void SuccessfulDock() {
        timeLeft = timeToTouch;
        direction = RandomDirection();
        score++;
        moveSpeed = score + initialMoveSpeed;
        scoreText.text = score.ToString();
        currentHealth += healthRewardForDocking;
    }

    public void showFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnFinish tag
    public void hideFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private Direction RandomDirection()
    {   
        System.Array values = System.Enum.GetValues(typeof(Direction));
        return (Direction)values.GetValue(Random.Range(0, values.Length));
    }
}
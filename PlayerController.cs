using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // public  variables
    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    public GameObject movingMermaid;
    public GameObject idleMermaid;
    public float scoreMultiplier = 10f;
    public UIDocument uiDocument;
    public GameObject explosionEffect;
    public GameObject borderParent;
    // private variables
    private Rigidbody2D rb;
    private float elapsedTime = 0f;
    private float score = 0f;
    private Label scoreText;
    private Button restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // create rigid body, score text, restart button, on-click for restart button
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
        movingMermaid.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        MovePlayer();
    }

    void UpdateScore()
    {
        // time counter, calc score and update UI
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score: " + score;
    }

    void MovePlayer()
    {
        //moves rocket
        if (Mouse.current.leftButton.isPressed)
        {
            //get mouse pos, translate to game coords, make vector, chanmge players 'up', apply force up
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
        // booster flame follows clicked or not
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            movingMermaid.SetActive(true);
            idleMermaid.SetActive(false);
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            movingMermaid.SetActive(false);
            idleMermaid.SetActive(true);
        }
    }

    // Void is called on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        //die on collision
        Instantiate(explosionEffect, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex;
        borderParent.SetActive(false);
        Destroy(gameObject);
    }

    // reload button functionality
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

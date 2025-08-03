
using TMPro;
using UnityEngine;
public class BallPhysics : MonoBehaviour
{
    [SerializeField] float ballSpeed = 8f;
    [SerializeField] TMP_Text livesText;

    [SerializeField] float speedMultiplier = 1.1f;
    [SerializeField] Transform startPos;
    [SerializeField] float maxSpeed = 45;
    [SerializeField] int playerLives = 3;
    [SerializeField] int currentLive = 0;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text scoreTextAtGameOverScreen;
    [SerializeField] GameObject gameOverCont;
    Animator anim;
    TrailRenderer trailRenderer;
    int currentScore = 0;


    bool canPressSpace = true;
    Rigidbody2D rb;

    void Awake()
    {
        gameOverCont.SetActive(false);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canPressSpace = true;
        rb.linearVelocity = new Vector2(0, 0);
        trailRenderer = GetComponent<TrailRenderer>();
        anim = GetComponent<Animator>();
        currentLive = playerLives;
        LivesLeft();
    }

    void Update()
    {
        Launch();

    }

    void Launch()
    {
        float maxAngle = 2f;
        Vector2 facingDir = Vector2.up;
        facingDir.x = Random.Range(-maxAngle, maxAngle) == 0 ? 1f : -1f;

        if (Input.GetKey(KeyCode.Space) && canPressSpace)
        {
            rb.linearVelocity = facingDir * ballSpeed;
            canPressSpace = !canPressSpace;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        BrickHealth brick = collision.gameObject.GetComponent<BrickHealth>();
        CameraShake.Instance.Shake();
        SounManager.Instance.BounceSound();
        if (collision.gameObject.CompareTag("Walls"))
        {
            anim.SetTrigger("SideHit");
        }
        else
        {
            anim.SetTrigger("Hit");
        }
        

        if (brick)
        {
            if (collision.gameObject.CompareTag("Yellow"))
            {
                ScoreUpdate(50);
            }
            if (collision.gameObject.CompareTag("Red"))
            {
                ScoreUpdate(100);
            }
        }
        
        rb.linearVelocity *= speedMultiplier;


        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.linearVelocity *= speedMultiplier;
        }
        else
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        SubLives();

    }

    void ResetBallPos()
    {
        rb.linearVelocity = new Vector2(0f, 0f);
        transform.position = startPos.position;
        canPressSpace = true;

    }

    void GameOverScreen()
    {
        gameOverCont.SetActive(true);
    }

    void LivesLeft()
    {
        livesText.text = currentLive.ToString("D2");


    }
    void SubLives()
    {
        currentLive--;
        LivesLeft();
        if (currentLive <= 0)
        {
            GameOverScreen();
            trailRenderer.Clear();
            Destroy(this.gameObject, 2f);
        }
        if (currentLive > 0)
        {
            Invoke("ResetBallPos", 0.5f);
            canPressSpace = true;
        }
    }

    void ScoreUpdate(int amount)
    {
        currentScore += amount;

        scoreText.text = currentScore.ToString("D4");
        scoreTextAtGameOverScreen.text = currentScore.ToString("D4");
    }
    
}

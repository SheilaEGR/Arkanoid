using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    public Ball ball;

    public float paddleSpeed = 500;
    public float force = 500.0f;
    public float scale = 0.3f;

    private float movement = 0;
    private bool gameStarted = false;
    private bool applyInitialForce = false;
    private Rigidbody2D rb;
    private Vector2 initialPosition;

    // ========================================================================
    // =====                      PUBLIC FUNCTIONS                        =====
    // ========================================================================


    // ========================================================================
    // =====                      PRIVATE FUNCTIONS                       =====
    // ========================================================================
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        Restart();
    }

    private void Update()
    {
        if(Globals.resetGame)
        {
            Globals.resetGame = false;
            Restart();
        }

        movement = Input.GetAxis("Horizontal");

        if(!gameStarted)
        {
            ball.UpdatePositionX(transform.position.x);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
                applyInitialForce = true;
                Debug.Log("Start!");
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * paddleSpeed * Time.fixedDeltaTime, 0f);

        if(applyInitialForce)
        {
            float angle = Random.Range(-30, 30) * Mathf.Deg2Rad;
            Vector2 forceVec = new Vector2(force * Mathf.Sin(angle),
                                            force * Mathf.Cos(angle));
            ball.ApplyForce(forceVec);
            applyInitialForce = false;
        }
    }


    // ========================================================================
    // =====                      PADDLE COLLISIONS                       =====
    // ========================================================================
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !applyInitialForce)
        {
            Vector2 vel = rb.velocity;
            vel.Normalize();
            vel.y *= -1;
            Ball mBall = collision.gameObject.GetComponent<Ball>();
            mBall.ApplyForce(vel * force * 0.1f);
        }
    }


    // ========================================================================
    // ========================================================================
    private void Restart()
    {
        transform.position = initialPosition;
        gameStarted = false;
        applyInitialForce = false;
        rb.velocity = Vector2.zero;
    }
}

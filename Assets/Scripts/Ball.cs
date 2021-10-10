using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isPlaying = false;
    private float initialY;
    private AudioManager audioManager;
    private TrailRenderer trail;

    // ========================================================================
    // =====                      PUBLIC FUNCTIONS                        =====
    // ========================================================================
    public void ApplyForce(Vector2 force)
    {
        rb.AddForce(force);
        isPlaying = true;
    }

    public void UpdatePositionX(float X)
    {
        if (isPlaying) return;
        transform.position = new Vector2(X, initialY);
    }


    // ========================================================================
    // =====                      PRIVATE FUNCTIONS                       =====
    // ========================================================================
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
        trail = GetComponent<TrailRenderer>();

        initialY = transform.position.y;
        Restart();
    }

    private void FixedUpdate()
    {
        if(Globals.levelFinished)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        CheckVelocity();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Brick")
        {
            Brick mBrick = collision.gameObject.GetComponent<Brick>();
            Globals.score += mBrick.GetPoints();
        }
        audioManager.Play("HitBall");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Globals.ballsLeft--;
            if (Globals.ballsLeft == 0)
            {
                Globals.gameOver = true;
                Debug.Log("Game over!");
                audioManager.Play("GameOver");
            }
            else
            {
                Globals.resetGame = true;
                Restart();
                audioManager.Play("LostBall");
            }
        }
    }


    // ========================================================================
    // =====                          UTILITIES                           =====
    // ========================================================================
    private void Restart()
    {
        transform.position = new Vector2(0, initialY);
        trail.Clear();
        rb.velocity = Vector2.zero;
        isPlaying = false;
    }

    private void CheckVelocity()
    {
        Vector2 velVec = rb.velocity;
        velVec.Normalize();
        // ===== MINIMUM ANGLE 
        if (Mathf.Abs(velVec.y) < 0.2f)
        {
            velVec.y = 0.2f * Mathf.Sign(velVec.y);
        }
        // ===== MINIMUM VELOCITY OF 9
        if (rb.velocity.magnitude < 9)
        {
            rb.velocity = velVec * 9;
        }
        
    }
}

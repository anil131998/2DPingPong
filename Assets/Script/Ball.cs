using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startDir;
    private Vector2 smoothVelocity = Vector2.zero;
    private float smoothTime = 0.3f;
    private int sideBounces = 0;

    [SerializeField] private float startForce = 500;
    [SerializeField] private float ballSpeed = 15;

    public static UnityAction Evnt_Score;
    public static UnityAction Evnt_GameOver;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void StartGame()
    {
        startDir = new Vector2(1, 1);
        sideBounces = 0;
        rb.AddForce(startDir.normalized * startForce);
    }
    
    private void GameOver()
    {
        rb.velocity = Vector2.zero;
        Evnt_GameOver?.Invoke();
    }

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude > 0 && rb.velocity.magnitude != ballSpeed)
        {
            rb.velocity =  Vector2.SmoothDamp(rb.velocity , rb.velocity.normalized * ballSpeed, ref smoothVelocity, smoothTime);
        }
    }

    private void Score()
    {
        sideBounces = 0;
        ballSpeed += 0.1f;
        Evnt_Score?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case "LeftGoal":
                GameOver();
                return;
            case "RightGoal":
                GameOver();
                return;

            case "LeftPlayer":
                Score();
                rb.AddForce( Vector2.right , ForceMode2D.Impulse);
                break;
            case "RightPlayer":
                Score();
                rb.AddForce(Vector2.left, ForceMode2D.Impulse);
                break;

            case "UpperEnd":
                sideBounces++;
                if (sideBounces > 2)
                    GameOver();
                break;
            case "LowerEnd":
                sideBounces++;
                if (sideBounces > 2)
                    GameOver();
                break;

            default:
                break;
        }

    }


    private void OnEnable()
    {
        GameplayManager.Evnt_StartGame += StartGame;
    }
    private void OnDisable()
    {
        GameplayManager.Evnt_StartGame -= StartGame;
    }

}

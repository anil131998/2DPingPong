using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Player1;
    [SerializeField] private Rigidbody2D Player2;
    [SerializeField] private float playerspeed;

    private Vector2 Player1Mov;
    private Vector2 Player2Mov;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
            Player1Mov = new Vector2(0f, 1f);
        else if (Input.GetKey(KeyCode.S))
            Player1Mov = new Vector2(0f, -1f);
        else
            Player1Mov = new Vector2(0f, 0f);

        if (Input.GetKey(KeyCode.UpArrow))
            Player2Mov = new Vector2(0f, 1f);
        else if (Input.GetKey(KeyCode.DownArrow))
            Player2Mov = new Vector2(0f, -1f);
        else
            Player2Mov = new Vector2(0f, 0f);

    }

    private void FixedUpdate()
    {
        Player1.velocity = Player1Mov * playerspeed * Time.fixedDeltaTime;
        Player2.velocity = Player2Mov * playerspeed * Time.fixedDeltaTime;
    }

}

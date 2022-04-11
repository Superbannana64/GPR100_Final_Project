using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float xInput, yInput;
    public float playerSpeed = 5.0f;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        CheckInput();
    }
    void FixedUpdate()
    {
        PlayerPhysics();
    }
    void PlayerPhysics()
    {
        if(xInput != 0 && yInput != 0)
        {
            xInput *= .7f;
            yInput *= .7f;
        }
        rb2d.velocity = new Vector2(xInput*playerSpeed, yInput*playerSpeed);
    }
    void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
    void TriggerCheckInput()
    {

    }
}

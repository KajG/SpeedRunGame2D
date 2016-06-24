using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public float jumpHeight;
    private float timer = 0.75f;
    private bool Ground;
    private bool timerCheck;
    public float speedR = 0f;
    public float speedL = 0f;
    private float maxSpeedR = 10f;
    private float maxSpeedL = -10f;
    private bool speedUpR = false;
    private bool speedUpL = false;
    private bool canDoubleJump = false;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("up")) 
        {
            if (Ground)
            {
                maxSpeedL = -10f;
                maxSpeedR = 10f;
                _rigidbody.gravityScale = 1;
                timerCheck = true;
                _rigidbody.AddForce(transform.up * jumpHeight);
                Ground = false;
                canDoubleJump = true;
             }
             else if (canDoubleJump)
             {
                canDoubleJump = false;
                timerCheck = true;
                Ground = false;
                _rigidbody.AddForce(transform.up * jumpHeight);
              }
        }
        
        if (!Ground)
        {
            maxSpeedL = -6f;
            maxSpeedR = 6f;
        }
        Debug.Log(timer);
        if (timerCheck)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            _rigidbody.gravityScale = 2;
            timerCheck = false;
            timer = 0.75f;
        }




        transform.position += Vector3.right * speedR * Time.deltaTime;
        transform.position += Vector3.right * speedL * Time.deltaTime;
        if (Input.GetKeyDown("right"))
        {
            speedUpR = true;
            Debug.Log(speedUpR);
        }
        else if (Input.GetKeyUp("right"))
        {
            speedUpR = false;
            Debug.Log(speedUpR);
        }
        if (speedUpR == true && speedR < maxSpeedR)
        {
            speedR += 0.5f;
        }
        if (speedUpR == false && speedR > 0)
        {
            speedR -= 0.5f;
        }

        if (Input.GetKeyDown("left"))
        {
            speedUpL = true;
            Debug.Log(speedUpL);
        }
        else if (Input.GetKeyUp("left"))
        {
            speedUpL = false;
            Debug.Log(speedUpL);
        }
        if (speedUpL == true && speedL > maxSpeedL)
        {
            speedL -= 0.5f;
        }
        if (speedUpL == false && speedL < 0)
        {
            speedL += 0.5f;
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Ground = true;
        }
    }
}
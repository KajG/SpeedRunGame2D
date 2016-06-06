using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public float jumpHeight;
    private float timer = 0.75f;
    private bool Ground;
    private bool timerCheck;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Ground)
        {
            _rigidbody.gravityScale = 1;
            if (Input.GetKeyDown("i"))
            {
                timerCheck = true;
                _rigidbody.AddForce(transform.up * jumpHeight);
                Ground = false;
            }
        }
        Debug.Log(timer);
        if (timerCheck)
        {
            timer -= Time.deltaTime;
        }
        if(timer < 0)
        {
            _rigidbody.gravityScale = 2;
            timerCheck = false;
            timer = 0.75f;
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

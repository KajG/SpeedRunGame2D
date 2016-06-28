using UnityEngine;
using System.Collections;

public class pinWheelMovement : MonoBehaviour {
    private float speed = -2;
    private float x;
    public GameObject target;
    public GameObject spawnpoint;
    
    void Awake()
    {
        
    }

	void Start ()
    {
        
	}
	

	void Update ()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hallo");
        if (other.gameObject.CompareTag("Ground"))
        {
            this.transform.position = target.transform.position;
        }
    }
}

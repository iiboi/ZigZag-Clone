using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 8f;

    private Rigidbody rb;

    private bool isMovingForward = true;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() 
    {
        rb.linearVelocity = Vector3.forward * speed;
    }

    private void Update()
    {

        if (transform.position.y > 0.75)
        {
            Vector3 tempPos = transform.position;
            tempPos.y = 0.75f;
            transform.position = tempPos;    
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Movement();
        }

    }

    private void Movement()
    {
        if(isMovingForward)
        {
            rb.linearVelocity = Vector3.right * speed;

            isMovingForward = false;
        }
        else
        {
            rb.linearVelocity = Vector3.forward * speed;

            isMovingForward = true;
        }
    }

    public void IncreaseSpeed()
    {
        speed += 1.5f;

        Debug.Log($"New Speed: {speed}");
    }
}
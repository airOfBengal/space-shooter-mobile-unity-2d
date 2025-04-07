using UnityEngine;

public class Meteor : Enemy
{
    public float minSpeed;
    public float maxSpeed;
    private float speed;
    public float rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.linearVelocity = Vector2.down * speed;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    public override void HurtSequence()
    {
        
    }

    public override void DeathSequence()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            Destroy(collision.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

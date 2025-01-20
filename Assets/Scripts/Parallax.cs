using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector2 startPosition;
    [SerializeField] private float speed = 5f;
    private float spriteHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);

        if(transform.position.y < startPosition.y - spriteHeight)
        {
            transform.position = startPosition;
        }
    }
}

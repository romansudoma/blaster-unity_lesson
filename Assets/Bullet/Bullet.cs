using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float xSpeed;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(xSpeed, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        gameManager.AddScore();
        Destroy(gameObject);
    }
}

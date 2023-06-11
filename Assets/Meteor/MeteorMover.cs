using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    public float speed = -2f;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, speed);
    }
}

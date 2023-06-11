using UnityEngine;
using TMPro;

public class ShipControl : MonoBehaviour
{
    public GameManager gameManager;
    public Bullet bulletPrefab;
    public float speed = 10f;
    public float xLimit = 7f;
    public float yLimit = 6f;
    public float reloadTime = 0.2f;

    float elapsedTime = 0f;

    public float shield = 100f;
    public TMP_Text shieldText;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        float xInput = Input.GetAxis("Horizontal");
        transform.Translate(xInput * speed * Time.deltaTime, 0f, 0f);
        float yInput = Input.GetAxis("Vertical");
        transform.Translate(0f, yInput * speed * Time.deltaTime, 0f);

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        position.y = Mathf.Clamp(position.y, -yLimit, yLimit);
        transform.position = position;

        if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
        {
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0.5f, 1.2f, 0);
            bulletPrefab.xSpeed = 5f;
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            spawnPos = transform.position;
            spawnPos += new Vector3(-0.5f, 1.2f, 0);
            bulletPrefab.xSpeed = -5f;
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

            elapsedTime = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shield <= 0f)
            gameManager.PlayerDied();
        else
        {
            shield -= 10f;
            shieldText.text = shield.ToString();
            Destroy(collision.gameObject);
        }
            
    }
}

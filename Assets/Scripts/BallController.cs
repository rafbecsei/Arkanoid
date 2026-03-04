using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Block"))
        {
            FindFirstObjectByType<GameManager>().BlocoDestruido();
            Destroy(coll.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("ParedeBaixo"))
        {
            Debug.Log("Bola caiu!");
            FindFirstObjectByType<GameManager>().PerdeVida();
            // Destroy(gameObject);
        }
    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Mathf.Abs(rb.linearVelocity.x) < 1f)
        {
            float direction = rb.linearVelocity.x >= 0 ? 1 : -1;
            rb.linearVelocity = new Vector2(direction * 2f, rb.linearVelocity.y);
        }
        else if (Mathf.Abs(rb.linearVelocity.y) < 1f)
        {
            float direction = rb.linearVelocity.y >= 0 ? 1 : -1;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, direction * 2f);
        }
    }
}

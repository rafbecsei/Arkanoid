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
            Destroy(coll.gameObject);
        }

        else if(coll.collider.CompareTag("ParedeBaixo"))
        {
            FindObjectOfType<GameManager>().PerdeVida();
            Destroy(gameObject);
        }
    }
}

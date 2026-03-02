using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject ballPrefab;
    public Transform ballSpawnPoint;

    private GameObject currentBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(currentBall == null)
        {
            currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);

            Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(Random.Range(-2f, 2f), 8f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

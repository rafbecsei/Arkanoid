using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public int vidas = 3;

    private GameObject currentBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBall();
    }

    void SpawnBall()
    {

        currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(Random.Range(-2f, 2f), 8f);
    }

    public void PerdeVida()
    {
        vidas--;

        if(vidas > 0)
        {
            if(currentBall != null)
            {
                Destroy(currentBall);
            }

            SpawnBall();
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

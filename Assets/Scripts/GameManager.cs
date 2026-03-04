using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public int vidas = 3;
    public int blocos;

    private GameObject currentBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBall();

        blocos = GameObject.FindGameObjectsWithTag("Block").Length;
    }

    void SpawnBall()
    {
        currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(Random.Range(-4f, 4f), 8f);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void BlocoDestruido()
    {
        blocos--;

        if(blocos <= 0)
        {
            Debug.Log("Você venceu!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

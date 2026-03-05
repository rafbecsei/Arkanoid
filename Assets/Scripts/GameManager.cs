using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public int vidas = 3;
    public int blocos;

    private GameObject currentBall;

    public GameObject paddleRedPrefab;
    public Vector2 vidasStartPos = new Vector2(-3.5f, -4.5f);
    public float espacamentoEntreVidas = 1f;
    private List<GameObject> vidasVisuais;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnVidasVisuais();

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

        // Remove visual da vida perdida
        if (vidasVisuais.Count > 0)
        {
            GameObject ultimaVida = vidasVisuais[vidasVisuais.Count - 1];
            vidasVisuais.RemoveAt(vidasVisuais.Count - 1);
            Destroy(ultimaVida);
        }

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
            SceneManager.LoadScene("GameOver");
        }
    }

    public void BlocoDestruido()
    {
        blocos--;

        if(blocos <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // SceneManager.LoadScene("fase2");
        }
    }

    void SpawnVidasVisuais()
    {
        vidasVisuais = new List<GameObject>();

        for (int i = 0; i < vidas; i++)
        {
            Vector3 pos = new Vector3(vidasStartPos.x + i * espacamentoEntreVidas, vidasStartPos.y, 0);
            GameObject vida = Instantiate(paddleRedPrefab, pos, Quaternion.identity);
            vidasVisuais.Add(vida);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

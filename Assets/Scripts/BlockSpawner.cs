using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;

    public int linhas = 6;
    public int colunas = 10;
    public float espacamento = 0.03f;

    public Vector2 StartPosition = new Vector2(-3.72f, 3f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < linhas; i++)
        {
            for(int j = 0; j < colunas; j++)
            {
                Vector2 posicao = new Vector2(StartPosition.x + j * (0.8f + espacamento), 
                                            StartPosition.y - i * (0.35f + espacamento)); 
                GameObject bloco = Instantiate(blockPrefabs[i], posicao, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

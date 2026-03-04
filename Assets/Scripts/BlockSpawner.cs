using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs; // 0: R (roxo), 1: V (verde), 2: A (azul), 3: Vm (vermelho), 4: Am (amarelo), 5: C (cinza)

    public Vector2 StartPosition = new Vector2(-3.72f, 3f);
    public float espacamento = 0.03f;
    public float colunaWidth = 0.8f;
    public float linhaHeight = 0.35f;

    void Start()
    {
        int fase = SceneManager.GetActiveScene().buildIndex;

        if(fase == 1)
        {
            // Fase1: layout padrão 6x10
            int linhas = 6;
            int colunas = 10;

            for(int i = 0; i < linhas; i++)
            {
                for(int j = 0; j < colunas; j++)
                {
                    Vector2 posicao = new Vector2(
                        StartPosition.x + j * (colunaWidth + espacamento),
                        StartPosition.y - i * (linhaHeight + espacamento)
                    );

                    GameObject prefab = blockPrefabs[i % (blockPrefabs.Length - 1)]; // exceto cinza
                    Instantiate(prefab, posicao, Quaternion.identity);
                }
            }
        }
        else if(fase == 2)
        {
            // Fase2: escada da direita para a esquerda
            int colunasEscada = 10; // número de colunas
            int[] degrausPorColuna = {1,2,3,4,5,6,7,8,9,10}; // número de blocos coloridos por coluna

            for(int c = 0; c < colunasEscada; c++)
            {
                int degraus = degrausPorColuna[c];
                for(int l = 0; l <= degraus; l++)
                {
                    Vector2 posicao = new Vector2(
                        StartPosition.x + (colunasEscada - 1 - c) * (colunaWidth + espacamento), // da direita para a esquerda
                        StartPosition.y - l * (linhaHeight + espacamento)
                    );

                    GameObject prefab;

                    if(l == 0)
                    {
                        // base cinza
                        prefab = blockPrefabs[5]; // C
                    }
                    else
                    {
                        // cores na sequência: R, V, A, Vm, Am
                        prefab = blockPrefabs[(l - 1) % 5]; // 0-4
                    }

                    Instantiate(prefab, posicao, Quaternion.identity);
                }
            }
        }
    }
}
using UnityEngine;

public class Player : MonoBehaviour
{

   private Rigidbody2D paddleRed_0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paddleRed_0 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = -4.05f;
        if (pos.x <= -3.56f){
            pos.x = -3.56f;
        }
        if (pos.x >= 3.6f){
            pos.x = 3.6f;
        }
        transform.position = pos;
    }
}

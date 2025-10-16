using UnityEngine;

public class movObjetos : MonoBehaviour
{

    public float velocidade = 2f;
    public float pontoParaDestruir;

    void Update()
    {
        transform.Translate(Vector2.down * velocidade * Time.deltaTime);

        if (transform.position.y < pontoParaDestruir)
        {
            Destroy(this.gameObject);
        }
    }
}

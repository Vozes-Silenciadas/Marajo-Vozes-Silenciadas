using Unity.Mathematics;
using UnityEngine;

public class Inimigo_vira : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 localScale;
    inventarioControla inventario;
    
    float tempoAtual;
    float tempoMax = 3;
    float cont = 0;

    public bool atordoado = false;
    float tempoAtor;
    float tempoMaxAtor = 1.5f;
    public bool jogadorEstaNaArea;

    public GameObject Z;


    void Start()
    {
        tempoAtual = tempoMax;
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        inventario = FindAnyObjectByType<inventarioControla>();
    }

    void Update()
    {
        if (!atordoado)
        {
            if (tempoAtual < 0)
            {
                tempoAtual = tempoMax;
                cont++;
            }
            else
            {
                tempoAtual -= Time.deltaTime;
            }
            if (cont == 1)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90);
            }
            if (cont == 2)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                cont = 0;
            }

            if (jogadorEstaNaArea && Input.GetKeyDown(KeyCode.Space))
            {
                if (inventario.verificarItem(2))
                {
                    atordoado = true;
                    tempoAtor = tempoMaxAtor;
                    float x = 0.05f, y = 0.15f;
                    float tempoDes = 1.4f;

                    for(int i = 0; i < 3; i++)
                    {
                        GameObject novoZ = Instantiate(Z, transform.transform);
                        novoZ.transform.localPosition = new Vector2(x, y);
                        novoZ.transform.localScale = new Vector2(0.05f, 0.05f);
                        Destroy(novoZ, tempoDes);
                        tempoDes -= 0.6f;
                        x -= 0.05f;
                    }
                }
                else
                {
                    Debug.Log("Você não tem nada para atordoar");
                }
            }

        }
        else
        {
            if (tempoAtor < 0)
                {
                    atordoado = false;
                }
                else
                {
                    tempoAtor -= Time.deltaTime;                
                    Debug.Log("Atordoado" + tempoAtor);
                }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorEstaNaArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorEstaNaArea = false;
        }
    }
}

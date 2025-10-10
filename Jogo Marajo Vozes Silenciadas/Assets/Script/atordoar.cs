using UnityEngine;

public class atordoar : MonoBehaviour
{
    inventarioControla inventario;
    public bool atordoado = false;
    public float tempoAtor;
    public float tempoMaxAtor = 1.5f;
    public bool jogadorEstaNaArea;
    public MonoBehaviour script;
    public GameObject Z;
    Rigidbody2D rb;

    void Start()
    {
        inventario = FindAnyObjectByType<inventarioControla>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (atordoado)
        {

            if (tempoAtor < 0)
            {
                atordoado = false;
                script.enabled = true;
            }
            else
            {
                tempoAtor -= Time.deltaTime;
                Debug.Log("Atordoado" + tempoAtor);
            }
        }
        
        AtordoarInimigo();
    
    }

    public void AtordoarInimigo()
    {
        if (jogadorEstaNaArea && Input.GetKeyDown(KeyCode.Space))
        {
            if (inventario.verificarItem(2))
            {
                atordoado = true;
                tempoAtor = tempoMaxAtor;
                float x = 0.05f, y = 0.15f;
                float tempoDes = 1.4f;
                script.enabled = false;
                rb.linearVelocity = Vector2.zero;
                for (int i = 0; i < 3; i++)
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

    public void Voltando()
    {
       
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

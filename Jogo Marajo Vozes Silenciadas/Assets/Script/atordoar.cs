using UnityEngine;

public class atordoar : MonoBehaviour
{
    inventarioControla inventario;

    bool atordoado = false;
    float tempoAtor;
    float tempoMaxAtor = 1.5f;
    MonoBehaviour[] scripts;
    Transform pai;
    Rigidbody2D rb;
    
    public GameObject Z;
    public bool jogadorEstaNaArea;
    public int ItemParaAtordoar;

    void Start()
    {
        pai = transform.parent;
        inventario = FindAnyObjectByType<inventarioControla>();
        rb = GetComponentInParent<Rigidbody2D>();
        scripts = pai.GetComponents<MonoBehaviour>();
    }

    void Update()
    {
        if (atordoado)
        {
            if (tempoAtor < 0)
            {
                atordoado = false;
                LigarOuDesligar();
            }
            else
            {
                tempoAtor -= Time.deltaTime;
            }
        }
        
        AtordoarInimigo();
    
    }

    public void AtordoarInimigo()
    {
        if (jogadorEstaNaArea && Input.GetKeyDown(KeyCode.Space))
        {
            if (inventario.verificarItem(ItemParaAtordoar))
            {
                atordoado = true;
                tempoAtor = tempoMaxAtor;
                float x = 0.05f, y = 0.15f;
                float tempoDes = 1.4f;
                LigarOuDesligar();
                rb.linearVelocity = Vector2.zero;
                for (int i = 0; i < 3; i++)
                {
                    GameObject novoZ = Instantiate(Z, transform.transform);
                    novoZ.transform.localPosition = new Vector2(x, y);
                    novoZ.transform.localScale = new Vector2(0.5f, 0.5f);
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

    public void LigarOuDesligar()
    {
       foreach (MonoBehaviour mono in scripts)
        {
            mono.enabled = !mono.enabled;
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

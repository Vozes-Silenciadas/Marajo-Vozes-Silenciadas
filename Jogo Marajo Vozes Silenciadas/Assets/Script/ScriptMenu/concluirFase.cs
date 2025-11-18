using UnityEngine;
using UnityEngine.SceneManagement;

public class concluirFase : MonoBehaviour
{
    Coleta_itens pistass;             // Refer�ncia ao script que controla a coleta de pistas
    public FalaBalao fala;            // Refer�ncia ao script respons�vel por exibir falas ou bal�es de di�logo
    public GameObject telaFinal;
    public transicao transicao;
   
    void Start()
    {                
        fala = FindAnyObjectByType<FalaBalao>();     // Procura automaticamente o objeto que cont�m o script FalaBalao na cena
        pistass = FindAnyObjectByType<Coleta_itens>(); // Procura o script Coleta_itens (para saber quantas pistas foram coletadas)
        telaFinal.SetActive(false);
        
    }

    void OnCollisionEnter2D(Collision2D collision)   // Detecta colis�es f�sicas 
    {
        if (collision.collider.CompareTag("Player")) // Verifica se quem colidiu foi o jogador
        {
            Scene cena = SceneManager.GetActiveScene();
            if (cena.name == "Fase1")
            {
                if (pistass.contaPista >= 6)             // Se o jogador j� coletou 6 ou mais pistas
                {
                    telaFinal.SetActive(true);// Carrega a tela de transicao
                    transicao.ComecarEscrita();           
                }
                else                                     // Caso o jogador ainda n�o tenha todas as pistas
                {
                    StartCoroutine(fala.tempoFechar("Preciso de mais pistas")); // Mostra mensagem dizendo que faltam pistas
                }
            }
            if(cena.name == "Fase2")
            {
                aliadoSegue[] aliado = FindObjectsOfType<aliadoSegue>();

                foreach (aliadoSegue aliadoSegue in aliado)
                {
                    aliadoSegue.ChegouNoBarco();
                    if(aliadoSegue.qtdResgatados == 3)
                    {
                        telaFinal.SetActive(true);// Carrega a tela de transicao
                        transicao.ComecarEscrita();           
                    }
                }  
                if (aliadoSegue.qtdResgatados < 3)
                {
                    StartCoroutine(fala.tempoFechar("Ainda falta crianças para resgatar")); // Mostra mensagem dizendo o que faltam
                }
            }
            if(cena.name == "Fase4")
            {
                aliadoSegue niara = FindAnyObjectByType<aliadoSegue>();
                

                if (niara.niaraChegouNoBarco())
                {
                    SceneManager.LoadScene("Final"); 
                } else
                {
                    StartCoroutine(fala.tempoFechar("Ela está aqui ainda, tenho certeza"));
                }
            }
        }
    }
}

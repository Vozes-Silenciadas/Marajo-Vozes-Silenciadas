using UnityEngine;
using System.Collections;
public class InimigoGira : MonoBehaviour
{

    // Configurações para a varredura
    public float anguloInicial = 0;
    public float anguloFinal = -90;

    // Tempo em segundos para completar a varredura
    public float duracao = 2f;
    public float pause = 1f;

    public Transform desenhoVisao; // Referência ao objeto que representa a visão do inimigo
    public CampoVisao campoVisao; // Referência ao script do campo de visão

    void Start()
    {
        desenhoVisao = transform.Find("atordoar");
        desenhoVisao.rotation = Quaternion.Euler(0, 0, anguloInicial);
        InvokeRepeating("Comecar",1,duracao*2+pause*2); // Inicia o ciclo de repetição da varredura 
    }

    void Comecar()
    {
        StartCoroutine(CicloDeVarredura()); 
    }

    IEnumerator CicloDeVarredura()
    {
        yield return StartCoroutine(GirarSuavemente(anguloInicial, anguloFinal, duracao));

        yield return new WaitForSeconds(pause);

        yield return StartCoroutine(GirarSuavemente(anguloFinal, anguloInicial, duracao));

        yield return new WaitForSeconds(pause);
    }
    
    // Coroutine para girar suavemente de um ângulo para outro
    IEnumerator GirarSuavemente(float anguloDe, float anguloPara, float duracao)
    {
        
        float tempoPassado = 0f;
        
        while (tempoPassado < duracao)
        {
            tempoPassado += Time.deltaTime;
            float t = tempoPassado / duracao; // Normaliza o tempo para o intervalo [0, 1]

            float anguloAtual = Mathf.Lerp(anguloDe, anguloPara, t); // Interpola o ângulo atual
            
            desenhoVisao.rotation = Quaternion.Euler(0f, 0f, anguloAtual);

            Vector2 direcaoAtual = AnguloParaVetor(desenhoVisao.eulerAngles.z); // Calcula a direção baseada no ângulo atual
            campoVisao.DirecaoInimigoN(-direcaoAtual);
         
            yield return null; 
        }
        
        desenhoVisao.rotation = Quaternion.Euler(0f, 0f, anguloPara);

        Vector2 direcaoFinal = AnguloParaVetor(desenhoVisao.eulerAngles.z);
        campoVisao.DirecaoInimigoN(-direcaoFinal);
        
    }
    
   
    private Vector2 AnguloParaVetor(float angulo)
    {
        // Ajusta o ângulo para alinhar com o sistema de coordenadas
        float anguloRad = (angulo + 90f) * Mathf.Deg2Rad; 
        
        return new Vector2(Mathf.Cos(anguloRad), Mathf.Sin(anguloRad)).normalized; // Retorna o vetor
    }
}

using UnityEngine;
using System.Collections;
public class InimigoGira : MonoBehaviour
{

    public float anguloInicial = 0;
    public float anguloFinal = -90;
    public float duracao = 2f;
    public float pause = 1f;

    public Transform desenhoVisao;
    public CampoVisao campoVisao;

    void Start()
    {
        desenhoVisao = transform.Find("atordoar");
        desenhoVisao.rotation = Quaternion.Euler(0, 0, anguloInicial);
        InvokeRepeating("Comecar",1,duracao*2+pause*2);
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
    
    IEnumerator GirarSuavemente(float anguloDe, float anguloPara, float duracao)
    {
        float tempoPassado = 0f;
        
        while (tempoPassado < duracao)
        {
            tempoPassado += Time.deltaTime;
            float t = tempoPassado / duracao; 

            float anguloAtual = Mathf.Lerp(anguloDe, anguloPara, t);
            
            desenhoVisao.rotation = Quaternion.Euler(0f, 0f, anguloAtual);

            Vector2 direcaoAtual = AnguloParaVetor(desenhoVisao.eulerAngles.z);
            campoVisao.DirecaoInimigoN(-direcaoAtual);
         
            yield return null; 
        }
        
        desenhoVisao.rotation = Quaternion.Euler(0f, 0f, anguloPara);

        Vector2 direcaoFinal = AnguloParaVetor(desenhoVisao.eulerAngles.z);
        campoVisao.DirecaoInimigoN(-direcaoFinal);
        
    }
    
   
    private Vector2 AnguloParaVetor(float angulo)
    {
        float anguloRad = (angulo + 90f) * Mathf.Deg2Rad; 
        
        return new Vector2(Mathf.Cos(anguloRad), Mathf.Sin(anguloRad)).normalized;
    }
}

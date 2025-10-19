using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    public int vidaStat;
    public int cena;
    public GameObject[] coracoes;
  
    void Start()
    {
        vidaStat = 3;
    }

    void FixedUpdate()
    {
        if (vidaStat <= 0)
        {
            SceneManager.LoadScene(cena);
        }
    }
    
    public void PerderVida()
    {
        Destroy(coracoes[vidaStat-1]);
        
    }
}

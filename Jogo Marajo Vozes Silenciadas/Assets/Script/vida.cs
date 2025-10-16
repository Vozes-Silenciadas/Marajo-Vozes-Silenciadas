using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    public float vidaStat;
    public int cena;

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
}

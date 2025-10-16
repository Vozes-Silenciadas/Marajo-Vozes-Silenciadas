using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpPorta : MonoBehaviour
{
    public int cena;
    public Transform tp;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = tp.position;
            //SceneManager.LoadScene(cena);
        }


    }

}

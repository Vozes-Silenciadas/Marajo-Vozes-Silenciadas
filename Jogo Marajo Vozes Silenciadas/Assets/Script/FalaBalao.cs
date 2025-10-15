using System.Collections;
using TMPro;
using UnityEngine;

public class FalaBalao : MonoBehaviour
{

    public GameObject balaoDeFala;
    public TextMeshProUGUI texto;
   
    public IEnumerator tempoFechar(string fala)
    {
        texto.text = fala;
        balaoDeFala.SetActive(true);
        yield return new WaitForSeconds(3f);
        balaoDeFala.SetActive(false);
    }

   
}

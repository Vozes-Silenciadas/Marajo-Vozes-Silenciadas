using UnityEngine;
using UnityEngine.UI;

public class abaControla : MonoBehaviour
{
    public Image[] abaImage;
    public GameObject[] paginas;

    void Start()
    {
        AtivarAba(0);
    }

    public void AtivarAba(int abaNum)
    {
        for (int i = 0; i < paginas.Length; i++)
        {
            paginas[i].SetActive(false);
            abaImage[i].color = Color.grey;
        }
        paginas[abaNum].SetActive(true);
        abaImage[abaNum].color = Color.white;
    }
}

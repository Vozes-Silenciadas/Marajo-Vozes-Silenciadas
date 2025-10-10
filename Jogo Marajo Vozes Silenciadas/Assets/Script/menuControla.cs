using UnityEngine;

public class menuControla : MonoBehaviour
{

    public GameObject menu;
    static bool jogoPausado = false;

    void Start()
    {
        menu.SetActive(false);
        jogoPausado = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);

            if (jogoPausado)
            {
                Voltar();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        jogoPausado = true;
    }

    void Voltar()
    {
        Time.timeScale = 1;
        jogoPausado = false;
    }
    
    public bool Pausado()
    {
        return jogoPausado;
    }
}

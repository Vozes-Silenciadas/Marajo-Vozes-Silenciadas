using UnityEngine;

public class movEndlessRun : MonoBehaviour
{
    public GameObject[] waypoints;
    public int wayAtual = 0;
    public bool teste;
    menuControla menu;

    void Start()
    {
        transform.position = waypoints[wayAtual].transform.position;
        menu = FindAnyObjectByType<menuControla>();
    }
    void Update()
    {
        if (!menu.Pausado())
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(wayAtual < waypoints.Length-1) wayAtual++;
                transform.position = waypoints[wayAtual].transform.position;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(wayAtual > 0) wayAtual--;
                transform.position = waypoints[wayAtual].transform.position;
            }
        }        
    }
}

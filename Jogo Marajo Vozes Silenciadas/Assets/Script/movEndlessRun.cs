using UnityEngine;

public class movEndlessRun : MonoBehaviour
{
    public GameObject[] waypoints;
    public int wayAtual = 0;
    public bool teste;
    void Start()
    {
        transform.position = waypoints[wayAtual].transform.position;
    }
    void Update()
    {
        //float dirX = Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(wayAtual < waypoints.Length-1) wayAtual++;
            transform.position = waypoints[wayAtual].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(wayAtual > 0) wayAtual--;
            transform.position = waypoints[wayAtual].transform.position;
        }
    }
}

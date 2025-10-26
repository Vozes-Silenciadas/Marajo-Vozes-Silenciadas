using UnityEngine;

public class Scrollvertical : MonoBehaviour
{
    public float vel = 4f;         // Velocidade com que a textura se move
    public Renderer quad;          // Renderer do objeto que possui a textura 

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 offset = new Vector2(0, vel * Time.deltaTime);  // Cria um deslocamento vertical baseado na velocidade e no tempo
        quad.material.mainTextureOffset += offset;             // Aplica o deslocamento à textura, fazendo ela mover
    }
}

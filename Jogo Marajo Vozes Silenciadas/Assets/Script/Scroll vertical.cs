using UnityEngine;

public class Scrollvertical : MonoBehaviour
{
    public float vel = 4f;
    public Renderer quad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, vel * Time.deltaTime);
        quad.material.mainTextureOffset += offset;

    }
}

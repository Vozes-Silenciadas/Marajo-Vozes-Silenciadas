using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Collider2D Collider;
    RaycastHit2D[] hit2Ds = new RaycastHit2D[5];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int Nhits = Collider.Raycast(Vector2.one, hit2Ds);
        if (Nhits > 0)
        {
            Debug.Log("Algo foi detectado");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

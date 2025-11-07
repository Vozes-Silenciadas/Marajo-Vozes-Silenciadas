using UnityEngine;

public class Inimigo_Mov_Reverso : MonoBehaviour
{
    public float dirX;
    public float dirY;
    Rigidbody2D rb;
    public Transform[] pontosPatrulha;
    public CampoVisao sla;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = pontosPatrulha[0].position;
        dirX = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x < pontosPatrulha[2].localPosition.x)
        {
            dirX = 0;
            dirY = 1;
            transform.rotation = Quaternion.Euler(dirX, dirY, 180);
        }
        if (transform.localPosition.y > pontosPatrulha[1].localPosition.y)
        {
            dirX = 1;
            dirY = 0;
            transform.rotation = Quaternion.Euler(dirX, dirY, 90);
        }
        if (transform.localPosition.x > pontosPatrulha[4].localPosition.x)
        {
            dirX = 0;
            dirY = -1;
            transform.rotation = Quaternion.Euler(dirX, dirY, 0);
        }
        if (transform.localPosition.x > pontosPatrulha[0].localPosition.x && transform.localPosition.y > pontosPatrulha[0].localPosition.y)
        {
            dirX = -1;
            dirY = 0;
            transform.rotation = Quaternion.Euler(dirX, dirY, -90);
        }
        sla.DirecaoInimigo(dirX, dirY);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX, dirY);
    }
}

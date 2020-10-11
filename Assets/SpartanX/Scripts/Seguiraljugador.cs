using UnityEngine;

public class Seguiraljugador : MonoBehaviour
{
    float Xoffset;
    public GameObject jugador;
    private void Start()
    {
        Xoffset = transform.position.x;
    }


    void FixedUpdate()
    {   if (jugador.transform.position.x < 0)
        {
            transform.position = new Vector3(Xoffset + jugador.transform.position.x, transform.position.y, transform.position.z);
        }
            
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject prefabCuerpo;

    public List<Transform> ListaDeCuerpo;
    Vector3 direccion;
    float velocity = 0.4f;

    void Start()
    {
        ListaDeCuerpo = new List<Transform> ();
        StartCoroutine("TickTiempo");
        ListaDeCuerpo.Add(transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direccion = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direccion = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direccion = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direccion = Vector3.right;
        }
     
    }

    IEnumerator TickTiempo() ///tiempo movimiento de cabeza por ticks
    {
        while (true)
        {
            for (int i = 0; i < ListaDeCuerpo.Count; i++)
            {
                if (i > 0)
                {
                    Debug.Log("indice: " + (ListaDeCuerpo.Count -i-2) + "    limite:"  + ListaDeCuerpo.Count  );
                    ListaDeCuerpo[ListaDeCuerpo.Count - i].position = ListaDeCuerpo[ListaDeCuerpo.Count - i - 1].position;
                    //Debug.Log("despalza" + ListaDeCuerpo [ListaDeCuerpo.Count - i].name + " a " + ListaDeCuerpo[ListaDeCuerpo.Count - i - 1].name);
                    
                }else
                {
                    ListaDeCuerpo [i].Translate (direccion);
                }
            }
            yield return new WaitForSeconds (velocity);
        }
    }
    //comida colicionador 
    private void OnTriggerStay(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject.name == "Comida")
        {
            Destroy(col.gameObject);
            GameObject nuevoCuerpo = Instantiate(prefabCuerpo, ListaDeCuerpo[ListaDeCuerpo.Count -1 ].position, Quaternion.identity) as GameObject;
            ListaDeCuerpo.Add(nuevoCuerpo.transform);
        }
    }
}

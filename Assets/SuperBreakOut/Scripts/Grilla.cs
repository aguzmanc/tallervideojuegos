using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grilla : MonoBehaviour
{
    public List<Bloque> bloquePrefabs;
    List<Bloque> bLoques = new List<Bloque>();
    int bloquesDestruidos;
    private void Awake()
    {
        int cols = 11;
        int filas = 10;


        var bloquesSize = bloquePrefabs[0].GetComponent<BoxCollider2D>().size;

        var inicio = new Vector3(bloquesSize.x * -(cols / 2), -1, 0);
        float padding = 0.08f;
        bloquesSize += new Vector2(padding, padding);
        for(int fila=0; fila<filas; fila++)
        {
            for (int col=0; col<cols; col++)
            {
                int color = fila / 2;
                var bloque = Instantiate(bloquePrefabs[color]);
                bloque.transform.SetParent(transform);
                bloque.transform.position = new Vector3(col * bloquesSize.x, fila * bloquesSize.y, 0) + inicio;
                bLoques.Add(bloque);
            }
        }
    }
    public void BloqueDestruido()
    {
        bloquesDestruidos++;
        if(bloquesDestruidos == bLoques.Count)
        {
            FindObjectOfType<Pad>().Reset();
            FindObjectOfType<Bola>().Reset();
            Reset();
        }
    }
    public void Reset()
    {
        foreach(var bloque in bLoques)
        {
            bloque.Reset();
        }
    }
}

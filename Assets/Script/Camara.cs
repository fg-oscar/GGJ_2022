using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject Personaje_1;
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Personaje_1.transform.position.x;
        transform.position = pos;

    }
}

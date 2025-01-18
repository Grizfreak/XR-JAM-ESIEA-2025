using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class Conveyor : MonoBehaviour
{
    private float fix = -1.9f;
    public float speed;
    Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 pos = rBody.position;
        rBody.position += Vector3.forward * speed * fix * Time.fixedDeltaTime;
        rBody.MovePosition(pos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public BoxCollider leftBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        DesactivarCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Desactiva los colliders del brazo del enemigo
    public void DesactivarCollider()
    {
        leftBoxCollider.enabled = false;
    }

    //Activa los colliders del brazo del enemigo
    public void ActivarCollider()
    {
        leftBoxCollider.enabled = true;
    }
}

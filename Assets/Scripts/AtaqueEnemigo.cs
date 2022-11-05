using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    
    //public BoxCollider rightBoxCollider;
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
    public void DesactivarCollider()
    {
        //rightBoxCollider.enabled = false;
        leftBoxCollider.enabled = false;
    }
    public void ActivarCollider()
    {
        //rightBoxCollider.enabled = true;
        leftBoxCollider.enabled = true;
    }
}

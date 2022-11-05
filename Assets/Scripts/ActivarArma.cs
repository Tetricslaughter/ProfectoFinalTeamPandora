using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArma : MonoBehaviour
{
    
    private AgarrarArma agarrarArma;
    // Start is called before the first frame update
    void Start()
    {
        agarrarArma = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarArma>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            agarrarArma.ActivateArma();
            Destroy(gameObject);
        }
    }
}

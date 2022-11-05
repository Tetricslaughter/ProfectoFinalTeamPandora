using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPremio : MonoBehaviour
{
    private AgarrarPremio agarrarPremio;
    // Start is called before the first frame update
    void Start()
    {
        agarrarPremio = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarPremio>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            agarrarPremio.ActivatePremio();
            Destroy(gameObject);
        }
    }
}

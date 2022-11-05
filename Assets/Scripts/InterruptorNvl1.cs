using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorNvl1 : MonoBehaviour
{
    [SerializeField]
    private GameObject premio;
    [SerializeField]
    private int interruptorType;
    private Vector3 posPremio;
    private AgarrarPremio agarrarPremio;

    private PuertaBehaviour puertaBehaviour1;

    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        posPremio = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        agarrarPremio = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarPremio>();
        puertaBehaviour1 = GameObject.Find("PuertaNvl1").GetComponent<PuertaBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trofeo") == true)
        {
            Debug.Log("se instancio");
            Instantiate(premio, posPremio, transform.rotation);

            agarrarPremio.DesactivarPremio();

            if (puertaBehaviour1.NumberDoor == 6 && interruptorType == 6)
            {
                puertaBehaviour1.OpenClose();
            }
        }

    }
}

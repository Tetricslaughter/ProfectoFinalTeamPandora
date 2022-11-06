using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarPremio : MonoBehaviour
{
    [SerializeField]
    private GameObject premio;
    [SerializeField]
    private PlayerBehaviour playerBehaviour;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Activa el premio que sujeta el player
    public void ActivatePremio()
    {
        premio.SetActive(true);
    }

    //Desactiva el premio que sujeta el player
    public void DesactivarPremio()
    {
        premio.SetActive(false);
    }
}

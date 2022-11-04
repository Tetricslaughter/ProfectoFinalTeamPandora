using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarArma : MonoBehaviour
{
    [SerializeField]
    private GameObject arma;
    [SerializeField]
    private PlayerBehaviour playerBehaviour;
    private bool tengoArma;
    private bool armaEquipada;

    public BoxCollider armaBoxCollider;
    public BoxCollider punioBoxCollider;
    //public BoxCollider body;
    // Start is called before the first frame update
    void Start()
    {
        DesactivarColliderArmas();
        tengoArma = false;
        armaEquipada = false;
        //body.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tengoArma && Input.GetKeyDown(KeyCode.K))
        {
            if (armaEquipada)
            {
                DesactivarArma();
            }
            else
            {
                ActivateArma();
            }
        }
    }

    public void ActivateArma()
    {
        tengoArma = true;
        arma.SetActive(true);
        armaEquipada = true;

        playerBehaviour.speed = 3f;
        playerBehaviour.conArma = true;
    }

    public void DesactivarArma()
    {
        arma.SetActive(false);
        armaEquipada = false;
        playerBehaviour.speed = 5f;
        playerBehaviour.conArma = false;
    }

    public void DesactivarColliderArmas()
    {
       // body.enabled = true;
        if (armaBoxCollider != null)
        {
            armaBoxCollider.enabled = false;
        }
        punioBoxCollider.enabled = false;
    }
    public void ActivarColliderArmas()
    {
        //body.enabled = true;
        if (playerBehaviour.conArma)
        {
            if (armaBoxCollider != null)
            {
                armaBoxCollider.enabled = true;
            }
        }
        else
        {
            punioBoxCollider.enabled = true;
        }
    }
}

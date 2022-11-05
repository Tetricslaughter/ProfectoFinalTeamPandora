using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarPremio : MonoBehaviour
{
    [SerializeField]
    private GameObject premio;
    [SerializeField]
    private PlayerBehaviour playerBehaviour;
    private bool tengoPremio;
    private bool premioEquipado;

  //  public BoxCollider premioBoxCollider;
    //public BoxCollider punioBoxCollider;
    //public BoxCollider body;
    // Start is called before the first frame update
    void Start()
    {
       // DesactivarColliderPremios();
        tengoPremio = false;
        premioEquipado = false;
        //body.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tengoPremio && Input.GetKeyDown(KeyCode.C))
        {
            if (premioEquipado)
            {
                DesactivarPremio();
            }
            else
            {
                ActivatePremio();
            }
        }
    }

    public void ActivatePremio()
    {
        tengoPremio = true;
        premio.SetActive(true);
        premioEquipado = true;

        //playerBehaviour.speed = 3f;
        //playerBehaviour.conArma = true;
    }

    public void DesactivarPremio()
    {
        premio.SetActive(false);
        premioEquipado = false;
     //   playerBehaviour.speed = 5f;
       // playerBehaviour.conArma = false;
    }

   /* public void DesactivarColliderArmas()
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
    }*/
}

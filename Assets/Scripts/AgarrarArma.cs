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
    // Start is called before the first frame update
    void Start()
    {
        DesactivarColliderArmas();//se desactivan los boxColliders del puño y de la espada
        tengoArma = false;      //al iniciar la escena el player no tiene un arma
        armaEquipada = false;   //por lo tanto tampoco la tendria equipada
        
    }

    // Update is called once per frame
    void Update()
    {
        //este if sirve para equiparse y desaquiparse el arma cuando se apreta la tecla especificada
        if (tengoArma && Input.GetKeyDown(KeyCode.K)) //también como condición tiene que antes se tendria que haber agarrado un arma
        {
            if (armaEquipada)       //evalúa si tiene o no equipada el arma
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
        arma.SetActive(true);   //activa el arma del player
        armaEquipada = true;

        playerBehaviour.speed = 3f;     //disminuye la velocidad del player para aparentar que el arma es pesada y le cuesta moverse
        playerBehaviour.conArma = true; //cambia el estado de una variable correspondiente al Script PlayerBehaviour
    }

    public void DesactivarArma()
    {
        arma.SetActive(false);              //desactiva el arma del player
        armaEquipada = false;
        playerBehaviour.speed = 5f;         //aumenta la velocidad del player
        playerBehaviour.conArma = false;
    }

    //Desactiva los colliders del puño y de la espada
    public void DesactivarColliderArmas()
    {
        if (armaBoxCollider != null)
        {
            armaBoxCollider.enabled = false;
        }
        punioBoxCollider.enabled = false;
    }

    //Activa los colliders del puño y de la espada
    public void ActivarColliderArmas()
    {
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

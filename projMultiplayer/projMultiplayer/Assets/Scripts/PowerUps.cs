using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PowerUps : NetworkBehaviour
{   
    public enum DeBuffType
    {
        Lentidao,
        AumentoDePeso,
        DiminuicaoDePulo,
        LimitarCampoVisao,
        InverterControles,
        Banana,
        BloquearAtaque
    };
    public DeBuffType tipoDeBuff;
    float velDeslize = 100;

    public float massa;
    public float forcaPuloDebuff;
    public float velocidadeDebuff;
    public bool ataqueBloqueado;

    void Start()
    {
        
    }

    void Update()
    {
        if (tipoDeBuff == DeBuffType.AumentoDePeso)
        {
            massa = 2f;
            forcaPuloDebuff = 2f;
        }

        else if (tipoDeBuff == DeBuffType.Lentidao)
        {
            velocidadeDebuff = 2f;
        }

        else if (tipoDeBuff == DeBuffType.DiminuicaoDePulo)
        {
            forcaPuloDebuff = 0.5f;
        }

        else if (tipoDeBuff == DeBuffType.LimitarCampoVisao)
        {
            //colidiu.GetComponent<PlayerController>().telaSuja.SetActive(true);
        }

        else if (tipoDeBuff == DeBuffType.InverterControles)
        {
            velocidadeDebuff = -0.5f;
        }

        else if (tipoDeBuff == DeBuffType.BloquearAtaque)
        {
            ataqueBloqueado = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (tipoDeBuff == DeBuffType.Banana)
            {
                collision.gameObject.GetComponent<PlayerController>().podeAndar = false;
                Vector3 direction = (transform.position - collision.gameObject.transform.position).normalized;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(direction * velDeslize, ForceMode.Impulse);
            }

            Destroy(gameObject);
        }
    }
}

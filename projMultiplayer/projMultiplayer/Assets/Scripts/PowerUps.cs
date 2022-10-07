using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
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

    GameObject colidiu;
    float velDeslize = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            colidiu = collision.gameObject;

            if (tipoDeBuff == DeBuffType.AumentoDePeso)
            {
                collision.gameObject.GetComponent<Rigidbody>().mass = 2f;
                collision.gameObject.GetComponent<PlayerController>().forcaPuloDeBuff = 2f;
                colidiu.GetComponent<PlayerController>().tempo = 0;
            }

            else if (tipoDeBuff == DeBuffType.Lentidao) 
            {
                collision.gameObject.GetComponent<PlayerController>().velocidadeDeBuff = 0.5f;
                colidiu.GetComponent<PlayerController>().tempo = 0;
            }

            else if (tipoDeBuff == DeBuffType.DiminuicaoDePulo)
            {
                collision.gameObject.GetComponent<PlayerController>().forcaPuloDeBuff = 0.5f;
                colidiu.GetComponent<PlayerController>().tempo = 0;
            }

            else if (tipoDeBuff == DeBuffType.LimitarCampoVisao)
            {
                colidiu.GetComponent<PlayerController>().tempo = 0;
                colidiu.GetComponent<PlayerController>().telaSuja.SetActive(true);
            }

            else if (tipoDeBuff == DeBuffType.InverterControles)
            {
                collision.gameObject.GetComponent<PlayerController>().velocidadeDeBuff = -0.5f;
                colidiu.GetComponent<PlayerController>().tempo = 0;
            }

            else if (tipoDeBuff == DeBuffType.Banana)
            {
                colidiu.GetComponent<PlayerController>().podeAndar = false;
                Vector3 direction = (transform.position - colidiu.transform.position).normalized;
                colidiu.GetComponent<Rigidbody>().AddForce(direction * velDeslize, ForceMode.Impulse);
                colidiu.GetComponent<PlayerController>().tempo = 0;
            }

            else if (tipoDeBuff == DeBuffType.BloquearAtaque) 
            {
                collision.gameObject.GetComponent<PlayerController>().ataqueBloqueado = false;
                colidiu.GetComponent<PlayerController>().tempo = 0;
            }

            Destroy(gameObject);
        }
    }
}

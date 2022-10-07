using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimentação")]
    public float movX;
    public float movZ;
    public float velocidade;
    public float forca_Pulo;
    public bool podePular;

    [Header("DeBuffs")]
    public bool ataqueBloqueado;
    public bool podeAndar;
    public float velocidadeDeBuff = 1f;
    public float forcaPuloDeBuff = 1f;
    public float tempo;
    public float tempoLimite;
    public GameObject telaSuja;

    [Header("Combat")]
    [SerializeField] KeyCode AttackButton;
    [SerializeField] float KnockbackStrenght;

    public Rigidbody rigbd;
    void Start()
    {
        rigbd = GetComponent<Rigidbody>();
        ataqueBloqueado = false;
        podeAndar = true;
        tempo = -1;
        telaSuja.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tempo >= 0f && tempo <= tempoLimite) tempo += Time.deltaTime;

        if (tempo >= 0.8)
        {
            podeAndar = true;
            tempo = -1;
        }

        if (tempo >= tempoLimite)
        {
            rigbd.mass = 1;
            ataqueBloqueado = true;
            telaSuja.SetActive(false);
            velocidadeDeBuff = 1f;
            forcaPuloDeBuff = 1f;
            tempo = -1;
        }

        if (gameObject.tag == "Player1")
        {
            movX = Input.GetAxis("Horizontal1");
            movZ = Input.GetAxis("Vertical1");

            if (Input.GetKeyDown(KeyCode.Space) && podePular)
            {
                rigbd.AddForce(Vector3.up * forca_Pulo * forcaPuloDeBuff, ForceMode.Impulse);
            }
        }

        if (gameObject.tag == "Player2")
        {
            movX = Input.GetAxis("Horizontal2");
            movZ = Input.GetAxis("Vertical2");

            if (Input.GetKeyDown(KeyCode.KeypadEnter) && podePular)
            {
                rigbd.AddForce(Vector3.up * forca_Pulo * forcaPuloDeBuff, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        if (podeAndar == true)
        {
            rigbd.velocity = new Vector3
            (
                (transform.forward.x * movZ) * velocidade * velocidadeDeBuff,
                rigbd.velocity.y,
                (transform.forward.z * movZ) * velocidade * velocidadeDeBuff
            );

            transform.Rotate(new Vector3(0, movX, 0) * velocidade);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Arena")
        {
            podePular = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Arena")
        {
            podePular = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(AttackButton) && ataqueBloqueado == false)
        {
            if (other.TryGetComponent<PlayerController>(out PlayerController player))
                player.GetDamage(transform.position);
        }
    }

    public void GetDamage(Vector3 strikerPosition)
    {
        Vector3 direction = ((strikerPosition - transform.position) * -1).normalized;
        rigbd.AddForce(direction * KnockbackStrenght, ForceMode.Impulse);
    }
}

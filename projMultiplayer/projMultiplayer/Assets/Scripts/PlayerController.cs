using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movX;
    public float movZ;
    public float velocidade;
    public float forca_Pulo;
    public bool podePular1;
    public bool podePular2;

    [Header("Combat")]
    [SerializeField] KeyCode AttackButton;
    [SerializeField] float KnockbackStrenght;

    public Rigidbody rigbd;
    void Start()
    {
        rigbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player1")
        {
            movX = Input.GetAxis("Horizontal1");
            movZ = Input.GetAxis("Vertical1");

            if (Input.GetKeyDown(KeyCode.Space) && podePular1)
            {
                rigbd.AddForce(Vector3.up * forca_Pulo * PowerUps.forcaPuloDeBuff, ForceMode.Impulse);
            }
        }

        if (gameObject.tag == "Player2")
        {
            movX = Input.GetAxis("Horizontal2");
            movZ = Input.GetAxis("Vertical2");

            if (Input.GetKeyDown(KeyCode.KeypadEnter) && podePular2)
            {
                rigbd.AddForce(Vector3.up * forca_Pulo, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        rigbd.velocity = new Vector3
        (
            (transform.forward.x * movZ) * velocidade * PowerUps.velocidadeDeBuff, 
            rigbd.velocity.y,
            (transform.forward.z * movZ) * velocidade * PowerUps.velocidadeDeBuff
        );

        transform.Rotate(new Vector3(0, movX, 0) * velocidade);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Arena")
        {
            if (gameObject.tag == "Player1") 
            {
                podePular1 = true; 
            }
            if (gameObject.tag == "Player2") 
            {
                podePular2 = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Arena")
        {
            if (gameObject.tag == "Player1")
            {
                podePular1 = false;
            }
            if (gameObject.tag == "Player2")
            {
                podePular2 = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(AttackButton) && PowerUps.ataqueBloqueado == false)
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

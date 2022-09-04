using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porrada : MonoBehaviour
{
    [SerializeField] Collider IgnorableCollider;
    [SerializeField] KeyCode AttackButton;

    Rigidbody Rigidbody;

    [SerializeField] float KnockbackStrenght;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Teste 1");
        if (other != IgnorableCollider)
        {
            Debug.Log("Teste 2");
            if (Input.GetKey(AttackButton))
            {
                Debug.Log("Teste 3");
                if (other.TryGetComponent<Porrada>(out Porrada porrada)) porrada.GetDamage(transform.parent.position);
            }
        }
    }

    public void GetDamage(Vector3 strikerPosition)
    {
        Debug.Log("Teste 4");
        Vector3 direction = (strikerPosition + transform.parent.position).normalized;
        transform.parent.GetComponent<Rigidbody>().AddForce(direction * KnockbackStrenght, ForceMode.Impulse); 
    }
}

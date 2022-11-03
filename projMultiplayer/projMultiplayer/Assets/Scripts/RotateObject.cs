using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class RotateObject : MonoBehaviour
{
    [SerializeField] Vector3 euler;
    public float force;

    void Update()
    {
        transform.Rotate(euler * force);
    }
}

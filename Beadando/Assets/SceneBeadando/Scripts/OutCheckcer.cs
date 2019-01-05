using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCheckcer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WallCube"))
        {
            Destroy(other.gameObject);
        }
        else
        {
            other.transform.position = Vector3.zero + new Vector3(0, 1, 0);
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }       
    }
}
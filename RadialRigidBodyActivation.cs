using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialRigidBodyActivation : MonoBehaviour {
    public LayerMask activationLayer;
    public int radius = 5;
    public int speed = 5;
    private void OnEnable()
    {
        var colliders = Physics.OverlapSphere(transform.position,radius,activationLayer.value);
        foreach(Collider col in colliders)
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            float dist = Vector3.Distance(transform.position,col.gameObject.transform.position);
            StartCoroutine(ActivateRigidBody(rb,dist/speed));
        }
    }
    IEnumerator ActivateRigidBody(Rigidbody rb,float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false;
    }
}

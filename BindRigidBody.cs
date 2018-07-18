using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindRigidBody : MonoBehaviour {
    public LayerMask rigidlayer;
    public float breakForce = Mathf.Infinity;
    public float breakTorque = Mathf.Infinity;

    private void Awake()
    {
        var colliders = Physics.OverlapSphere(transform.position, transform.localScale.x / 2, rigidlayer);
        for(int i=0;i<colliders.Length-1;++i)
        {
            FixedJoint joint = colliders[i].gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = colliders[i + 1].gameObject.GetComponent<Rigidbody>();
            joint.breakForce = breakForce;
            joint.breakTorque = breakTorque;
        }
        Destroy(gameObject);
    }
}

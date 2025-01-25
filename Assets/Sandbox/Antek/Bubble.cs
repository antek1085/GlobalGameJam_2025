using System;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private ConfigurableJoint _fixedJoint;
    private Rigidbody _rigidbody;
    private bool isAttached;
    public float powerOfFloat;
    [SerializeField] SphereCollider _collider;
    void Awake()
    {
        _fixedJoint = GetComponent<ConfigurableJoint>();
        _rigidbody = GetComponent<Rigidbody>();
        isAttached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttached == true)
        {
            _rigidbody.AddForce(0,powerOfFloat,0,ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            _fixedJoint.connectedBody = other.GetComponent<Rigidbody>();
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _rigidbody.useGravity = false;
            isAttached = true;
            _fixedJoint.connectedAnchor = other.ClosestPoint(gameObject.transform.position);
            _fixedJoint.xMotion = ConfigurableJointMotion.Locked;
            _fixedJoint.yMotion = ConfigurableJointMotion.Locked;
            _fixedJoint.zMotion = ConfigurableJointMotion.Locked;
            _collider.enabled = false;
            
        }
        else if (other.tag != "Bubble")
        {
            transform.GetChild(0).SetParent(null);
            GetComponent<OnBubblePop>().PlayOnDestroy();
            Destroy(this.gameObject);
        }
    }
}

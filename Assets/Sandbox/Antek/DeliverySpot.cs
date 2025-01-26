using System;
using UnityEngine;

public class DeliverySpot : MonoBehaviour
{
    [SerializeField] private GameObject objectToDeliver;
    [SerializeField] private int numberOfPoints;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == objectToDeliver.tag)
        {
            Destroy(other.gameObject);
            GetComponent<Collider>().isTrigger = false;
            DeliveryObject();
        }
    }

    private void DeliveryObject()
    {
      var spawnedObject =  Instantiate(objectToDeliver, transform.position, transform.rotation);
      spawnedObject.GetComponent<Rigidbody>().useGravity = false;
      spawnedObject.GetComponent<Rigidbody>().detectCollisions = false;
      GetComponentInParent<PointsController>().addPoints(numberOfPoints);
      GetComponent<Light>().enabled = false;
    }
}

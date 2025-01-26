using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Random = UnityEngine.Random;

public class RatMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] GameObject plane;
    private Mesh planeMesh;
    Bounds bounds;
    public bool isPickedUp = false;

    private void Awake()
    {
        planeMesh = plane.GetComponent<MeshFilter>().mesh;
        navMeshAgent = GetComponent<NavMeshAgent>();
        bounds = planeMesh.bounds;
    }

    void Update()
    {
        if(isPickedUp) return;
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            setRatDestination();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            Destroy(other.gameObject);
        }
    }

    void setRatDestination()
    {
        float minX = plane.transform.position.x - plane.transform.localScale.x * bounds.size.x * 0.5f;
        float minZ = plane.transform.position.z - plane.transform.localScale.z * bounds.size.z * 0.5f;
        
        Vector3 newDestination = new Vector3(Random.Range(minX, -minX), plane.transform.position.y, Random.Range(minZ, -minZ));
        
        navMeshAgent.SetDestination(newDestination);
    }

    public void OnPickUp()
    {
        isPickedUp = true;
        navMeshAgent.isStopped = true;
        navMeshAgent.enabled = false;
    }

    public void OnDrop()
    {
        StartCoroutine(AliveRat());
    }

    IEnumerator  AliveRat()
    {
        GetComponent<XRGrabInteractable>().enabled = false;
        yield return new WaitForSeconds(4f);
        GetComponent<XRGrabInteractable>().enabled = true;
        navMeshAgent.enabled = true;
        navMeshAgent.isStopped = false;
        isPickedUp = false;
    }
}

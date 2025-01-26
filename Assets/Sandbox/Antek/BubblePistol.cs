using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class BubblePistol : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float force;
    public HapticImpulsePlayer xrHapticImpulsePlayer;
    private GameObject spawnedObject;
    [SerializeField] private GameObject Fan;

    public bool isGrowing;

    private void Awake()
    {
        isGrowing = false;
    }

    private void FixedUpdate()
    {
        if (isGrowing && spawnedObject != null) 
        {
            spawnedObject.transform.localScale += new Vector3(0.1f,0.1f,0.1f) * Time.deltaTime;
            spawnedObject.GetComponent<Bubble>().powerOfFloat += 0.02f;
            xrHapticImpulsePlayer.SendHapticImpulse(0.3f, 0.2f,10);
        }
    }

    private void Update()
    {
        if (isGrowing && spawnedObject != null)
        {
           Fan.transform.Rotate(0,0,100);
        }

        
    }

    public void SpawnBubble()
    {
        spawnedObject = Instantiate(bubble, spawnPoint.position, Quaternion.Euler(0,0,0));
        isGrowing = true;
        spawnedObject.GetComponent<Rigidbody>().useGravity = false;
        spawnedObject.transform.SetParent(gameObject.transform);
    }

    public void CastBubble()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.SetParent(null);
            spawnedObject.GetComponent<Rigidbody>().useGravity = true;
            spawnedObject.GetComponent<Rigidbody>().AddForce(spawnPoint.up * -1* force);
            isGrowing = false;   
            
        }
    }
}

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

    private void Awake()
    {
    }

    public void SpawnBubble()
    {
        GameObject spawnedBubble = Instantiate(bubble, spawnPoint.position, Quaternion.Euler(0,0,0));
        spawnedBubble.GetComponent<Rigidbody>().AddForce(spawnPoint.up * -1* force);
        xrHapticImpulsePlayer.SendHapticImpulse(1, 0.2f);
    }
}

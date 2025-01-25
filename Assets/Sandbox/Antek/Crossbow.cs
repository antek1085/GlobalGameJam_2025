using UnityEngine;

public class Crossbow : MonoBehaviour
{
    [SerializeField] private GameObject bolt;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float force;

    void ShootVolt()
    {
        var spawnedObject = Instantiate(bolt, spawnPoint.position, Quaternion.Euler(0, 0, 0));
        spawnedObject.GetComponent<Rigidbody>().AddForce(spawnPoint.up * -1 * force);
    }
}

using UnityEngine;

public class Crossbow : MonoBehaviour
{
    [SerializeField] private GameObject bolt;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject rotationOfBold;
    [SerializeField] private float force;

    public void ShootVolt()
    {
        var spawnedObject = Instantiate(bolt, spawnPoint.position, rotationOfBold.transform.rotation);
        spawnedObject.GetComponent<Rigidbody>().AddForce(spawnPoint.up * -1 * force);
    }
}

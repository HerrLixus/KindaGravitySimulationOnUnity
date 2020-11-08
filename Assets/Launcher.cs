using UnityEngine;

public class Launcher : MonoBehaviour
{
    public float force;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Impulse);
    }
}

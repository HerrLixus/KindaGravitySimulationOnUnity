using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    List<GameObject> Affectors = new List<GameObject>();
    
    public Rigidbody Rigid;
    private float distance;
    private float other_mass;
    private float power;

    private void OnTriggerEnter(Collider other)
    {
        Affectors.Add(other.gameObject);
    }
    
    private void OnTriggerExit(Collider other)
    {
        Affectors.Remove(other.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Affectors != null) {
            foreach (var affector in Affectors)
            {
                distance = Vector3.Distance(transform.position, affector.transform.position);
                other_mass = affector.GetComponent<Rigidbody>().mass;
                power = 6.67430f * (other_mass * Rigid.mass) / Mathf.Pow(distance, 2);
                Rigid.AddForce((affector.transform.position - transform.position).normalized * power, ForceMode.Force);
            }
        }
    }
}

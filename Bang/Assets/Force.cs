using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public void AddForce(List<Cube> cubes, float force)
    {
        foreach (Cube explorableCube in cubes)
        {
            Rigidbody rigitBody = explorableCube.GetComponent<Rigidbody>();
            rigitBody.AddExplosionForce(force, transform.position, transform.localScale.x);
        }
    }

    public void AddExplosion(List<Rigidbody> cubes, float force, float radius)
    {
        foreach (Rigidbody explorableObject in cubes)
        {
            explorableObject.AddExplosionForce(force, transform.position, radius);
        }
    }
}

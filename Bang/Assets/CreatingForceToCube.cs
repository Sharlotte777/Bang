using System.Collections.Generic;
using UnityEngine;

public class CreatingForceToCube : MonoBehaviour
{
    public void AddForce(List<Cube> cubes, float force)
    {
        foreach (Cube explorableCube in cubes)
        {
            Rigidbody rigitBody = explorableCube.GetComponent<Rigidbody>();
            rigitBody.AddExplosionForce(force, transform.position, transform.localScale.x);
        }
    }
}

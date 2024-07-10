using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerOfExplosion : MonoBehaviour
{
    [SerializeField] private Force _addingForce = null;
    [SerializeField] private float _force;
    private float _radius = 100f;


    public float ReturnDifference(Vector3 sizeOfCube)
    {
        Vector3 startingSize = new Vector3(1.00f, 1.00f, 1.00f);
        Vector3 vectorDifference = startingSize - sizeOfCube;
        float difference = vectorDifference.x;
        return difference;
    }

    public void CreateExplosion(float difference, List<Rigidbody> cubes)
    {
        int multiplier = 10;
        difference *= multiplier;
        _addingForce.AddExplosion(cubes, _force + difference, _radius + difference);
    }
}

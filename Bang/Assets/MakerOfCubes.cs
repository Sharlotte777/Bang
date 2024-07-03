using System.Collections.Generic;
using UnityEngine;

public class MakerOfCubes : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _force;

    private List<Rigidbody> GetExplorableCubes()
    {
        Collider[] hits = Physics.OverlapBox(transform.position, transform.localScale);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }

    private void OnEnable()
    {
        _prefab.Divided += CreateCubes;
    }

    private void OnDisable()
    {
        _prefab.Divided -= CreateCubes;
    }

    private void CreateCubes(Cube cube)
    {
        int minNumberOfCubes = 2;
        int maxNumberOfCubes = 6;
        int numberOfCubes = Random.Range(minNumberOfCubes, maxNumberOfCubes + 1);

        for (int i = 0; i <= numberOfCubes; i++)
        {
            Cube newCube = Instantiate(cube, transform.position, Quaternion.identity);
            newCube.Authorization();

            foreach (Rigidbody explorableCube in GetExplorableCubes())
            {
                explorableCube.AddExplosionForce(_force, transform.position, transform.localScale.x);
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class MakerOfCubes : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _force;
    [SerializeField] private Force _addingForce = null;

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
        List<Cube> cubes = new List<Cube>();
        int minNumberOfCubes = 2;
        int maxNumberOfCubes = 6;
        int numberOfCubes = Random.Range(minNumberOfCubes, maxNumberOfCubes + 1);

        for (int i = 0; i < numberOfCubes; i++)
        {
            Cube newCube = Instantiate(cube, transform.position, Quaternion.identity);
            newCube.Init();
            cubes.Add(newCube);
        }

        _addingForce.AddForce(cubes, _force);
    }
}

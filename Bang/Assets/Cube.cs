using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceOfSeparation = 100;
    [SerializeField] private MakerOfExplosion _makerOfExplosion = null;
    [SerializeField] private float _radious = 25f;
    private int _numberOfDecrease = 2;
    private Material _material;
    private float _difference = 0;

    public event Action<Cube> Divided;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnMouseUpAsButton()
    {
        TryDivide();
        Destroy(gameObject);
    }

    public void Authorization()
    {
        ReduceSeparateChance();
        CreateScale();
        CreateColor();
    }

    public void TryDivide()
    {
        int minChanceOfSeparation = 0;
        int maxChanceOfSeparation = 100;

        float probability = Random.Range(minChanceOfSeparation, maxChanceOfSeparation + 1);

        if (_chanceOfSeparation >= probability)
        {
            Divided?.Invoke(this);
        }
        else
        {
            _makerOfExplosion.CreateExplosion(_difference, GetExplodableObjects());
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        _difference = _makerOfExplosion.ReturnDifference(transform.localScale);

        Collider[] hits = Physics.OverlapSphere(transform.position, _radious);

        List <Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }

    private void ReduceSeparateChance()
    {
        int reduceNumber = 2;

        _chanceOfSeparation /= reduceNumber;
    }

    private void CreateScale()
    {
        transform.localScale /= _numberOfDecrease;
    }

    private void CreateColor()
    {
        _material.color = Random.ColorHSV();
    }
}

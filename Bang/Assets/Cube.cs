using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    public event Action<Cube> Divided;

    private int _chanceOfSeparation = 100;
    private int _numberOfDecrease = 2;
    private Material _material;
    private Rigidbody _rigidbody;

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

        float probability = UnityEngine.Random.Range(minChanceOfSeparation, maxChanceOfSeparation + 1);

        if (_chanceOfSeparation >= probability)
        {
            Divided?.Invoke(this);
        }
    }

    private void OnMouseUpAsButton()
    {
        TryDivide();
        Destroy(gameObject);
    }

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _rigidbody = GetComponent<Rigidbody>();
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
        _material.color = UnityEngine.Random.ColorHSV();
    }
}

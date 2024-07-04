using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceOfSeparation = 100;
    private int _numberOfDecrease = 2;
    private Material _material;

    public event Action<Cube> Divided;

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
    }

    private void OnMouseUpAsButton()
    {
        TryDivide();
        Destroy(gameObject);
    }

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
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

﻿using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class GraveyardMono : MonoBehaviour
{
    public float2 FieldDimensions;
    public int NumberToSpawn;
    public GameObject TombstonePrefab;
    public uint RandomSeed;
}

public class GraveyardBaker : Baker<GraveyardMono>
{
    public override void Bake(GraveyardMono authoring)
    {
        AddComponent(new GraveyardProperties
        {
            FieldDimensions = authoring.FieldDimensions,
            NumberToSpawn = authoring.NumberToSpawn,
            TombstonePrefab = GetEntity(authoring.TombstonePrefab)
        });
        AddComponent(new GraveyardRandom
        {
            Value = Random.CreateFromIndex(authoring.RandomSeed)
        });
    }
}
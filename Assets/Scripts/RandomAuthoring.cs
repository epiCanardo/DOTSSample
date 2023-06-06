using UnityEngine;
using Unity.Entities;

public class RandomAuthoring : MonoBehaviour
{
}

public class RandomBaker : Baker<RandomAuthoring>
{
    public override void Bake(RandomAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new RandomComponent { rnd = new Unity.Mathematics.Random(1) });
    }
}
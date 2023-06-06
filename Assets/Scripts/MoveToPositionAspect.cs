using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity entity; // un seul possible
    
    private readonly RefRW<LocalTransform> transform;
    private readonly RefRO<Speed> speed;
    private readonly RefRW<TargetPosition> targetPosition;

    public void Move(float deltaTime, Unity.Mathematics.Random rnd)
    {
        float3 direction = math.normalize(targetPosition.ValueRW.value - transform.ValueRW.Position);
        transform.ValueRW.Position += direction * deltaTime * speed.ValueRO.value;

        float reachedTargetDistance = .5f;
        if (math.distance(transform.ValueRW.Position, targetPosition.ValueRW.value) < reachedTargetDistance)
            targetPosition.ValueRW.value = GetRandomPosition(rnd);      

    }

    private float3 GetRandomPosition(Unity.Mathematics.Random rnd)
    {
        return new float3(rnd.NextFloat(0, 15f), 1, rnd.NextFloat(0, 15f));
    }
}

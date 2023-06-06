using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        // main thread, nestable
        foreach ((RefRW<LocalTransform> transform, Speed speed) in SystemAPI.Query<RefRW<LocalTransform>, Speed>())
        {
            transform.ValueRW.Position += new Unity.Mathematics.float3(SystemAPI.Time.DeltaTime * speed.value, 0, 0);
        }

        // distributed threads, non nestable
        //Entities.ForEach((ref LocalTransform transform) => 
        //{
        //     transform.Position += new Unity.Mathematics.float3(SystemAPI.Time.DeltaTime, 0, 0);
        //}).ScheduleParallel();
    }
}
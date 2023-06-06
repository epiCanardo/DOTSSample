using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.VisualScripting;

public partial class MovingSystemBase : SystemBase
{
    protected override void OnUpdate()
    {
        // main thread, nestable
        foreach (MoveToPositionAspect moveAspect in SystemAPI.Query<MoveToPositionAspect>())
        {
            moveAspect.Move(SystemAPI.Time.DeltaTime, SystemAPI.GetSingleton<RandomComponent>().rnd);
        }

        // distributed threads, non nestable
        //Entities.ForEach((ref LocalTransform transform) => 
        //{
        //     transform.Position += new Unity.Mathematics.float3(SystemAPI.Time.DeltaTime, 0, 0);
        //}).ScheduleParallel();
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CarMoveSystem : ComponentSystem
{
    private EntityQuery _query;

    protected override void OnCreate()
    {
        _query = GetEntityQuery(ComponentType.ReadOnly<CarSpeed>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_query).ForEach((Entity entity, Transform transform, CarSpeed carSpeed) =>
        {
            var car = transform.position;
            car.z -= carSpeed._speed/100;
            transform.position = car;
        });
    }
}

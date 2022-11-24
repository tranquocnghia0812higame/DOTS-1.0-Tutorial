using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class CameraMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var brainEntity = SystemAPI.GetSingletonEntity<BrainTag>();
        var brainScale = SystemAPI.GetComponent<LocalToWorldTransform>(brainEntity).Value.Scale;

        var cameraSingleton = CameraMono.Instance;
        if (!cameraSingleton) return;
        var positionFactor =(float) SystemAPI.Time.ElapsedTime * cameraSingleton.Speed;
        var height = cameraSingleton.HeightAtScale(brainScale);
        var radius = cameraSingleton.RadiusAtScale(brainScale);

        cameraSingleton.transform.position = new Vector3
        {
            x = Mathf.Cos(positionFactor) * radius,
            y = height,
            z = Mathf.Sin(positionFactor)* radius
        };
        cameraSingleton.transform.LookAt(Vector3.zero, Vector3.up);
    }
}



using UniRx;
using UnityEngine;

public class ConstantSpeedMover : AMover
{
    public override void Move(Vector3 speed, float time)
    {
        _world.Position -= speed * time;
    }

    public ConstantSpeedMover(IWorld world) : base(world)
    {
    }
}

public interface IControl
{
    IObservable<Unit> Jump { get; }
}
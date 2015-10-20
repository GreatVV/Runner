using UnityEngine;

public class ConstantSpeedMover : IMover
{
    private IWorld _world;

    public void Move(IWorld world)
    {
        _world = world;
    }

    public void MoveOn(Vector3 speed, float time)
    {
        _world.Position += speed * time;
    }
}
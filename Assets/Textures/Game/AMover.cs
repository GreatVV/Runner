using System;
using UniRx;
using UnityEngine.Assertions.Must;

public abstract class AMover
{
    protected IWorld _world;

    protected AMover(IWorld world)
    {
        world.MustNotBeNull();
        _world = world;
    }
}
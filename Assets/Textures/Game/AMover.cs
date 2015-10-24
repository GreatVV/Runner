using System;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions.Must;

public abstract class AMover
{
    protected IWorld _world;

    protected AMover(IWorld world)
    {
        world.MustNotBeNull();
        _world = world;
    }

    public abstract void Move(Vector3 speed, float time);
}
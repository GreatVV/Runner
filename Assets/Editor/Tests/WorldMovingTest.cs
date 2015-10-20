using NSubstitute;
using NUnit.Framework;
using UniRx;
using UnityEngine;

[TestFixture]
public class WorldMovingTest
{
    [Test]
    public void WorldMove()
    {
        var expectedMove = new Vector3(5, 0, 0);
        var world = GetSimpleWorld();
        var mover = GetMover();




    }

    private IMover GetMover()
    {
        return new ConstantSpeedMover();
    }

    private IWorld GetSimpleWorld()
    {
        return new World();
    }
}

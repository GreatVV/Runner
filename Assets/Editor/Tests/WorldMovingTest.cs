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
        var expectedPosition = new Vector3(-10, 0, 0);
        var move = new Vector3(5, 0, 0);
        var world = GetTestWorld(); 
        var mover = new ConstantSpeedMover(world);
        mover.Move(move, 2);
        Assert.AreEqual(expectedPosition, world.Position);
    }

    private static World GetTestWorld()
    {
        return new GameObject("TestWorld", typeof(World)).GetComponent<World>();
    }

    [Test]
    public void CharacterJumpTest()
    {
        var world = GetTestWorld();
        var mover = new ConstantSpeedMover(world);
        mover.Move(new Vector3(5,0,0), 1f);
        var playerControl = Substitute.For<IControl>();
        playerControl.Jump.Returns(Observable.Return(Unit.Default));
        var character = new Character(playerControl);


    }

    
}

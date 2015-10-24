using UniRx;
using UnityEngine;

public interface ICharacter
{
    IObservable<Vector2> Position { get; }
    IObservable<Unit> Jump();
}
using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class Game : MonoBehaviour,IGame
{
    [Inject]
    private AMover mover;

    [Inject]
    private IControl control;

    [Inject]
    private ICharacter character;

    public Vector3 Speed = new Vector3(10, 0, 0);

    private CompositeDisposable subscriptions = new CompositeDisposable();

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        gameObject.UpdateAsObservable().Select(_ => Time.deltaTime).Subscribe(delta => mover.Move(Speed, delta)).AddTo(subscriptions);
        control.Jump.Subscribe(_ => character.Jump().Subscribe()).AddTo(subscriptions);
    }

    public void EndGame()
    {
        subscriptions.Clear();
    }
}
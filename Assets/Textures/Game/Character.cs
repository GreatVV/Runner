using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Character : MonoBehaviour, ICharacter
{
    private readonly IControl _control;

    public float MaxY = 5;
    public float JumpTime = 5;
    

    public Character(IControl control)
    {
        control.MustNotBeNull();
        _control = control;
    }

    public IObservable<Vector2> Position
    {
        get
        {
            return this.UpdateAsObservable().Select(_ => (Vector2)transform.position);
        }
    }

    private bool isJump;

    public IObservable<Unit> Jump()
    {
        if (isJump)
        {
            return Observable.Empty<Unit>();
        }
        
        return Observable.Create<Unit>
            (
             observer =>
             {
                 isJump = true;
                    var startPosition = transform.localPosition;
                 var sequence = DOTween.Sequence().Join(DOTween.To(() => transform.localPosition, value => transform.localPosition = value, startPosition + new Vector3(0, MaxY, 0), JumpTime)).Append(
                     DOTween.Sequence().Join(DOTween.To(() => transform.localPosition, value => transform.localPosition = value, startPosition, JumpTime)));
                 sequence.OnComplete(observer.OnCompleted);
                 sequence.Play();
                 return Disposable.Create(
                                          () =>
                                          {
                                              isJump = false;
                                          });
             });
    }
}
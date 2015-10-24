using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ClickControl : MonoBehaviour, IControl
{
    public IObservable<Unit> Jump
    {
        get
        {
            return this.gameObject.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
        }
    }
}
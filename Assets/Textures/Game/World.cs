using UnityEngine;

public class World : MonoBehaviour, IWorld
{
    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }
}
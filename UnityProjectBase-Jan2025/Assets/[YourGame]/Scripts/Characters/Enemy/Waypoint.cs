using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Vector3 Position => transform.position;
    public Quaternion Rotation => transform.rotation;
    public Vector3 Forward => transform.forward;
}

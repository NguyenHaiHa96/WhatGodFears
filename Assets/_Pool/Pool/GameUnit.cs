using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    private Transform trans;

    [Header("Game Unit")]
    public PoolType PoolType;

    public Transform Transform
    {
        get
        {
            if (trans == null)
            {
                trans = gameObject.transform;
            }
            return trans;
        }
    }

    public Quaternion Rotation { get => Transform.rotation; set => Transform.rotation = value; }
    public Vector3 WorldPosition { get => Transform.position; set => Transform.position = value; }
    public Vector3 LocalPosition { get => Transform.localPosition; set => Transform.localPosition = value; }
    public Vector3 LocalScale { get => Transform.localScale; set => Transform.localScale = value; }
    public Vector3 EulerAngles { get => Transform.eulerAngles; set => transform.eulerAngles = value; }
    public Vector3 EulerLocalRotation { get => Transform.localRotation.eulerAngles; }

    public float DeltaTime { get => Time.deltaTime; }
    public float FixedDeltaTime { get => Time.fixedDeltaTime; }

    public virtual void SetTransformParent(Transform parent)
    {
        transform.parent = parent;
    }
}
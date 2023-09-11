using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    private Transform trans;
    private RectTransform rectTransform;

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

    public RectTransform RectTransform
    {
        get
        {
            if (rectTransform == null)
            {
                rectTransform = gameObject.GetComponent<RectTransform>(); ;
            }
            return rectTransform;
        }
    }

    public Quaternion Rotation { get => Transform.rotation; set => Transform.rotation = value; }
    public Vector3 WorldPosition { get => Transform.position; set => Transform.position = value; }
    public Vector3 LocalPosition { get => Transform.localPosition; set => Transform.localPosition = value; }
    public Vector3 LocalScale { get => Transform.localScale; set => Transform.localScale = value; }
    public Vector3 EulerAngles { get => Transform.eulerAngles; set => transform.eulerAngles = value; }
    public Vector3 EulerLocalRotation { get => Transform.localRotation.eulerAngles; }
    public Vector3 AnchoredPosition { get => RectTransform.anchoredPosition; set => RectTransform.anchoredPosition = value; }
    public Vector3 SizeDelta { get => RectTransform.sizeDelta; set => RectTransform.sizeDelta = value; }

    public float DeltaTime { get => Time.deltaTime; }
    public float FixedDeltaTime { get => Time.fixedDeltaTime; }

    public virtual void SetTransformParent(Transform parent)
    {
        transform.parent = parent;
    }
}
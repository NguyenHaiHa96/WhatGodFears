using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UICanvas : GameUnit
{
    [Header("UI Canvas")]
    public UIID UIID;
    public Transform TfPopup;
    public Ease EaseOpen;
    public Ease EaseClose;
    public bool IsDestroyOnClose = false;

    private UnityAction closeCallback = null;

    #region Getter Setter
    public UnityAction CloseCallback { get => closeCallback; set => closeCallback = value; }

    #endregion

    public virtual void OnInit()
    {

    }


    public virtual void FetchData()
    {

    }

    public virtual void OnOpen()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnClose() 
    {
        CloseCallback?.Invoke();
        gameObject.SetActive(false);
        if (IsDestroyOnClose)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OpenAnimation()
    {

    }
}

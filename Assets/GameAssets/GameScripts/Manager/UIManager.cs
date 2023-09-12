using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class UIManager : GameSingleton<UIManager>
{
    private readonly string path = "Prefabs/UI/UICanvas/";

    public Transform TfCanvasParent;

    [Header("Canvas")]
    public UICanvas CurrentCanvas;
    public UICanvas LastActiveCanvas;

    public CanvasGameplay CanvasGameplay;

    [ShowInInspector] private Dictionary<UIID, UICanvas> UICanvasPrefabDict = new();
    private Dictionary<UIID, UICanvas> UICanvasDict = new();

    public override void Awake()
    {
        base.Awake();
        OnInit();
        CanvasGameplay.OnOpen();
    }

    public override void OnInit()
    {
        base.OnInit();
        UICanvas[] canvases = Resources.LoadAll<UICanvas>(path);
        for (int i = 0; i < canvases.Length; i++)
        {
            UICanvasPrefabDict.Add(canvases[i].UIID, canvases[i]);
        }
        CanvasGameplay = GetUI(UIID.Gameplay) as CanvasGameplay;
    }

    #region Canvas
    public bool IsOpenedUI(UIID ID)
    {
        return UICanvasDict.ContainsKey(ID) && UICanvasDict[ID] != null && UICanvasDict[ID].gameObject.activeInHierarchy;
    }

    public UICanvas GetUI(UIID ID)
    {
        UICanvas canvas = null;
        if (!UICanvasDict.ContainsKey(ID) || UICanvasDict[ID] == null)
        {
            canvas = Instantiate(UICanvasPrefabDict[ID], TfCanvasParent);
            canvas.gameObject.SetActive(false);
            UICanvasDict.Add(ID, canvas);
        }
        else
        {
            canvas = UICanvasDict[ID];
        }

        return UICanvasDict[ID];
    }

    public T GetUI<T>(UIID ID) where T : UICanvas
    {
        return GetUI(ID) as T;
    }

    public UICanvas OpenUI(UIID ID)
    {
        UICanvas canvas = GetUI(ID);
        canvas.OnOpen();
        return canvas;
    }

    public T OpenUI<T>(UIID ID) where T : UICanvas
    {
        return OpenUI(ID) as T;
    }

    public bool IsOpened(UIID ID)
    {
        return UICanvasDict.ContainsKey(ID) && UICanvasDict[ID] != null;
    }


    public void IsOpenedAndOpenUI(UIID ID)
    {
        UICanvas canvas = GetUI(ID);
        if (!canvas.gameObject.activeInHierarchy)
        {
            OpenUI(ID);
        }
    }

    public void SetCurrentCanvas(UIID ID)
    {
        if (CurrentCanvas != null)
        {
            CurrentCanvas.OnClose();
        }
        CurrentCanvas = OpenUI(ID);
    }
    #endregion

    public void CloseUI(UIID ID)
    {
        if (IsOpened(ID))
        {
            GetUI(ID).OnClose();
        }
    }
}

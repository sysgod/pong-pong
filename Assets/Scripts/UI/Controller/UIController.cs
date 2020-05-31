using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public UserInterfaceConfig Config;

    public static UIController Instance;

    [Header("UI Vars")]
    public RectTransform PanelRoot;
    public RectTransform PermanentRoot;

    public Dictionary<UserInterfaceConfig.UIPanleType, UIPanel> _panelsPrefabCollection = new Dictionary<UserInterfaceConfig.UIPanleType, UIPanel>();
    public Dictionary<UserInterfaceConfig.UIPanleType, UIPanel> _spawedPanels = new Dictionary<UserInterfaceConfig.UIPanleType, UIPanel>();

    public UserInterfaceConfig.UIPanleType menuTypeOnLoad = UserInterfaceConfig.UIPanleType.UNKNOWN;
    public bool IsStartPanelToPermanentRoot = true;
    private void Awake()
    {
        Instance = this;
        InitializeController();
    }

    private void Start()
    {
        if (menuTypeOnLoad != UserInterfaceConfig.UIPanleType.UNKNOWN)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.Log("Start Initialize panels collection");
#endif
            ShowPanelOfType<object>(menuTypeOnLoad, null,IsStartPanelToPermanentRoot);
        }
    }


    public void InitializeController()
    {
#if UNITY_EDITOR
        UnityEngine.Debug.Log("Start Initialize panels collection");
#endif
        foreach (var cfg in Config.GamePanels)
        {
            if (!_panelsPrefabCollection.ContainsKey(cfg.Type))
                _panelsPrefabCollection.Add(cfg.Type, cfg.PanelPrefab);
        }
    }

    public IPanel ShowPanelOfType<T>(UserInterfaceConfig.UIPanleType panelType,T obj, bool permanent=false)
    {
        var root = permanent ? PermanentRoot : PanelRoot;

        if (_spawedPanels.ContainsKey(panelType))
        {
            var existingPanel = _spawedPanels[panelType];
            existingPanel.Show<T>(obj);
            
            return existingPanel;
        }

        if (_panelsPrefabCollection.ContainsKey(panelType)) {
            var newPanel = Instantiate(_panelsPrefabCollection[panelType], root) as UIPanel;
            _spawedPanels.Add(panelType, newPanel);

            newPanel.Show<T>(obj);
            return newPanel;
        }
#if UNITY_EDITOR
        UnityEngine.Debug.LogError($"Error looking for panel of ");
#endif
        return null;
    }

    public void HideAllPanels(bool IsExcludePermanant = false)
    {
        foreach(KeyValuePair<UserInterfaceConfig.UIPanleType, UIPanel> panel in _spawedPanels)
        {
            if (IsExcludePermanant && panel.Value.transform.parent.Equals(PermanentRoot)) continue;
            if (panel.Value.IsShown())
            {
                panel.Value.Hide();
            }
        }
    }
}

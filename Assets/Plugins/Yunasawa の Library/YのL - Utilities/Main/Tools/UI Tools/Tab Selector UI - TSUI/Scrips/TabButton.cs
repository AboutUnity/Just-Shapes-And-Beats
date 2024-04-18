using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YNL.Extension.Method;

namespace YNL.Tools.UI
{
    [AddComponentMenu("YのL/Tools/UI/Tab Selector UI/Tab Button")]
    public class TabButton : MonoBehaviour
    {
        #region ▶ Properties
        public string Label = "";

        [Space(10)]
        [SerializeField] private TabManager _tabManager;
        private ITabActionable[] _thisTabSelectable;
        private Button _thisButton;

        [Space]
        public ETabState TabState = ETabState.Deselected;

        [Title("Tab Events")]
        public UnityEvent Select;
        public UnityEvent Deselect;

        #endregion

        #region ▶ Monobehaviour
#if UNITY_EDITOR
        protected void OnValidate()
        {
            if (Label == "") Label = gameObject.name;

            if (_thisButton == null) _thisButton = this.gameObject.GetOrAddComponent<Button>();
            if (_thisTabSelectable == null) _thisTabSelectable = this.GetComponents<ITabActionable>();
            if (_tabManager == null) _tabManager = this.transform.parent?.GetComponent<TabManager>();
        }
#endif

        protected void Awake()
        {
            if (Label == "") Label = gameObject.name;

            if (_thisButton == null) _thisButton = this.gameObject.GetOrAddComponent<Button>();
            if (_thisTabSelectable == null) _thisTabSelectable = this.GetComponents<ITabActionable>();
            if (_tabManager == null) _tabManager = this.transform.parent.GetComponent<TabManager>();

            _thisButton.onClick.AddListener(OnClick);
        }
        #endregion

        #region ▶ Tab State Functions: Select/Deselect/OnClick
        public void OnSelect()
        {
            TabState = ETabState.Selected;
            foreach (var tab in _thisTabSelectable) tab.Select();
            Select?.Invoke();
        }
        public void OnDeselect()
        {
            TabState = ETabState.Deselected;
            foreach (var tab in _thisTabSelectable) tab.Deselect();
            Deselect?.Invoke();
        }

        public void OnClick()
        {
            if (TabState == ETabState.Deselected) _tabManager.TabSelected(this);
        }

        public void ForceSelect() => OnClick();
        #endregion   

    }

    [SerializeField]
    public enum ETabState
    {
        Selected, Deselected,
    }
}

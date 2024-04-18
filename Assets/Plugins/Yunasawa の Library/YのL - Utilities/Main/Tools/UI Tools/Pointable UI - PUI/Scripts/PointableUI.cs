using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YNL.Attribute;
using YNL.Extension.Method;
using YNL.Extension.Constant;

namespace YNL.Tools.UI
{
    [AddComponentMenu("YのL/Tools/UI/Pointable UI")]
    public class PointableUI : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        #region ▶ Properties
        public bool Interactable = true;

        #region ▶ PUIMode Properties
        private bool _isSelected;
        [BoxGroup("PUI Mode", showLabel: false)] public PUIMode Mode;
        [Space()]
        [ShowIf("Mode", Value = PUIMode.IgnoreDeselect), BoxGroup("PUI Mode")] public string IgnoreDeselectName = "IgnoreDeselect";
        [ShowIf("Mode", Value = PUIMode.IgnoreDeselect), BoxGroup("PUI Mode")] public LayerMask IgnoreDeselectLayer;
        [ShowIf("Mode", Value = PUIMode.IgnoreDeselect), BoxGroup("PUI Mode")] public bool DetectCoveredIgnoreUI;

        [ShowIf("Mode", Value = PUIMode.HoverToSelect), BoxGroup("PUI Mode")] public bool DeselectOnExit;
        #endregion

        #region ▶ PUI Graphics
        [Title("PUI Graphics")]
        public EButtonTransition Transition = EButtonTransition.Color;
        bool _colorTransition => Transition.Contain(EButtonTransition.Color);
        bool _spriteTransition => Transition.Contain(EButtonTransition.SpriteSwap);
        bool _animationTransition => Transition.Contain(EButtonTransition.Animation);
        [Space(10)]
        [HideIfEnum("Transition", (int)EButtonTransition.None)]
        [HideIfEnum("Transition", (int)EButtonTransition.Animation)]
        public Image TargetGraphic;
        [Space()]
        private Color DefaultColor;
        [ShowIf("_colorTransition", Value = true)] public Color NormalColor = new(1, 1, 1, 1);
        [ShowIf("_colorTransition", Value = true)] public Color HighlightedColor = new(1, 1, 1, 1);
        [ShowIf("_colorTransition", Value = true)] public Color PressedColor = new(0.65f, 0.65f, 0.65f, 1);
        [ShowIf("_colorTransition", Value = true)] public Color SelectedColor = new(1, 1, 1, 1);
        [ShowIf("_colorTransition", Value = true)] public Color DisabledColor = new(0.75f, 0.75f, 0.75f, 0.5f);
        [ShowIf("_colorTransition", Value = true)] public float FadeDuration = 0.1f;
        [Space()]
        [ShowIf("_spriteTransition", Value = true)] public Sprite NormalSprite;
        [ShowIf("_spriteTransition", Value = true)] public Sprite HighlightedSprite;
        [ShowIf("_spriteTransition", Value = true)] public Sprite PressedSprite;
        [ShowIf("_spriteTransition", Value = true)] public Sprite SelectedSprite;
        [ShowIf("_spriteTransition", Value = true)] public Sprite DisabledSprite;
        [Space(10)]
        [ShowIf("_animationTransition", Value = true)] public Animator _Animator;
        [Space(10)]
        [ShowIf("_animationTransition", Value = true)] public string NormalTrigger = "Normal";
        [ShowIf("_animationTransition", Value = true)] public string HighlightedTrigger = "Highlighted";
        [ShowIf("_animationTransition", Value = true)] public string PressedTrigger = "Pressed";
        [ShowIf("_animationTransition", Value = true)] public string SelectedTrigger = "Selected";
        [ShowIf("_animationTransition", Value = true)] public string DisabledTrigger = "Disabled";
        #endregion

        #region ▶ PUI Event
        [FoldoutGroup("PUI Event")]
        [Header("Invoked when PUI is selected")]
        [FoldoutGroup("PUI Event/On Select | Deselect")] public UnityEvent Select;
        [Header("Invoked when PUI is deselected")]
        [FoldoutGroup("PUI Event/On Select | Deselect")] public UnityEvent Deselect;
        [Header("Invoked when PUI is clicked, but not be invoked when pointer is out of PUI")]
        [FoldoutGroup("PUI Event/On Pointer Click")] public UnityEvent LeftClick;
        [FoldoutGroup("PUI Event/On Pointer Click")] public UnityEvent RightClick;
        [FoldoutGroup("PUI Event/On Pointer Click")] public UnityEvent MiddleClick;
        [Header("Invoked when PUI is pressed")]
        [FoldoutGroup("PUI Event/On Pointer Down")] public UnityEvent LeftDown;
        [FoldoutGroup("PUI Event/On Pointer Down")] public UnityEvent RightDown;
        [FoldoutGroup("PUI Event/On Pointer Down")] public UnityEvent MiddleDown;
        [Header("Invoked when PUI is released, still be invoked even when pointer is out of PUI")]
        [FoldoutGroup("PUI Event/On Pointer Up")] public UnityEvent LeftUp;
        [FoldoutGroup("PUI Event/On Pointer Up")] public UnityEvent RightUp;
        [FoldoutGroup("PUI Event/On Pointer Up")] public UnityEvent MiddleUp;
        [Header("Invoked when pointer enter a PUI")]
        [FoldoutGroup("PUI Event/On Enter | Exit")] public UnityEvent Enter;
        [Header("Invoked when pointer exit a PUI")]
        [FoldoutGroup("PUI Event/On Enter | Exit")] public UnityEvent Exit;
        #endregion
        #endregion

        #region ▶ Methods
        #region ▶ Editor Methods
#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            Validate();
        }
#endif

        private void Awake()
        {
            Validate();

            if (Transition == EButtonTransition.Color || Transition == EButtonTransition.SpriteSwap)
            {
                if (TargetGraphic == null) TargetGraphic = this.GetComponent<Image>();
            }
            if (Transition == EButtonTransition.Color) if (TargetGraphic != null) TargetGraphic.color = NormalColor;
            if (Transition == EButtonTransition.SpriteSwap) if (TargetGraphic != null) TargetGraphic.sprite = NormalSprite;
            if (Transition == EButtonTransition.Animation) if (_Animator != null) _Animator.Play(NormalTrigger);

            IgnoreDeselectLayer = LayerMask.NameToLayer(IgnoreDeselectName);
        }

        private void Validate()
        {
#if UNITY_EDITOR
            Button getButton;
            if (GetComponent<Button>() != null)
            {
                getButton = GetComponent<Button>();
                getButton.DestroyOnValidate();
            }
#endif

            if (Transition == EButtonTransition.Color || Transition == EButtonTransition.SpriteSwap)
            {
                if (TargetGraphic == null)
                {
                    TargetGraphic = GetComponent<Image>();
                    if (TargetGraphic == null) MDebug.Warning("Require <b><color=#00FF87>Image</color></b> component if PUI is in <i><b>Color Tint</b></i> or <i><b>Sprite Swap</b></i> transition mode.");
                }
                else
                {
                    DefaultColor = TargetGraphic.color;

                    if (Transition == EButtonTransition.Color)
                    {
                        if (TargetGraphic.color != SelectedColor)
                        {
                            if (NormalColor != Color.white) TargetGraphic.color = NormalColor;
                        }
                    }
                    if (Transition == EButtonTransition.SpriteSwap)
                    {
                        if (NormalSprite != null) TargetGraphic.sprite = NormalSprite;
                    }
                }
            }
            if (Transition == EButtonTransition.Animation)
            {
                if (_Animator == null)
                {
                    _Animator = GetComponent<Animator>();
                    if (_Animator == null) MDebug.Warning("Require <b><color=#00FF87>Animator</color></b> component if PUI is in <i><b>Animation</b></i> transition mode.");
                }
            }
        }
        #endregion

        #region ▶ PUI Handler Methods
        /// <summary>
        /// Used to force selecting the PUI via code, without clicking on it.
        /// </summary>
        public void ForceSelect() => OnSelect(new(EventSystem.current));
        public void ForceDeselect()
        {
            var eventData = new BaseEventData(EventSystem.current);
            OnDeselect(new(EventSystem.current));
            if (eventData.selectedObject == this.gameObject) eventData.selectedObject = null;
        }
        public void DetectIgnoreUI(bool activate) => DetectCoveredIgnoreUI = activate;

        public void OnSelect(BaseEventData eventData)
        {
            PUIInteractableHandler("OnSelect");

            if (Transition == EButtonTransition.Color) TargetGraphic.color = SelectedColor;
            if (Transition == EButtonTransition.SpriteSwap) TargetGraphic.sprite = SelectedSprite;
            if (Transition == EButtonTransition.Animation) if (_Animator != null) _Animator.Play(SelectedTrigger);

            if (eventData.selectedObject != this.gameObject) eventData.selectedObject = this.gameObject;

            if (!_isSelected) PUIEventHandler("OnSelect", null);

            _isSelected = true;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            PUIInteractableHandler("OnDeselect");

            GameObject ignoreObject = RaycastUI.GetUIElement(IgnoreDeselectLayer, DetectCoveredIgnoreUI);
            if (ignoreObject != null && ignoreObject != this.gameObject && Mode == PUIMode.IgnoreDeselect)
            {
                if (gameObject.activeSelf) StartCoroutine(ReselectDelayed(this.gameObject));

                if (Transition == EButtonTransition.Color) TargetGraphic.color = SelectedColor;
                if (Transition == EButtonTransition.SpriteSwap) TargetGraphic.sprite = SelectedSprite;
                if (Transition == EButtonTransition.Animation) if (_Animator != null) _Animator.Play(SelectedTrigger);
                return;
            }

            if (Transition == EButtonTransition.Color)
            {
                if (NormalColor != Color.white) TargetGraphic.color = NormalColor;
                else TargetGraphic.color = DefaultColor;
            }
            if (Transition == EButtonTransition.SpriteSwap) TargetGraphic.sprite = NormalSprite;
            if (Transition == EButtonTransition.Animation) if (_Animator != null) _Animator.Play(NormalTrigger);

            if (_isSelected) PUIEventHandler("OnDeselect", null);

            _isSelected = false;

            //MDebug.Notify($"On Deselect: {name}");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PUIInteractableHandler("OnClick");

            if (Mode == PUIMode.HoverToSelect) return;

            if (Mode == PUIMode.OnlyClickButton)
            {
                if (Transition == EButtonTransition.Color)
                {
                    if (NormalColor != Color.white) TargetGraphic.color = NormalColor;
                    else TargetGraphic.color = DefaultColor;
                }
                if (Transition == EButtonTransition.SpriteSwap) TargetGraphic.sprite = NormalSprite;
                if (Transition == EButtonTransition.Animation) if (_Animator != null) _Animator.Play(NormalTrigger);
                PUIEventHandler("OnClick", eventData);
                return;
            }
            if (eventData.selectedObject != this.gameObject) eventData.selectedObject = this.gameObject;

            PUIEventHandler("OnClick", eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PUIInteractableHandler("OnDown");

            if (Mode == PUIMode.HoverToSelect) return;

            if (_isSelected) return;
            if (Transition == EButtonTransition.Color) TargetGraphic.color = PressedColor;
            if (Transition == EButtonTransition.SpriteSwap) TargetGraphic.sprite = PressedSprite;
            if (Transition == EButtonTransition.Animation) if (_Animator != null) _Animator.Play(PressedTrigger);

            PUIEventHandler("OnDown", eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PUIInteractableHandler("OnUp");

            if (Mode == PUIMode.HoverToSelect) return;

            PUIEventHandler("OnUp", eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PUIInteractableHandler("OnEnter");

            if (Mode == PUIMode.HoverToSelect)
            {
                if (eventData.selectedObject != this.gameObject) eventData.selectedObject = this.gameObject;
            }
            else
            {
                if (Transition == EButtonTransition.Color)
                {
                    if (TargetGraphic.color != SelectedColor) TargetGraphic.color = HighlightedColor;
                }
                if (Transition == EButtonTransition.SpriteSwap) TargetGraphic.sprite = HighlightedSprite;
                if (Transition == EButtonTransition.Animation) if (_Animator != null) _Animator.Play(HighlightedTrigger);
            }

            PUIEventHandler("OnEnter", eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PUIInteractableHandler("OnExit");

            if (Mode == PUIMode.HoverToSelect && DeselectOnExit) StartCoroutine(ReselectDelayed(null));

            if (Transition == EButtonTransition.Color)
            {
                if (TargetGraphic.color != SelectedColor)
                {
                    if (NormalColor != Color.white) TargetGraphic.color = NormalColor;
                    else TargetGraphic.color = DefaultColor;
                }
            }
            if (Transition == EButtonTransition.SpriteSwap) if (TargetGraphic.sprite != SelectedSprite) TargetGraphic.sprite = NormalSprite;
            if (Transition == EButtonTransition.Animation) if (_Animator != null) _Animator.Play(NormalTrigger);

            PUIEventHandler("OnExit", eventData);
        }
        #endregion

        #region ▶ Extension Methods
        private IEnumerator ReselectDelayed(GameObject gameObj)
        {
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(gameObj);
        }

        private void PUIEventHandler(string eventType, PointerEventData eventData)
        {
            switch (eventType)
            {
                case "OnSelect":
                    Select?.Invoke();
                    break;
                case "OnDeselect":
                    Deselect?.Invoke();
                    break;
                case "OnClick":
                    if (eventData.button == PointerEventData.InputButton.Left) LeftClick?.Invoke();
                    else if (eventData.button == PointerEventData.InputButton.Right) RightClick?.Invoke();
                    else if (eventData.button == PointerEventData.InputButton.Middle) MiddleClick?.Invoke();
                    break;
                case "OnDown":
                    if (eventData.button == PointerEventData.InputButton.Left) LeftDown?.Invoke();
                    else if (eventData.button == PointerEventData.InputButton.Right) RightDown?.Invoke();
                    else if (eventData.button == PointerEventData.InputButton.Middle) MiddleDown?.Invoke();
                    break;
                case "OnUp":
                    if (eventData.button == PointerEventData.InputButton.Left) LeftUp?.Invoke();
                    else if (eventData.button == PointerEventData.InputButton.Right) RightUp?.Invoke();
                    else if (eventData.button == PointerEventData.InputButton.Middle) MiddleUp?.Invoke();
                    break;
                case "OnEnter":
                    Enter?.Invoke();
                    break;
                case "OnExit":
                    Exit?.Invoke();
                    break;
            }
        }
        private void PUIInteractableHandler(string eventType)
        {
            if (!Interactable) return;

            switch (eventType)
            {
                case "OnSelect": if (_isSelected) return; break;
                case "OnDeselect": if (!_isSelected) return; break;
                case "OnClick": break;
                case "OnDown": if (_isSelected) return; break;
                case "OnUp": break;
                case "OnEnter": if (_isSelected) return; break;
                case "OnExit": if (_isSelected) return; break;
            }
        }

        #endregion
        #endregion
    }

    public enum PUIMode
    {
        StandardButton = 0, // Just like Unity's original button
        IgnoreDeselect = 1, // Ignore deselecting when clicking on UI with specific layer/tag
        HoverToSelect = 1 << 2, // Select when hovering pointer
        OnlyClickButton = 1 << 3, // Just for clicking purpose, not select after clicking
    }
}
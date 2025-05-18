using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unchord
{
    public class UIGameView : UIView
    {
        public float JoystickRadius { get; set; } = 400.0f;

        private Text _scoreboard;
        private Text _comboboard;
        private RectTransform _joybg;
        private RectTransform _joybt;
        private RectTransform _joyar;
        private UIJoystickArea _jArea;
        private Button _btnPause;

        protected override void Awake()
        {
            base.Awake();

            _scoreboard = transform.Find("Scoreboard").GetComponent<Text>();
            _comboboard = transform.Find("Comboboard").GetComponent<Text>();
            _joybg = transform.Find("JoystickBg").GetComponent<RectTransform>();
            _joybt = transform.Find("JoystickBt").GetComponent<RectTransform>();
            _joyar = transform.Find("JoystickArea").GetComponent<RectTransform>();
            _jArea = transform.Find("JoystickArea").GetComponent<UIJoystickArea>();
            _btnPause = transform.Find("PauseButton").GetComponent<Button>();

            _jArea.onPointerDown += OnPointerDown;
            _jArea.onPointerUp += OnPointerUp;
            _jArea.onBeginDrag += OnBeginDrag;
            _jArea.onDrag += OnDrag;
            _jArea.onEndDrag += OnEndDrag;

            _btnPause.onClick.AddListener(OnPauseButtonClicked);
        }

        public void SetScore(string strCombo)
        {
            _scoreboard.text = strCombo;
        }

        public void SetCombo(string strCombo)
        {
            _comboboard.text = strCombo;
        }

        private void SetJoysticRect(RectTransform rt, Vector2 canvasPosition, float radius)
        {

        }

        private void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log($"position == {eventData.position}");
            Debug.Log($"pressPosition == {eventData.pressPosition}");

            _joybg.anchoredPosition = Vector2.zero;

            //_joybg.anchoredPosition = eventData.position;
            _joybt.anchoredPosition = eventData.position;

            _joybg.sizeDelta = JoystickRadius * Vector2.one;
            _joybt.sizeDelta = JoystickRadius * Vector2.one;
        }

        private void OnPointerUp(PointerEventData eventData)
        {
            _joybt.anchoredPosition = _joybg.anchoredPosition;
        }

        private void OnBeginDrag(PointerEventData eventData)
        {
            
        }

        private void OnDrag(PointerEventData eventData)
        {
            Vector2 pCenter = _joybg.anchoredPosition;
            Vector2 pHandle = _joybt.anchoredPosition + eventData.scrollDelta;
            Vector2 diff = pHandle - pCenter;

            if (diff.magnitude > JoystickRadius)
                diff = diff.normalized * JoystickRadius;

            _joybt.anchoredPosition = pCenter + diff;
        }

        private void OnEndDrag(PointerEventData eventData)
        {
            _joybt.anchoredPosition = _joybg.anchoredPosition;
        }

        private void OnPauseButtonClicked()
        {

        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace CGLocalization.Example
{
    public class MenuUIControl : MonoBehaviour
    {
        [Header("Background")]
        [SerializeField]
        private Image m_backgroundImageFx = null;

        [Header("Options")]
        [SerializeField]
        private Dropdown m_optionLangDropDown = null;

        [Header("Controls")]
        [SerializeField]
        private LoadingUIControl m_loadingUIControl = null;
        [SerializeField]
        private CanvasGroup m_buttonsCanvas = null;
        [SerializeField]
        private CanvasGroup m_noteversionCanvas = null;
        [SerializeField]
        private CanvasGroup m_optionsCanvas = null;

        //cache vars
        private RectTransform m_backgroundImageFxRectTransform { get; set; }
        private Vector2 m_offsetBackgroundFxPosition { get; set; }

        private void Awake()
        {
            m_backgroundImageFxRectTransform = m_backgroundImageFx.GetComponent<RectTransform>();
            var languages = Localization.Instance.localizationAsset.languages;

            m_optionLangDropDown.ClearOptions();
            languages.ForEach(x => m_optionLangDropDown.options.Add(new Dropdown.OptionData {text = x.name}));
            m_optionLangDropDown.onValueChanged.AddListener(ChangeLang);

            m_loadingUIControl.EventFinishLoading += () => ShowLoading(false);
        }

        private void ChangeLang(int index)
        {
            Localization.Instance.ChangeLanguage(m_optionLangDropDown.options[m_optionLangDropDown.value].text);
        }

        private void Update()
        {
            AnimateBackground();
        }

        private void AnimateBackground()
        {
            if (Vector2.Distance(m_offsetBackgroundFxPosition, m_backgroundImageFxRectTransform.offsetMin) > .2f)
            {
                m_backgroundImageFxRectTransform.offsetMin = Vector2.MoveTowards(m_backgroundImageFxRectTransform.offsetMin, m_offsetBackgroundFxPosition, Time.deltaTime * 10);
            }
            else
            {
                m_offsetBackgroundFxPosition = new Vector2(UnityEngine.Random.Range(-150, 150), UnityEngine.Random.Range(-150, 150));
            }
        }

        public void ShowLoading(bool value)
        {
            m_buttonsCanvas.alpha = value ? 0 : 1;
            m_noteversionCanvas.alpha = value ? 0 : 1;
            m_optionsCanvas.alpha = 0;

            if (value)
                m_loadingUIControl.Show();
            else
                m_loadingUIControl.Hide();
        }
    }
}
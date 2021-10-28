using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CGLocalization.Example
{
    public class LoadingUIControl : MonoBehaviour
    {
        [SerializeField]
        private Image m_imageFillbar = null;
        [SerializeField]
        private Text m_textMessage = null;
        [SerializeField]
        private AudioSource m_audio = null;

        [SerializeField, SelectKeyDropdown(), SelectKeyType(KeyType.Audio)]
        int m_mission1AudioKey;

        [SerializeField, SelectKeyDropdown(), SelectKeyType(KeyType.String)]
        int[] m_messagesKeys;

        public event Action EventFinishLoading;

        //cache vars
        private CanvasGroup m_canvasgroup { get; set; }

        private void Awake()
        {
            m_canvasgroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            m_canvasgroup.alpha = 1;

            int randomKeyIndex = UnityEngine.Random.Range(0, m_messagesKeys.Length - 1);
            string text = Localization.Instance.GetString(m_messagesKeys[randomKeyIndex]);

            m_textMessage.text = text;     

            m_imageFillbar.fillAmount = 0;
            m_audio.PlayOneShot(Localization.Instance.GetAudio(m_mission1AudioKey), 1.3f);
            StartCoroutine(IDemoLoading());
        }

        public void Hide()
        {
            m_canvasgroup.alpha = 0;
        }

        private IEnumerator IDemoLoading()
        {
            while (m_imageFillbar.fillAmount < 1)
            {
                m_imageFillbar.fillAmount += .06f;
                yield return new WaitForSeconds(1);
            }

            EventFinishLoading.Invoke();
        }
    }
}

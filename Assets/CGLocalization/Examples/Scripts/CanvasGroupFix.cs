using UnityEngine;

namespace CGLocalization.Example
{
    public class CanvasGroupFix : MonoBehaviour
    {
        private CanvasGroup m_canvasGroup { get; set; }

        private void Awake()
        {
            m_canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            m_canvasGroup.interactable = m_canvasGroup.alpha > 0;
            m_canvasGroup.blocksRaycasts = m_canvasGroup.alpha > 0;
        }
    }
}

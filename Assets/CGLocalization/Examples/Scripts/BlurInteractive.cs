using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CGLocalization.Example
{
    [RequireComponent(typeof(Image))]
    public class BlurInteractive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Image m_image { get; set; }

        private readonly float m_defaultBlur = .8f;
        private readonly Color m_defaultColor = Color.grey;

        private float m_blurvalue = 0;
        private float m_blurtarget = 0;

        private void Awake()
        {
            m_image = GetComponent<Image>();

            //Create Material instance!
            m_image.material = Instantiate(m_image.material);

            //Set default values
            m_blurtarget = m_blurvalue = m_defaultBlur;

            SetBlur(m_defaultBlur);
            SetColor(m_defaultColor);
        }

        private void Update()
        {
            m_blurvalue = Mathf.MoveTowards(m_blurvalue, m_blurtarget, Time.deltaTime * 5);
            SetBlur(m_blurvalue);
        }

        private void SetBlur(float value)
        {
            m_image.material.SetFloat("_Size", value);
        }

        private void SetColor(Color color)
        {
            m_image.material.SetColor("_Main Color", color);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_blurtarget = 2;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_blurtarget = m_defaultBlur;
        }
    }
}
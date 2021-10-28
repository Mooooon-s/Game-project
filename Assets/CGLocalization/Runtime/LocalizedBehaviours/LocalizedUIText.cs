using UnityEngine;
using UnityEngine.UI;

namespace CGLocalization
{
    [SelectKeyType(KeyType.String)]
    [RequireComponent(typeof(Text))]
    public sealed class LocalizedUIText : LocalizedBehaviour
    {
        public bool uppercase;

        Text m_text;

        protected override void AssignString(string str)
        {
            if (!m_text)
                m_text = GetComponent<Text>();

            m_text.text = uppercase ? str.ToUpper() : str;
        }
    }
}
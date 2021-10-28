using UnityEngine;

namespace CGLocalization
{
    [SelectKeyType(KeyType.String)]
    [RequireComponent(typeof(TextMesh))]
    public sealed class LocalizedTextMesh : LocalizedBehaviour
    {
        public bool uppercase;

        TextMesh m_textMesh;

        protected override void AssignString(string str)
        {
            if (!m_textMesh)
                m_textMesh = GetComponent<TextMesh>();

            m_textMesh.text = uppercase ? str.ToUpper() : str;
        }
    }
}
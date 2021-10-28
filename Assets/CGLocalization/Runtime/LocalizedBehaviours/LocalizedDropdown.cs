using UnityEngine;
using UnityEngine.UI;

namespace CGLocalization
{
    [SelectKeyType(KeyType.String)]
    [RequireComponent(typeof(Dropdown))]
    public sealed class LocalizedDropdown : LocalizedBehaviour
    {
        [Tooltip("The separator used to split the key value and get the options.")]
        public string optionsSeparator = ";";
        public bool uppercase;

        Dropdown m_dropdown;

        protected override void AssignString(string str)
        {
            if (m_dropdown == null)
                m_dropdown = GetComponent<Dropdown>();

            // split the string using the separator
            string[] options = str.Split(optionsSeparator.ToCharArray());

            // assign the options if the same number the options
            if (options.Length == m_dropdown.options.Count)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    string option = options[i];
                    m_dropdown.options[i].text = uppercase ? option.ToUpper() : option;
                }

                // assign the caption
                string caption = options[m_dropdown.value];
                m_dropdown.captionText.text = uppercase ? caption.ToUpper() : caption;
            }
            else if(Application.isPlaying)
            {
                Debug.LogError("The amount of options in the Dropdown and the key are differents.", gameObject);
            }
        }
    }
}
using UnityEngine;

namespace CGLocalization
{
    [SelectKeyType(KeyType.Audio)]
    [RequireComponent(typeof(AudioSource))]
    public sealed class LocalizedAudioSource : LocalizedBehaviour
    {
        AudioSource m_audio;

        protected override void AssignObject(Object obj)
        {
            if (!m_audio)
                m_audio = GetComponent<AudioSource>();

            m_audio.clip = obj as AudioClip;
        }
    }
}
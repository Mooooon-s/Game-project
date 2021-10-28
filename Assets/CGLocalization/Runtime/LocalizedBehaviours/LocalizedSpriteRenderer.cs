using UnityEngine;

namespace CGLocalization
{
    [SelectKeyType(KeyType.Sprite)]
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class LocalizedSpriteRenderer : LocalizedBehaviour
    {
        SpriteRenderer m_spriteRenderer;

        protected override void AssignObject(Object obj)
        {
            if (!m_spriteRenderer)
                m_spriteRenderer = GetComponent<SpriteRenderer>();

            m_spriteRenderer.sprite = obj as Sprite;
        }
    }
}
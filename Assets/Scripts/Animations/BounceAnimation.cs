using DG.Tweening;
using UnityEngine;

namespace GridManagement.Animations
{
    public class BounceAnimation : ObjectAnimation
    {
        [SerializeField] float m_InitScale = 1f, m_MaxScale = 1.25f, m_MinScale = 1f;

        public override Sequence PlayAnimation()
        {
            float delay = m_Duration / 2f;

            transform.localScale = Vector3.one * m_InitScale;

            m_Sequence = DOTween.Sequence()
                .Append(transform.DOScale(m_MaxScale, m_Duration))
                .Append(transform.DOScale(m_MinScale, m_Duration))
                .Play();

            return m_Sequence;
        }

        public override void StopAnimation()
        {
            m_Sequence.Kill();
            transform.localScale = Vector3.one * m_MinScale;
        }
    }
}


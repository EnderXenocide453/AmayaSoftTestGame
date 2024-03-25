using DG.Tweening;
using UnityEngine;

namespace GridManagement.Animations
{
    public class ShakeAnimation : ObjectAnimation
    {
        [SerializeField] private float m_ShakeIntensity = 0.1f;
        [SerializeField] private int m_LoopsCount = 1;

        public override void PlayAnimation()
        {
            float delay = m_Duration / m_LoopsCount / 2;

            m_Sequence = DOTween.Sequence()
                .Append(transform.DOLocalMoveX(m_ShakeIntensity, delay))
                .Append(transform.DOLocalMoveX(-m_ShakeIntensity, delay))
                .Append(transform.DOLocalMoveX(0, delay))
                .SetLoops(m_LoopsCount)
                .Play();
        }

        public override void StopAnimation()
        {
            m_Sequence.Kill();
            transform.localPosition = Vector3.zero;
        }
    }
}


using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GridManagement.Animations
{

    public class FadeAnimation : ObjectAnimation
    {
        [SerializeField] Graphic m_Graphic;
        [SerializeField] float m_FadeValue;

        public override void PlayAnimation()
        {
            m_Sequence = DOTween.Sequence()
                .Append(m_Graphic?.DOFade(m_FadeValue, m_Duration))
                .Play();
        }

        public override void StopAnimation()
        {
            m_Sequence.Kill();
        }
    }
}


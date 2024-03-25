using DG.Tweening;
using UnityEngine;

namespace GridManagement.Animations
{
    public abstract class ObjectAnimation : MonoBehaviour
    {
        [SerializeField] protected float m_Duration = 1;
        [SerializeField] protected Sequence m_Sequence;

        public abstract void PlayAnimation();
        public abstract void StopAnimation();
    }
}


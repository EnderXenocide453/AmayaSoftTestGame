using GridManagement.Animations;
using UnityEngine;

namespace GridManagement.UI
{
    public class GridCellButtonAnimation : MonoBehaviour
    {
        [SerializeField] private ObjectAnimation[] m_IconApplyAnimations;
        [SerializeField] private ObjectAnimation m_IconDenyAnimation;
        [SerializeField] private ObjectAnimation m_SelfAppearAnimation;

        public void Appear()
        {
            m_SelfAppearAnimation?.PlayAnimation();
        }

        public void PlayApplyAnimation()
        {
            foreach (var animation in m_IconApplyAnimations)
                animation?.PlayAnimation();
        }

        public void PlayDenyAnimation()
        {
            m_IconDenyAnimation?.PlayAnimation();
        }

        private void OnDestroy()
        {
            foreach(var animation in m_IconApplyAnimations)
                animation?.StopAnimation();
            m_IconDenyAnimation?.StopAnimation();
            m_SelfAppearAnimation?.StopAnimation();
        }
    }
}

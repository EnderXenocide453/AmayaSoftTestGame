using GridManagement.Animations;
using UnityEngine;

namespace GridManagement.UI
{
    public class GridCellButtonAnimation : MonoBehaviour
    {
        [SerializeField] private ObjectAnimation m_IconApplyAnimation;
        [SerializeField] private ObjectAnimation m_IconDenyAnimation;
        [SerializeField] private ObjectAnimation m_SelfAppearAnimation;

        public void Appear()
        {
            m_SelfAppearAnimation?.PlayAnimation();
        }

        public void PlayApplyAnimation()
        {
            m_IconApplyAnimation?.PlayAnimation();
        }

        public void PlayDenyAnimation()
        {
            m_IconDenyAnimation?.PlayAnimation();
        }

        private void OnDestroy()
        {
            m_IconApplyAnimation?.StopAnimation();
            m_IconDenyAnimation?.StopAnimation();
            m_SelfAppearAnimation?.StopAnimation();
        }
    }
}

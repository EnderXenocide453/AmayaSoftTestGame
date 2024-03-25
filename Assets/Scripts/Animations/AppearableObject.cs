using UnityEngine;

namespace GridManagement.Animations
{
    public class AppearableObject : MonoBehaviour
    {
        [SerializeField] ObjectAnimation m_AppearAnimation;
        [SerializeField] ObjectAnimation m_DisappearAnimation;

        public void Appear()
        {
            m_DisappearAnimation?.StopAnimation();
            m_AppearAnimation?.PlayAnimation();
        }

        public void Disappear()
        {
            m_AppearAnimation?.StopAnimation();
            m_DisappearAnimation?.PlayAnimation();
        }

        private void OnDestroy()
        {
            m_AppearAnimation?.StopAnimation();
            m_DisappearAnimation?.StopAnimation();
        }
    }
}


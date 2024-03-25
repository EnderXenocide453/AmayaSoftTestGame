using GridManagement.Animations;
using UnityEngine;

namespace GridManagement.UI
{
    public class UIElementsHandler : MonoBehaviour
    {
        [SerializeField] AppearableObject m_WinPanel;

        public void ShowWinPanel()
        {
            m_WinPanel.Appear();
        }

        public void HideWinPanel()
        {
            m_WinPanel.Disappear();
        }
    }
}


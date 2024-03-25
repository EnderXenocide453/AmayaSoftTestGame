using UnityEngine;
using GridManagement.UI;
using System;

namespace GridManagement
{
    [RequireComponent(typeof(LevelsIterator))]
    public class GridExecutionHandler : MonoBehaviour
    {
        [Header("Logic")]
        [SerializeField] private LevelsIterator m_Iterator;

        private bool m_ISFirstInit = true;
        private bool m_IsButtonsActive = true;

        public bool IsFirstInit => m_ISFirstInit;

        public event Action onWin;

        private void Start()
        {
            m_Iterator ??= GetComponent<LevelsIterator>();
            m_Iterator.onIterationEnds += Win;

            m_Iterator.InitLevel(0);
            m_ISFirstInit = false;
        }

        public void OnCellSelected(GridCellButton cellButton)
        {
            if (!m_IsButtonsActive)
                return;

            if (m_Iterator.CheckIndex(cellButton.Index)) {
                cellButton.Animation.PlayApplyAnimation();
                m_Iterator.PassLevel();

                return;
            }

            cellButton.Animation.PlayDenyAnimation();
        }

        public void Restart()
        {
            m_Iterator.InitLevel(0);
            m_IsButtonsActive = true;
        }

        private void Win()
        {
            m_IsButtonsActive = false;
            onWin?.Invoke();
        }
    }
}


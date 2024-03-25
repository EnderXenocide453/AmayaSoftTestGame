using UnityEngine;
using GridManagement.Data;
using GridManagement.Generation;
using GridManagement.UI;
using System.Collections;

namespace GridManagement
{
    public class GridExecutionHandler : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private GridCellsData m_CellsData;
        [SerializeField] private GridSizeData[] m_GridLevels;
        [Header("Logic")]
        [SerializeField] private BaseGridGenerator m_GridGenerator;
        [SerializeField] private BaseGridVisualizer m_Visualizer;
        [Header("Misc.")]
        [SerializeField] private float m_LevelPassDelay = 1f;

        private int m_CurrentLevel;
        private GridGenerationData m_gridData;

        private void Start()
        {
            if (!ValidateData())
                return;

            InitLevel(0);
        }

        public void OnCellSelected(GridCellButton cellButton)
        {
            if (cellButton.Index == m_gridData.CorrectIndex) {
                cellButton.PlayApplyAnimation();
                PassLevel();

                return;
            }

            cellButton.PlayDenyAnimation();
        }

        private void InitLevel(int id)
        {
            id %= m_GridLevels.Length;

            m_gridData = m_GridGenerator.GenerateGrid(m_CellsData, m_GridLevels[id]);
            m_Visualizer.VisualizeGrid(m_gridData);

            m_CurrentLevel = id;
        }

        private void PassLevel()
        {
            StartCoroutine(WaitAndPass(m_LevelPassDelay));
        }

        private void LoadNextLevel()
        {
            InitLevel(m_CurrentLevel + 1);
        }

        private bool ValidateData()
        {
            bool isValid = true;

            if (m_CellsData == null) {
                Debug.LogError("Не указаны данные наполнения ячеек!");
                isValid = false;
            } if (m_GridLevels == null) {
                Debug.LogError("Не указаны данные уровней!");
                isValid = false;
            } if (m_GridGenerator == null) {
                Debug.LogError("Не назначен генератор сетки!");
                isValid = false;
            } if (m_Visualizer == null) {
                Debug.LogError("Не назначен визуализатор сетки!");
                isValid = false;
            }

            return isValid;
        }

        private IEnumerator WaitAndPass(float delay)
        {
            yield return new WaitForSeconds(delay);

            LoadNextLevel();
        }
    }
}


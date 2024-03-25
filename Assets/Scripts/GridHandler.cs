using UnityEngine;
using GridManagement.Data;
using GridManagement.Generation;

namespace GridManagement
{
    public class GridHandler : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private GridCellsData m_CellsData;
        [SerializeField] private GridSizeData[] m_GridLevels;
        [Header("Logic")]
        [SerializeField] private BaseGridGenerator m_GridGenerator;
        [SerializeField] private GridVisualizer m_Visualizer;

        private void Start()
        {
            if (!ValidateData())
                return;
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
    }
}


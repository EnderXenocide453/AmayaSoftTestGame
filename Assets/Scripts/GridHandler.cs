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
        [SerializeField] private BaseGridVisualizer m_Visualizer;

        private void Start()
        {
            if (!ValidateData())
                return;

            var data = m_GridGenerator.GenerateGrid(m_CellsData, m_GridLevels[0]);
            for (int i = 0; i < data.CellData.GetLength(0); i++)
                for (int j = 0; j < data.CellData.GetLength(1); j++)
                    Debug.Log(data.CellData[i, j].Name);
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


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
            m_Visualizer.VisualizeGrid(data);
        }

        private bool ValidateData()
        {
            bool isValid = true;

            if (m_CellsData == null) {
                Debug.LogError("�� ������� ������ ���������� �����!");
                isValid = false;
            } if (m_GridLevels == null) {
                Debug.LogError("�� ������� ������ �������!");
                isValid = false;
            } if (m_GridGenerator == null) {
                Debug.LogError("�� �������� ��������� �����!");
                isValid = false;
            } if (m_Visualizer == null) {
                Debug.LogError("�� �������� ������������ �����!");
                isValid = false;
            }

            return isValid;
        }
    }
}


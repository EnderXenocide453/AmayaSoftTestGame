using GridManagement.Data;
using GridManagement.UI;
using UnityEngine;

namespace GridManagement.Generation
{
    public class GridVisuzlizer : BaseGridVisualizer
    {
        [SerializeField] private GameObject m_CellPrefab;
        [SerializeField] private Transform m_GridContainer;
        [SerializeField] private float m_Spacing = 0.25f;
        //[SerializeField] private QuestionVisualizer

        public Transform GridContainer => m_GridContainer == null ? transform : m_GridContainer;

        public override void VisualizeGrid(GridGenerationData generationData)
        {
            if (!Validate())
                return;

            Clear();

            var cellsData = generationData.CellData;
            float offsetX = ((float)cellsData.GetLength(1) * m_Spacing - m_Spacing) / 2f;
            float offsetY = ((float)cellsData.GetLength(0) * m_Spacing - m_Spacing) / 2f;

            for (int x = 0;  x < cellsData.GetLength(1); x++) {
                for (int y = 0; y < cellsData.GetLength(0); y++) {
                    CellData data = cellsData[x, y];
                    DrawCell(x, y, data);
                }
            }

            void DrawCell(int x, int y, CellData data)
            {
                Vector2 position = new Vector2(x * m_Spacing - offsetX, y * m_Spacing - offsetY);

                GridCellButton button =
                    Instantiate(m_CellPrefab, position, Quaternion.identity, GridContainer)
                    .GetComponent<GridCellButton>();

                button.SetData(data, new Vector2Int(x, y));
            }
        }

        private void Clear()
        {
            for (int i = 0; i < GridContainer.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);
        }

        private bool Validate()
        {
            bool isValid = true;

            if (m_CellPrefab == null) {
                Debug.LogError("Не назначен префаб ячейки!");
                isValid = false;
            }
            if (m_CellPrefab.GetComponent<GridCellButton>() == null) {
                Debug.LogError("Префаб должен содержать компонент GridCellButton!");
                isValid = false;
            }

            return isValid;
        }
    }
}


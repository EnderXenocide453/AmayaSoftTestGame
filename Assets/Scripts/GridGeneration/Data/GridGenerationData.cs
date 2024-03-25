using GridManagement.Data;
using UnityEngine;

namespace GridManagement.Generation
{
    public class GridGenerationData
    {
        private CellData[,] m_GridData;
        private Vector2Int m_CorrectIndex;

        public CellData[,] CellData => m_GridData;
        public Vector2Int CorrectIndex => m_CorrectIndex;
        public CellData CorrectCell => m_GridData[CorrectIndex.y, CorrectIndex.x];

        public GridGenerationData(Vector2Int size)
        {
            if (!ValidateIndex(ref size))
                return;

            m_GridData = new CellData[size.y, size.x];
        }

        public void SetData(Vector2Int index, CellData data)
        {
            if (!ValidateIndexForExisting(ref index))
                return;

            m_GridData[index.y, index.x] = data;
        }

        public void SetCorrectIndex(Vector2Int correctIndex)
        {
            if (!ValidateIndexForExisting(ref correctIndex)) {
                return;
            }

            m_CorrectIndex = correctIndex;
        }

        private bool ValidateIndex(ref Vector2Int index) 
        {
            return 
                index.x >= 0 && index.y >= 0;
        }

        private bool ValidateIndexForExisting(ref Vector2Int index)
        {
            return
                m_GridData != null &&
                ValidateIndex(ref index) &&
                index.y < m_GridData.GetLength(0) &&
                index.x < m_GridData.GetLength(1);
        }
    }
}


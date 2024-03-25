using GridManagement.Data;
using System.Collections.Generic;
using UnityEngine;

namespace GridManagement.Generation
{
    public class GridGenerator : BaseGridGenerator
    {
        private List<CellData> m_UntouchedCellData;
        private GridCellsData m_CellData;

        public override GridGenerationData GenerateGrid(GridCellsData cellsData, GridSizeData gridSizeData)
        {
            InitUntouched(cellsData);

            GridGenerationData data = new GridGenerationData(gridSizeData.GridSize);

            List<CellData> freeCells = new List<CellData>(cellsData.Cells);
            Vector2Int gridSize = gridSizeData.GridSize;

            if (freeCells.Count < gridSize.x * gridSize.y) {
                Debug.LogError($"ячеек {cellsData.name} недостаточно дл€ заполнени€ сетки {gridSizeData.name}");
                return null;
            }

            Vector2Int correctIndex = RandomIndex(gridSize);
            CellData correctCell = GetRandomUntouched();

            freeCells.Remove(correctCell);

            data.SetData(correctIndex, correctCell);
            data.SetCorrectIndex(correctIndex);
            
            for (int y = 0; y < gridSize.y; y++) {
                for (int x = 0; x < gridSize.x; x++) {
                    //≈сли €чейка уже заполнена правильным вариантом, пропускаем итерацию
                    if (x == correctIndex.x && y == correctIndex.y)
                        continue;

                    int cellID = Random.Range(0, freeCells.Count);

                    data.SetData(new Vector2Int(x, y), freeCells[cellID]);
                    freeCells.RemoveAt(cellID);
                }
            }

            return data;
        }

        private void InitUntouched(GridCellsData cellsData)
        {
            if (ReferenceEquals(m_CellData, cellsData) && m_UntouchedCellData.Count > 0)
                return;

            m_CellData = cellsData;
            m_UntouchedCellData = new List<CellData>(cellsData.Cells);
        }

        private CellData GetRandomUntouched()
        {
            int id = Random.Range(0, m_UntouchedCellData.Count);
            CellData data = m_UntouchedCellData[id];
            m_UntouchedCellData.RemoveAt(id);

            return data;
        }

        private Vector2Int RandomIndex(Vector2Int size)
        {
            int x = Random.Range(0, size.x);
            int y = Random.Range(0, size.y);

            return new Vector2Int(x, y);
        }
    }
}


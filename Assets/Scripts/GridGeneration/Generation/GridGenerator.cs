using GridManagement.Data;
using System.Collections.Generic;
using UnityEngine;

namespace GridManagement.Generation
{
    public class GridGenerator : BaseGridGenerator
    {
        public override GridGenerationData GenerateGrid(GridCellsData cellsData, GridSizeData gridSizeData)
        {
            GridGenerationData data = new GridGenerationData(gridSizeData.GridSize);

            List<CellData> freeCells = new List<CellData>(cellsData.Cells);
            Vector2Int gridSize = gridSizeData.GridSize;
            if (freeCells.Count < gridSize.x * gridSize.y) {
                Debug.LogError($"ячеек {cellsData.name} недостаточно дл€ заполнени€ сетки {gridSizeData.name}");
                return null;
            }

            for (int y = 0; y < gridSize.y; y++) {
                for (int x = 0; x < gridSize.x; x++) {
                    int cellID = Random.Range(0, freeCells.Count);

                    data.SetData(new Vector2Int(x, y), freeCells[cellID]);
                    freeCells.RemoveAt(cellID);
                }
            }

            data.SetCorrectIndex(RandomIndex(gridSize));

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


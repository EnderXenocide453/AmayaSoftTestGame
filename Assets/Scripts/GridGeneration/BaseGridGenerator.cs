using GridManagement.Data;
using UnityEngine;

namespace GridManagement.Generation
{
    public abstract class BaseGridGenerator : MonoBehaviour
    {
        public abstract GridGenerationData GenerateGrid(GridCellsData cellsData, GridSizeData gridSize);
    }
}


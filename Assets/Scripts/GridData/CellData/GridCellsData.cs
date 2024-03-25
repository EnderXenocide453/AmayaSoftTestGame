using UnityEngine;

namespace GridManagement.Data
{
    [CreateAssetMenu(fileName = "CellsData", menuName = "Grid/CellsData")]
    public class GridCellsData : ScriptableObject
    {
        [SerializeField] private CellData[] cells;

        public CellData[] Cells => cells;
    }
}


using UnityEngine;

namespace GridManagement.Data
{
    [CreateAssetMenu(fileName = "GridSizeData", menuName = "Grid/SizeData")]
    public class GridSizeData : ScriptableObject
    {
        [SerializeField] private Vector2Int m_GridSize;

        public Vector2Int GridSize => m_GridSize;
    }
}


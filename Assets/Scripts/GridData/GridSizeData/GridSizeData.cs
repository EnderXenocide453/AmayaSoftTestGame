using UnityEngine;

namespace GridManagement.Data
{
    [CreateAssetMenu(fileName = "GridSizeData", menuName = "Grid/SizeData")]
    public class GridSizeData : ScriptableObject
    {
        [SerializeField, Range(1, 10)] private int x = 1, y = 1;

        public Vector2Int GridSize => new Vector2Int(x, y);
    }
}


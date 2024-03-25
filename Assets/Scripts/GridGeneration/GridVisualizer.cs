using UnityEngine;

namespace GridManagement.Generation
{
    public abstract class GridVisualizer : MonoBehaviour
    {
        public abstract void VisualizeGrid(GridGenerationData generationData);
    }
}


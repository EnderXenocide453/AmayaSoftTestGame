using UnityEngine;

namespace GridManagement.Generation
{
    public abstract class BaseGridVisualizer : MonoBehaviour
    {
        public abstract void VisualizeGrid(GridGenerationData generationData);
    }
}


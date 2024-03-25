using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridManagement.Generation
{
    public abstract class BaseQuestionVisualizer : MonoBehaviour
    {
        public abstract void VisualizeQuestion(string question);
    }
}


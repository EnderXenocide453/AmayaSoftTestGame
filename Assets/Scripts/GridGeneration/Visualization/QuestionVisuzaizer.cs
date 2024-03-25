using GridManagement.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace GridManagement.Generation
{
    public class QuestionVisuzaizer : BaseQuestionVisualizer
    {
        [SerializeField] private string m_QuestionBeginning, m_QuestionEnding;
        [SerializeField] private Text m_QuestionTextField;
        [SerializeField] private ObjectAnimation m_AppearAnimation;

        private void Start()
        {
            m_AppearAnimation?.PlayAnimation();
        }

        public override void VisualizeQuestion(string question)
        {
            if (!Validate())
                return;

            m_QuestionTextField.text = string.Concat(m_QuestionBeginning, question, m_QuestionEnding);
        }

        private bool Validate()
        {
            bool isValid = true;

            if (m_QuestionTextField == null) {
                Debug.LogError("Ќе указано текстовое поле дл€ вопроса!");
                isValid = false;
            }

            return isValid;
        }
    }
}


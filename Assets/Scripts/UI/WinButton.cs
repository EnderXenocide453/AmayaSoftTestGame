using System;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace GridManagement.UI
{
    public class WinButton : MonoBehaviour, IPointerClickHandler
    {
        private event Action _onClick;

        [Inject]
        public void Construct(GridExecutionHandler handler)
        {
            _onClick += handler.Restart;
            handler.onWin += Appear;
        }

        public void Appear()
        {
            gameObject.SetActive(true);
        }

        public void Disappear()
        {
            gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _onClick?.Invoke();
            Disappear(); 
        }
    }
}


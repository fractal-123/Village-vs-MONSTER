using UnityEngine;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private bool mouse_over = false;

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        UIManager.main.SetHoveringState(true);
        gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over= false;
        UIManager.main.SetHoveringState(false);
        gameObject.SetActive(false);
    }

}

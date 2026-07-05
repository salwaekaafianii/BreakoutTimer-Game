using UnityEngine;
using UnityEngine.EventSystems;

public class SprintButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public FirstPersonController player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.mobileSprint = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.mobileSprint = false;
    }
}
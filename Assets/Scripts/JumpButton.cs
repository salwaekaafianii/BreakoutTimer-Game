using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    public FirstPersonController player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.mobileJump = true;
    }
}
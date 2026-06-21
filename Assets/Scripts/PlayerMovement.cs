using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SimpleJoystick joystick;
    public CharacterController controller;

    public float speed = 8f;

    void Update()
    {
        Vector3 move = transform.right * joystick.Horizontal +
                       transform.forward * joystick.Vertical;

        controller.Move(move * speed * Time.deltaTime);
    }
}
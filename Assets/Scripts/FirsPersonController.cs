using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 15.0f;
    [SerializeField] private float sprintMultiplier = 2f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float gravityMultiplier = 2.2f;
    [Header("Look Parameters")]
    [SerializeField] private float upDownLookRange = 80f;

    [Header("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera mainCamera;
    // [SerializeField] private PlayerInputHandler playerInputHandler;
    [Header("Mobile")]
    [SerializeField] private SimpleJoystick joystick;
    [SerializeField] private Button jumpButton;
    [SerializeField] private Button sprintButton;

    [SerializeField] private AudioSource footstepAudio;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    public bool mobileSprint = false;
    public bool mobileJump = false;

    [Header("Head Bob")]
    [SerializeField] private float bobSpeed = 7f;      // semula 15
    [SerializeField] private float bobAmount = 0.015f; // semula 0.03

    private Vector3 cameraStartPos;
    private float bobTimer;
    [Header("Mobile Look")]
    [SerializeField] private float touchSensitivity = 0.2f;

    private int lookFingerId = -1;
    private Vector2 lastTouchPos;

    public bool isPaused;
    private Vector3 currentMovement;
    private float verticalRotation;
    private float CurrentSpeed
    {
        get
        {
            return walkSpeed * (mobileSprint ? sprintMultiplier : 1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraStartPos = mainCamera.transform.localPosition;

    }    // Update is called once per frame
    void Update()
    {
        if (isPaused) return;

        HandleMovement();
        HandleRotation();
        HandleFootstep();
        HeadBob();
    }
    private Vector3 CalculateWorldDirection()
    {
        if (joystick == null)
            return Vector3.zero;

        Vector3 inputDirection = new Vector3(
            joystick.Horizontal,
            0f,
            joystick.Vertical);

        return transform.TransformDirection(inputDirection).normalized;
    }
    private void HandleJumping()
    {
        if (characterController.isGrounded)
        {
            currentMovement.y = -0.5f;

            if (mobileJump)
            {
                currentMovement.y = jumpForce;

                // Dorongan ke depan saat lompat
                currentMovement += transform.forward * 6f;

                mobileJump = false;
            }
        }
        else
        {
            if (currentMovement.y > 0)
            {
                // Saat masih naik
                currentMovement.y += Physics.gravity.y * (gravityMultiplier + 1f) * Time.deltaTime;
            }
            else
            {
                // Saat turun lebih cepat
                currentMovement.y += Physics.gravity.y * (gravityMultiplier + 3f) * Time.deltaTime;
            }
        }
    }
    private void HandleMovement()
    {
        Vector3 worldDirection = CalculateWorldDirection();

        float speed = CurrentSpeed;

        // Saat di udara gerakan lebih jauh
        if (!characterController.isGrounded)
        {
            speed *= 2.2f;
        }

        currentMovement.x = worldDirection.x * speed;
        currentMovement.z = worldDirection.z * speed;

        HandleJumping();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void ApplyHorizontalRotation(float rotationAmount)
    {
        transform.Rotate(0, rotationAmount, 0);
    }

    private void HandleFootstep()
    {
        if (footstepAudio == null) return;

        // Jika SFX OFF
        if (PlayerPrefs.GetInt("SFX", 1) == 0)
        {
            if (footstepAudio.isPlaying)
                footstepAudio.Stop();
            return;
        }

        bool isMoving = new Vector3(currentMovement.x, 0, currentMovement.z).magnitude > 0.1f;
        if (isMoving)
        {
            footstepAudio.pitch = mobileSprint ? 1.5f : 1f;
            footstepAudio.volume = mobileSprint ? 1f : 0.8f;

            if (!footstepAudio.isPlaying)
            {
                footstepAudio.loop = true;
                footstepAudio.Play();
            }
        }
        else
        {
            footstepAudio.pitch = 1f;
            footstepAudio.volume = 0.8f;

            if (footstepAudio.isPlaying)
                footstepAudio.Stop();
        }
    }

    private void HeadBob()
    {
        if (mainCamera == null) return;

        bool isMoving = new Vector3(currentMovement.x, 0, currentMovement.z).magnitude > 0.1f;

        if (isMoving && characterController.isGrounded)
        {
            float speed = mobileSprint ? bobSpeed * 1.3f : bobSpeed;
            float amount = mobileSprint ? bobAmount * 1.2f : bobAmount;

            bobTimer += Time.deltaTime * speed;

            Vector3 targetPos = cameraStartPos;
            targetPos.y += Mathf.Sin(bobTimer) * amount;

            mainCamera.transform.localPosition = Vector3.Lerp(
                mainCamera.transform.localPosition,
                targetPos,
                Time.deltaTime * 10f
            );
        }
        else
        {
            bobTimer = 0f;

            mainCamera.transform.localPosition = Vector3.Lerp(
                mainCamera.transform.localPosition,
                cameraStartPos,
                Time.deltaTime * 8f
            );
        }
    }
    private void HandleRotation()
    {
        if (playerInputHandler == null) return;

        // Kalau joystick sedang dipakai, jangan putar kamera
        if (joystick != null &&
            (Mathf.Abs(joystick.Horizontal) > 0.01f ||
             Mathf.Abs(joystick.Vertical) > 0.01f))
        {
            return;
        }

        Vector2 rotation = playerInputHandler.RotationInput;

        ApplyHorizontalRotation(rotation.x * touchSensitivity);

        verticalRotation -= rotation.y * touchSensitivity;
        verticalRotation = Mathf.Clamp(
            verticalRotation,
            -upDownLookRange,
            upDownLookRange
        );

        mainCamera.transform.localRotation =
            Quaternion.Euler(verticalRotation, 0, 0);
    }
}
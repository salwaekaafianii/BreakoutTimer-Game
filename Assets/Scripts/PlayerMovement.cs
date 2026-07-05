// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public SimpleJoystick joystick;
//     public CharacterController controller;
//     public AudioSource footstepAudio;

//     public float speed = 8f;

//     void Update()
//     {
//         Vector3 move = transform.right * joystick.Horizontal +
//                        transform.forward * joystick.Vertical;

//         controller.Move(move * speed * Time.deltaTime);

//         // Jika SFX OFF, hentikan suara langkah
//         if (PlayerPrefs.GetInt("SFX", 1) == 0)
//         {
//             if (footstepAudio.isPlaying)
//                 footstepAudio.Stop();

//             return;
//         }

//         // Jika SFX ON
//         if (move.magnitude > 0.1f)
//         {
//             if (!footstepAudio.isPlaying)
//                 footstepAudio.Play();
//         }
//         else
//         {
//             if (footstepAudio.isPlaying)
//                 footstepAudio.Stop();
//         }
//     }
// }
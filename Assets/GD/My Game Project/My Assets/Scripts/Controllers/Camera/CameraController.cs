using UnityEngine;

namespace GD.My_Game_Project.My_Assets.Scripts.Controllers
{
    public class CameraController : MonoBehaviour
    {
        public Transform player; // Assign the player transform in the Inspector
        public float rotationSpeed = 5.0f;

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                RotateAroundPlayer(-1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                RotateAroundPlayer(1);
            }
        }
        private void RotateAroundPlayer(int direction)
        {
            transform.RotateAround(player.position, Vector3.up, direction * rotationSpeed * Time.deltaTime);
        }
    }
}

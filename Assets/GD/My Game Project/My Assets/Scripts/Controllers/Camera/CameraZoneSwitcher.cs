using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace GD.My_Game_Project.My_Assets.Scripts.Controllers.Camera
{
    public class CameraZoneSwitcher : MonoBehaviour
    {
        /*
         * Script Reference: https://www.youtube.com/watch?v=X_vK66w3GJk
         */
       [SerializeField]
        private string triggerTag = "Camera Zone";
    
        public CinemachineVirtualCamera primaryCamera;
        public CinemachineVirtualCamera[] vcams;

        private void Start()
        {
            SwitchToCamera(primaryCamera);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(triggerTag))
            {
                CinemachineVirtualCamera targetCamera = other.GetComponentInChildren<CinemachineVirtualCamera>();
                SwitchToCamera(targetCamera);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(triggerTag))
            {
                SwitchToCamera(primaryCamera);
            }
        }
        
        private void SwitchToCamera(CinemachineVirtualCamera targetCamera)
        {
            foreach (CinemachineVirtualCamera camera in vcams)
            {
                camera.enabled = camera == targetCamera;
            }
        }
    }
}

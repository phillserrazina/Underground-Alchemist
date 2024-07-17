using System.Linq;
using System.Collections;

using UnityEngine;
using Cinemachine;

using DG.Tweening;
using Sirenix.OdinInspector;
using Lucerna.Common.Singletons;

namespace Lucerna.Managers
{
	public class CameraManager : Singleton<CameraManager> 
	{
        // VARIABLES
        [Title("References")]
        [SerializeField] private CinemachineVirtualCamera defaultCamera;
		[SerializeField] private CinemachineVirtualCamera[] allCameras;

        private CinemachineVirtualCamera currentActiveCamera = null;
        public CinemachineVirtualCamera CurrentCamera => currentActiveCamera;
        public float DefaultCameraDefaultFOV { get; private set; }
        public float DefaultCameraCurrentFOV => currentActiveCamera.m_Lens.FieldOfView;

        // EXECUTION FUNCTIONS
        protected override void Awake()
        {
            base.Awake();

            if (allCameras.Length > 0)
            {
                currentActiveCamera = allCameras[0];
            }
        }

        // METHODS
        public void ChangeCameraPriority(int cameraIndex, int priority)
        {
			allCameras[cameraIndex].Priority = priority;
        }

        public CinemachineVirtualCamera GetCamera(int index)
        {
            return allCameras[index];
        }

        public CinemachineVirtualCamera GetCamera(string cameraName)
        {
            return allCameras.Where(camera => camera.name == cameraName).FirstOrDefault();
        }

        public void SetActiveCamera(int cameraIndex)
        {
            if (currentActiveCamera != null)
            {
                currentActiveCamera.Priority = 0;
            }

            currentActiveCamera = allCameras[cameraIndex];

			currentActiveCamera.Priority = 1;
        }

        public void SetActiveCamera(CinemachineVirtualCamera camera)
        {
            if (currentActiveCamera != null)
            {
                currentActiveCamera.Priority = 0;
            }
            
            if (camera != null)
            {
                currentActiveCamera = camera;
            }
            else
            {
                currentActiveCamera = defaultCamera;
            }

            currentActiveCamera.Priority = 1;
        }

        public void SetActiveCamera(string cameraName)
        {
            SetActiveCamera(GetCamera(cameraName));
        }

        public void SetCameraAim(Transform aimTarget)
        {
            currentActiveCamera.LookAt = aimTarget;
        }

        public void SetDefaultCamera(CinemachineVirtualCamera newDefault)
        {
            defaultCamera = newDefault;
            DefaultCameraDefaultFOV = defaultCamera.m_Lens.FieldOfView;
        }

        public void SetFOV(float newFov)
        {
            currentActiveCamera.m_Lens.FieldOfView = newFov;
        }

        public void ShakeCamera(float duration, float amplitude = 1, float frequency = 1f, bool smooth = true)
        {
            StartCoroutine(ShakeCameraCoroutine(duration, amplitude, frequency, smooth));
        }

        private IEnumerator ShakeCameraCoroutine(float duration, float amplitude = 1, float frequency = 1f, bool smooth = true)
        {
            CinemachineBasicMultiChannelPerlin perlin = currentActiveCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            float transitionDuration = smooth ? duration / 4f : 0f;

            DOVirtual.Float(0f, amplitude, transitionDuration, result =>
            {
                perlin.m_AmplitudeGain = result;
            });

            DOVirtual.Float(0f, frequency, transitionDuration, result =>
            {
                perlin.m_FrequencyGain = result;
            });

            yield return new WaitForSeconds(duration);

            DOVirtual.Float(amplitude, 0f, transitionDuration, result =>
            {
                perlin.m_AmplitudeGain = result;
            });

            DOVirtual.Float(frequency, 0f, transitionDuration, result =>
            {
                perlin.m_FrequencyGain = result;
            });
        }
    }
}
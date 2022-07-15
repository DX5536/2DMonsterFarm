using UnityEngine;

namespace PTWO_PR
{
    public class CameraZoomControl : MonoBehaviour
    {
        [SerializeField] private float zoomChange;
        
        [SerializeField] private float smoothChange;
        
        [SerializeField] private float minSize;
        
        [SerializeField] private float maxSize;

        [SerializeField] private int cameraOrthoGraphicSize;
        
        [SerializeField] private float standardZoomReset;

        [SerializeField] private new Camera camera;

        private void Start()
        {
            camera = GetComponent<Camera>();
            camera.orthographicSize = cameraOrthoGraphicSize;
        }

        private void Update()
        {
            
            // zoom in & out with camera, reset zoom to inital zoom with middle mouse button
            if (Input.mouseScrollDelta.y > 0)
                camera.orthographicSize -= zoomChange * Time.deltaTime * smoothChange;
            if (Input.mouseScrollDelta.y < 0)
                camera.orthographicSize += zoomChange * Time.deltaTime * smoothChange;

            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize , minSize , maxSize);

            if (Input.GetMouseButton(2))
            {
                camera.orthographicSize = standardZoomReset;
            }
        }
    }
}


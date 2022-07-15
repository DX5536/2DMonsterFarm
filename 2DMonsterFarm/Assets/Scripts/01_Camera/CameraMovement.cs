using UnityEngine;

namespace PTWO_PR
{
    public class CameraMovement : MonoBehaviour
    {

        private Vector3 origin;

        private Vector3 difference;

        private Vector3 resetCamera;

        private bool drag = false;

        void Start()
        {
            resetCamera = Camera.main.transform.position;
        }
        
        void LateUpdate()
        {
            // move camera with left click drag
            if (Input.GetMouseButton(0))
            {
                difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
                if (drag == false)
                {
                    drag = true;
                    origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else
            {
                drag = false;
            }

            if (drag)
            {
                Camera.main.transform.position = origin - difference;
            }

            
            // reset camera position to inital position
            if (Input.GetMouseButton(1))
                Camera.main.transform.position = resetCamera;
        }
    }
}


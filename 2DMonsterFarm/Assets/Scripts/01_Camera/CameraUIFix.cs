using UnityEngine;

namespace PTWO_PR
{
    public class CameraUIFix : MonoBehaviour
    {
        [SerializeField] private new GameObject camera;
    
        
        // disable camera zoom while shop active
        void Update()
        {
            if (ShopButton.isShopOpen)
        {
            camera.GetComponent<CameraZoomControl>().enabled = false;
        } 
            else
        {
            camera.GetComponent<CameraZoomControl>().enabled = true;
        }
            
        }
    }
}

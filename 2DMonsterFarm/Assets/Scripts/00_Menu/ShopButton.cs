using UnityEngine;
using UnityEngine.UI;

namespace PTWO_PR
{
    public class ShopButton : MonoBehaviour
    {
        [SerializeField] private GameObject shop;

        public static bool isShopOpen;

        private bool isActive;
        
        [SerializeField] private Button shopButton;

        [SerializeField] private Sprite shopOpenImage;
        
        [SerializeField] private Sprite shopCloseImage;
        
        [SerializeField] private AudioClip shopOpenSound;

        private void Update()
        {
            // open shop with b or through button click
            if (Input.GetKeyDown(KeyCode.B))
            {
                OpenShop();
                SoundManager.instance.PlaySound(shopOpenSound);
            }

            if (isShopOpen)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    OpenShop();
                    SoundManager.instance.PlaySound(shopOpenSound);
                }
            }
        }
        
        // method to open the shop, change icon and play sound
        public void OpenShop()
        {
    
            if (shop != null && PauseMenu.isPaused == false)
            {
                isShopOpen = true;
                isActive = shop.activeSelf;
                shopButton.image.sprite = shopOpenImage;
                shop.SetActive(!isActive);
                SoundManager.instance.PlaySound(shopOpenSound);

                if (isActive == true)
                {
                    shopButton.image.sprite = shopCloseImage;
                    isShopOpen = false;
                }
            }
        }
    }

}


using UnityEngine;

namespace PTWO_PR
{
    public class MiscShopItemHolder : MonoBehaviour
    {
        [SerializeField] private FarmManager farmManager;
        
        [SerializeField] private MiscShopItem food;
        
        [SerializeField] private MiscShopItem normalPlot;
        
        [SerializeField] private MiscShopItem skyPlot;
        
        [SerializeField] private MiscShopItem lavaPlot;
    
        private void Update()
        {
            
            // change button text & color in misc shop (*easy fix for buttons not working properly)
            if (farmManager.SelectedMisc == 1)
            {
                food.BuyButtonText.text = "Cancel";
                food.BuyButtonColor.color = Color.red;
            }
            else
            {
                food.BuyButtonText.text = "Buy";
                food.BuyButtonColor.color = Color.green;
            }
            
            if (farmManager.SelectedMisc == 2)
            {
                normalPlot.BuyButtonText.text = "Cancel";
                normalPlot.BuyButtonColor.color = Color.red;
            }
            else
            {
                normalPlot.BuyButtonText.text = "Buy";
                normalPlot.BuyButtonColor.color = Color.green;
            }
            
            if (farmManager.SelectedMisc == 3)
            {
                skyPlot.BuyButtonText.text = "Cancel";
                skyPlot.BuyButtonColor.color = Color.red;
            }
            else
            {
                skyPlot.BuyButtonText.text = "Buy";
                skyPlot.BuyButtonColor.color = Color.green;
            }
            
            if (farmManager.SelectedMisc == 4)
            {
                lavaPlot.BuyButtonText.text = "Cancel";
                lavaPlot.BuyButtonColor.color = Color.red;
            }
            else
            {
                lavaPlot.BuyButtonText.text = "Buy";
                lavaPlot.BuyButtonColor.color = Color.green;
            }
        }
    }

}
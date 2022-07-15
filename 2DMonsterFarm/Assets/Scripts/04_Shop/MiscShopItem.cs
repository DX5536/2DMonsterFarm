using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace PTWO_PR
{
    public class MiscShopItem : MonoBehaviour
    {
        [Header("References")]

        [SerializeField] private MiscShopItemScriptableObject misc;
        
        [SerializeField] private TextMeshProUGUI nameText;

        [SerializeField] private TextMeshProUGUI priceText;
        
        [SerializeField] private FarmManager farmManager;

        [SerializeField] private Image icon;

        [SerializeField] private Image buyButtonColor;

        [SerializeField] private TextMeshProUGUI buyButtonText;

        [SerializeField] private AudioClip shopSelectAudio;
        
        public Image BuyButtonColor
        {
            get { return buyButtonColor; }
        }
        
        public TextMeshProUGUI BuyButtonText
        {
            get { return buyButtonText; }
        }
        public Image Icon
        {
            get { return icon; }
        }

        private void Start()
        {
            ShopInterface();
            farmManager = FindObjectOfType<FarmManager>();
        }
        
        private void ShopInterface()
        {
            nameText.text = misc.MiscDisplayName;

            priceText.text = +misc.BuyPrice + "€";

            icon.sprite = misc.Icon;

        }
    }
}


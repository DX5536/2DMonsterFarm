using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace PTWO_PR
{
    public class MonsterShopItem : MonoBehaviour
    {
        [Header("References")]
        
        [SerializeField] private MonsterScriptableObject monster;

        [SerializeField] private TextMeshProUGUI nameText;

        [SerializeField] private TextMeshProUGUI priceText;

        [SerializeField] private TextMeshProUGUI sellText;

        [SerializeField] private TextMeshProUGUI hatchText;

        [SerializeField] private Image icon;

        [SerializeField] private FarmManager farmManager;

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
        public MonsterScriptableObject Monster
        {
            get { return monster; }
        }
        public Image Icon
        {
            get { return icon; }
        }

        private void Start()
        {

            farmManager = FindObjectOfType<FarmManager>();

            ShopInterface();
        }

        public void BuyMonster()
        {
            farmManager.SelectMonsterMethod(this);
            SoundManager.instance.PlaySound(shopSelectAudio);

        }

        private void ShopInterface()
        {
            nameText.text = Monster.MonsterDisplayName;

            priceText.text = +Monster.BuyPrice + "€";

            sellText.text = "Sell Price: " + Monster.SellPrice + "€";

            hatchText.text = "Hatch Time: " + Monster.MonsterHatchTime + "s";

            icon.sprite = Monster.Icon;

        }
    }
}


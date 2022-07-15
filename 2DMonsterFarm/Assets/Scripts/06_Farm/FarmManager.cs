using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace PTWO_PR
{
    public class FarmManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private MonsterShopItem selectMonster;
        
        [SerializeField] private MiscShopItem selectMisc;

        [SerializeField] private TextMeshProUGUI moneyTextStore;
        
        [SerializeField] private TextMeshProUGUI moneyText;
        
        [Header("Basic Variables")]

        [SerializeField] private int money;

        [SerializeField] private bool isPlanting = false;

        [SerializeField] private bool isMiscSelecting = false;
        
        [Header("Audio")]

        [SerializeField] private AudioClip shopClickSound;

        [SerializeField]
        private int selectedMisc = 0; // 1 - Food, 2 - Normal Plot, 3 - Sky Plot, 4 - Lava Plot
        
        public MonsterShopItem SelectMonster
        {
            get { return selectMonster; }
        }
        
        public bool IsPlanting
        {
            get { return isPlanting; }
        }
        
        public int Money
        {
            get { return money; }
        }

        public bool IsMiscSelecting
        {
            get { return isMiscSelecting; }
        }
        public int SelectedMisc
        {
            get { return selectedMisc; }
        }

        private void Start()
        {
            money = PlayerPrefs.GetInt("Money", Money);
            moneyText.text = PlayerPrefs.GetInt("Money", Money) + "€";
            moneyTextStore.text = PlayerPrefs.GetInt("Money", Money) + "€";
        }

        // selection for the monster shop
        public void SelectMonsterMethod(MonsterShopItem newMonster)
        {
            if (selectMonster == newMonster)
            {
                CheckSelection();

            }

            //Selected Monster but not buying yet
            else
            {
                CheckSelection();
                selectMonster = newMonster;
                selectMonster.BuyButtonColor.color = Color.red;
                selectMonster.BuyButtonText.text = "Cancel";
                isPlanting = true;
            }
        }

        // selection for the misc shop
        public void SelectMisc(int miscNumber)
        {
            SoundManager.instance.PlaySound(shopClickSound);
           
            if (miscNumber == SelectedMisc)
            {
                CheckSelection();
                
            }
            else
            {
                CheckSelection();
                isMiscSelecting = true;
                selectedMisc = miscNumber;
            }
        }

        // check what is selected in the shop
        public void CheckSelection()
        {
            if (IsPlanting)
            {
                isPlanting = false;
                if (selectMonster != null)
                {
                    selectMonster.BuyButtonColor.color = Color.green;
                    selectMonster.BuyButtonText.text = "Buy";
                    selectMonster = null;
                }
            }

            if (IsMiscSelecting)
            {
                isMiscSelecting = false;
                selectedMisc = 0;
            }
        }

        // method for every money transaction
        public void MoneyTransaction(int value)
        {
            money += value;
            moneyTextStore.text = Money + "€";
            moneyText.text = Money + "€";
            PlayerPrefs.SetInt("Money", Money);
        }

    }
}


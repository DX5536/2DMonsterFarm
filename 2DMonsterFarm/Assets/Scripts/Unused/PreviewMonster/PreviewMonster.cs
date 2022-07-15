using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PTWO_PR
{
    public class PreviewMonster : MonoBehaviour
    {
        [SerializeField]
        private FarmManager farmManager;

        [SerializeField]
        private MonsterShopItem mySelectedMonsterInShop;

        [SerializeField]
        private MonsterScriptableObject myMonsterScriptableObject;

        [SerializeField]
        private Image monsterImage;

        [SerializeField]
        private SpriteRenderer monsterSpriteRenderer;

        [SerializeField]
        private GameObject monsterPrefab;

        public MonsterShopItem SelectedMonsterInShop
        {
            get { return mySelectedMonsterInShop; }
        }

        public SpriteRenderer MonsterSpriteRenderer
        {
            get { return monsterSpriteRenderer; }
        }

        // Update is called once per frame
        void Update()
        {
            mySelectedMonsterInShop = farmManager.SelectMonster;

            if (mySelectedMonsterInShop != null)
            {
                myMonsterScriptableObject = mySelectedMonsterInShop.Monster;

                monsterImage = mySelectedMonsterInShop.Icon;

                monsterSpriteRenderer = monsterImage.GetComponent<SpriteRenderer>();
            }

            else
            {
                return;
            }

        }
    }
}


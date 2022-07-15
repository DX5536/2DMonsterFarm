using UnityEngine;

namespace PTWO_PR
{
    public class PlotManager : MonoBehaviour
    {

        [Header("Components")]
        
        [SerializeField] private BoxCollider2D monsterCollider;
        
        [SerializeField] private MonsterScriptableObject selectedMonster;

        [SerializeField] private FarmManager farmManager;

        [Header("Basic Variables")]
        
        [SerializeField] private int monsterStage = 0;
        
        [SerializeField] private float stageTimer;

        [SerializeField] private float fullTimer;

        [SerializeField] private float speed = 1f;
        
        [SerializeField] private bool isPlanted = false;
        
        [SerializeField] private bool isBought = true;
        
        [SerializeField] private bool isSkyPlot = false;
        
        [SerializeField] private bool isLavaPlot = false;

        [SerializeField] private bool isSkyMonsterActive = false;

        [SerializeField] private bool isFoodActive = false;

        [SerializeField] private bool updatedSpeed;

        [SerializeField] private bool playedHarvestableSound;


        [Header("Sprites")]
        
        [SerializeField] private SpriteRenderer monster;

        [SerializeField] private SpriteRenderer foodSpriteRenderer;
        
        [SerializeField] private SpriteRenderer tile;

        [Header("Normal Plot")]
        
        [SerializeField] private Sprite plotNotBoughtSprite;
        
        [SerializeField] private Sprite normalPlot;
        
        [SerializeField] private Sprite normalFoodActive;
        
        [SerializeField] private Sprite normalFoodNotActive;
        
        [Header("Sky Plot")]
        
        [SerializeField] private Sprite skyPlot;
        
        [SerializeField] private Sprite skyFoodActive;
        
        [SerializeField] private Sprite skyFoodNotActive;
        
        [SerializeField] private Sprite skyMonster;
        
        [Header("Lava Plot")]

        [SerializeField] private Sprite lavaPlot;
        
        [SerializeField] private Sprite lavaFoodActive;
        
        [SerializeField] private Sprite lavaFoodNotActive;

        /*[Header("Audio")]
        
        [SerializeField] private AudioClip harvestSound;
        
        [SerializeField] private AudioClip plantSound;
        
        [SerializeField] private AudioClip foodSound;
        
        [SerializeField] private AudioClip normalTileSound;
                
        [SerializeField] private AudioClip skyTileSound;
        
        [SerializeField] private AudioClip readyToHarvestSound; */

        [Header("Handlers for SoundFX")]
        [SerializeField] private PlayHarvestSoundFXEventHandler playHarvestSoundFXHandler;

        [SerializeField] private PlayPlantSoundFXEventHandler playPlantSoundFXHandler;

        [SerializeField] private PlayFoodSoundFXEventHandler playFoodSoundFXHandler;

        [SerializeField] private PlayNormalTileSoundFXEventHandler playNormalTileSoundFXHandler;

        [SerializeField] private PlaySkyTileSoundFXEventHandler playSkyTileSoundFXHandler;

        [SerializeField] private PlayLavaTileSoundFXEventHandler playLavaTileSoundFXHandler;

        [SerializeField] private PlayReadyToHarvestSoundFXEventHandler playReadyToHarvestSoundFXEventHandler;

        [Header("EnergyBeamAnimation when Harvest")]
        [SerializeField]
        private PlayAnimationWhenHarvestHandler harvestAnimationHandler;
       
        public MonsterScriptableObject SelectedMonster
        {
            get { return selectedMonster; }
            set => selectedMonster = value;
        }
        
        public float FullTimer
        {
            get { return fullTimer; }
            set => fullTimer = value;
        }
        
        public int MonsterStage
        {
            get { return monsterStage; }
            set => monsterStage = value;
        }


        private void Start()
        {
            monster = transform.GetChild(0).GetComponent<SpriteRenderer>();
            monsterCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
            farmManager = transform.parent.GetComponent<FarmManager>();
            foodSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
            tile = GetComponent<SpriteRenderer>();

            if (!isBought)
            {
                tile.sprite = plotNotBoughtSprite;
                foodSpriteRenderer.enabled = false;
            }

        }

        private void Update()
        {
            
            // logic for updating monster stage when planted & harvesting
            if (isPlanted)
            {
                stageTimer -= speed*Time.deltaTime;
                FullTimer -= speed*Time.deltaTime;

                if (stageTimer < 0 && MonsterStage < SelectedMonster.MonsterStages.Length - 1)
                {
                    stageTimer = SelectedMonster.TimeBetweenStages;
                    MonsterStage++;
                    UpdateMonster();
                }

                if (MonsterStage == 3)
                {
                    if (!playedHarvestableSound)
                    {
                        //SoundManager.instance.PlayRandomizedSound(readyToHarvestSound);
                        playReadyToHarvestSoundFXEventHandler.ActivatePlayReadyToHarvestSound();

                        playedHarvestableSound = true;
                    }
                    
                }
            }

            // give plots different effects
            if (monster.sprite == skyMonster)
            {
                isSkyMonsterActive = true;
            }

            if (isSkyPlot && isSkyMonsterActive)
            {
                if (speed < 3 && !updatedSpeed)
                {
                    updatedSpeed = true;
                    speed += 1f;
                    speed += 1f;
                }
            }
        }

        // planting logic while a monster is selected from the shop & the money is greater equal or greater than monster buyprice
        private void OnMouseDown()
        {
            if (isPlanted)
            {
                if (MonsterStage == SelectedMonster.MonsterStages.Length - 1)
                {
                    Harvest();
                }

            }
            else if (farmManager.IsPlanting && farmManager.SelectMonster.Monster.BuyPrice <= farmManager.Money && isBought)
            {
                Plant(farmManager.SelectMonster.Monster);
            }

            // selection of the misc shop
            if (farmManager.IsMiscSelecting)
            {
                switch (farmManager.SelectedMisc)
                {
                    case 1: // place food
                        if (farmManager.Money >= 40 && isBought && isFoodActive == false)
                        {
                            isFoodActive = true;
                            farmManager.MoneyTransaction(-40);

                            //SoundManager.instance.PlayRandomizedSound(foodSound);
                            playFoodSoundFXHandler.ActivatePlayFoodSound();

                            if (speed < 2 && isSkyPlot == false)
                            {
                                speed += 1f;
                                foodSpriteRenderer.sprite = normalFoodActive;
                            }

                            if (speed <= 2 && isSkyPlot)
                            {
                                speed += 1f;
                                foodSpriteRenderer.sprite = skyFoodActive;
                            }
                            
                            if (speed <= 2 && isLavaPlot)
                            {
                                speed += 1f;
                                foodSpriteRenderer.sprite = lavaFoodActive;
                            }
                        }

                        break;
                    case 2: // buy normal plot
                        if (farmManager.Money >= 100 && !isBought)
                        {
                            isBought = true;
                            farmManager.MoneyTransaction(-100);
                            tile.sprite = normalPlot;
                            foodSpriteRenderer.enabled = true;

                            //SoundManager.instance.PlayRandomizedSound(normalTileSound);
                            playNormalTileSoundFXHandler.ActivatePlayNormalTileSound();
                        }

                        break;
                    case 3: // buy sky plot
                        if (farmManager.Money >= 200 && !isBought)
                        {
                            isBought = true;

                            //SoundManager.instance.PlayRandomizedSound(skyTileSound);
                            playSkyTileSoundFXHandler.ActivatePlaySkySound();

                            tile.sprite = skyPlot;
                            farmManager.MoneyTransaction(-200);
                            foodSpriteRenderer.enabled = true;
                            foodSpriteRenderer.sprite = skyFoodNotActive;
                            isSkyPlot = true;

                        }

                        break;
                    case 4: // buy lava plot
                        if (farmManager.Money >= 300 && !isBought)
                        {
                            isBought = true;
                            farmManager.MoneyTransaction(-300);
                            tile.sprite = lavaPlot;
                            foodSpriteRenderer.enabled = true;
                            foodSpriteRenderer.sprite = lavaFoodNotActive;
                            isLavaPlot = true;

                            //SoundManager.instance.PlayRandomizedSound(normalTileSound);
                            playLavaTileSoundFXHandler.ActivatePlayLavaSound();
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        // visual clue for hovering over tiles
        private void OnMouseOver()
        {
            tile.color = Color.green;

            if (!isBought)
            {
                tile.color = Color.red;
            }
        }

        private void OnMouseExit()
        {
            tile.color = Color.white;
        }

        // harvest method
        private void Harvest()
        {
            isPlanted = false;
            isSkyMonsterActive = false;
            isFoodActive = false;
            MonsterStage = 0;
            monster.gameObject.SetActive(false);
            farmManager.MoneyTransaction(SelectedMonster.SellPrice);
            speed = 1f;

            //SoundManager.instance.PlayRandomizedSound(harvestSound);
            playHarvestSoundFXHandler.ActivatePlayHarvestSound();

            updatedSpeed = false;
            playedHarvestableSound = false;
           // change the food bowl according to plot
            if (isSkyPlot)
            {
                foodSpriteRenderer.sprite = skyFoodNotActive;
            } 
            else
            {
                foodSpriteRenderer.sprite = normalFoodNotActive;
            }
            if (isLavaPlot)
            {
                foodSpriteRenderer.sprite = lavaFoodNotActive;
            } 
            else
            {
                foodSpriteRenderer.sprite = normalFoodNotActive;
            }

            harvestAnimationHandler.ActivatePlayAnimationOnHarvest();
        }

        // method for planting && the changes needed for variables
        private void Plant(MonsterScriptableObject newMonster)
        {
            SelectedMonster = newMonster;
            isPlanted = true;
            farmManager.MoneyTransaction(-SelectedMonster.BuyPrice);
            MonsterStage = 0;
            UpdateMonster();
            stageTimer = SelectedMonster.TimeBetweenStages;
            FullTimer = SelectedMonster.MonsterHatchTime;
            monster.gameObject.SetActive(true);

            //SoundManager.instance.PlayRandomizedSound(plantSound);
            playPlantSoundFXHandler.ActivatePlayPlantSound();
        }

        // fix the sprite collider with each stage
        private void UpdateMonster()
        {
            monster.sprite = SelectedMonster.MonsterStages[MonsterStage];
            monsterCollider.size = monster.sprite.bounds.size;
            monsterCollider.offset = new Vector2(0 , monster.bounds.size.y / 2);
        }
    }
}

# Realize_Implement

# High Level
1. Implement Player
    * Code Camera Follow
    * Code Player Health & Health Bar
    * Code Player Stamina & Stamina Bar
    * Code Player Attack
    * Code Player Movement & Dash
2. Implement Enemies
    * Code EnemyAI
    * Code EnemyHealth
    * Code EnemySpawner
    * Code BossController
    * Code BossHealth
    * Code BossArenaTrigger
3. Implement GameManager
    * Code CurrencyManager
    * Code PotionManager
    * Code GameData, GameManager & SaveData
4. Implement Interface
    * Code Escape Menu
    * Code MenuController
6. Implement Quests
    * Code Quest, QuestManager, QuestLog
7. Implement World Surroundings
    * Code Interactions (Chest, Bonfire, NPC etc)
8. Implement SFX
    * Code AreaMusicTriger
    * Code FadeInSound
    * Code Player Sounds
9. Create Enemy Prefabs


# Implement Player

## Camera Follow [issue 53]
1. Add a camera object to the hierachy
2. code and add CameraFollow.cs to the camera object
3. Add Player object to the script
4. Committed code: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/CameraFollow.cs

https://github.com/user-attachments/assets/3119ed5f-6dcb-4ca9-adec-56c4de09c5fe


## Player Health [issue 9]
1. Add UI Image
2. Create Children Background and Foreground
3. Code and add script Player Health to Health object
4. Add images to the object
5. Committed Codes: 
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/PlayerHealth.cs

https://github.com/user-attachments/assets/c97c2fbd-9a99-416d-9f35-e915104c26a0


## Player Stamina [issue 44]
1. Add UI Image
2. Create Children Background and Foreground
3. Code and add script Player Stamina to Stamina object
4. Add images to the object
5. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/PlayerStamina.cs



## Player Attack [issue 9] [issue 20]
1. Add animation to the player gameobject
2. Attach Player attack script to the gameobject
3. Adjust code to run the animation via the Animator
4. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/RogueAttack.cs


## Player Movement & Dash [issue 20] [issue 28]
1. Add animation to the player gameobject
2. Attach Player Movement script to the gameobject
3. Adjust code to run the animation via the Animator
4. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/RogueMovement.cs

# Implement Enemies 

## EnemyAI [issue 10]
1. Create Enemy Object
2. Add sprites and animations to the object
3. Code and add the Enemy AI Script to the Enemy Object
4. Adjust the values in the script that is on the object
5. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/EnemyAI.cs

## EnemyHealth [issue 9]
1. Add UI Image
2. Create Children Background and Foreground
3. Code and add script Enemy Health to Health object
4. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/EnemyHealth.cs

## EnemySpawner [issue 10]
1. Create an empty gameobject
2. Place it to the spot you want your Enemies to idle at
3. Add the empty gameobject to the dedicated spot in the script
4. Adjust the values
5. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/EnemySpawner.cs

## BossController
1. Create Boss Object
2. Add sprites and animations to the object
3. Code and add the BossController Script to the Boss Object
4. Adjust the values in the script that is on the object
5. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/BossController.cs

## BossHealth
1. Add UI Image
2. Create Children Background and Foreground
3. Code and add script Boss Health to Health object
4. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/BossHealth.cs

## BossArenaTrigger
1. Create an empty gameobject
2. Define a box collider set to trigger
3. If Player enters that box collider area the Boss HP will appear
4. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/BossArenaTrigger.cs

# Implement GameManager

## CurrencyManager
1. Create a TMP Text object that defines the currency
2. Code the CurrencyManager
3. Create an empty object and add the CurrencyManager to it
4. Add the Text object to the object with the CurrencyManager
5. Committed code:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/CurrencyManager.cs

## PotionManager
1. Create a TMP text object that defines the current amount of potions
2. Create an image object, that switches between Health, Stamina and empty potion
3. Code and add PotionManager script to PotionManager object
4. Add image and text object to the PotionManager script
5. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Interface/InterfaceScripts/PotionManager.cs

## GameData, GameManager & SaveData
1. Create an empty object
2. Code and attach the GameManager script to the object
3. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/GameData.cs
    2. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/GameManager.cs
    3. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/SaveData.cs




[issue 8]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/8
[issue 9]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/9
[issue 10]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/10
[issue 20]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/20
[issue 28]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/28
[issue 44]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/44
[issue 53]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/53

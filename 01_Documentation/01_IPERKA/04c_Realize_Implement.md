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
    * Code Interactions (Treasurechest, Bonfire, NPC etc)
8. Implement SFX
    * Code AreaMusicTriger
    * Code FadeInSound
    * Code Player Sounds
9. Create Enemy Prefabs
10. Implement Testcases
11. List of issues encountered


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
1. Using the Flowchart from [issue 58] I created my script
2. Add animation to the player gameobject
3. Attach Player attack script to the gameobject
4. Adjust code to run the animation via the Animator
5. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/RogueAttack.cs


## Player Movement & Dash [issue 20] [issue 28]
1. Add animation to the player gameobject
2. Attach Player Movement script to the gameobject
3. Adjust code to run the animation via the Animator
4. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/RogueMovement.cs

# Implement Enemies 

## EnemyAI [issue 10]
1. Using the Flowchart from [issue 58] I created my script
2. Create Enemy Object
3. Add sprites and animations to the object
4. Code and add the Enemy AI Script to the Enemy Object
5. Adjust the values in the script that is on the object
6. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/EnemyAI.cs

## EnemyHealth [issue 9]
1. Add UI Image
2. Create Children Background and Foreground
3. Code and add script Enemy Health to Health object
4. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/EnemyHealth.cs

## EnemySpawner [issue 10]
1. Using the Flowchart from [issue 58] I created my script
2. Create an empty gameobject
3. Place it to the spot you want your Enemies to idle at
4. Add the empty gameobject to the dedicated spot in the script
5. Adjust the values
6. Committed codes:
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
1. Using the Flowchart from [issue 58] I created my script
2. Create an empty object
3. Code and attach the GameManager script to the object
4. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/GameData.cs
    2. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/GameManager.cs
    3. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/SaveData.cs

# Implement Interface

## EscapeMenu
1. Create a canvas
2. Create and attach 3 button objects to it
3. Name them Resume, Controls and Back to Menu
4. Code and attach EscapeMenu script to the canvas
5. Connect the button objects with the script
6. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Interface/InterfaceScripts/EscapeMenu.cs

## MainMenuController
1. Create a canvas
2. Create and attach 4 button objects to the canvas
3. Name them New Game, Load Game, Controls and Exit
4. Code and attach MainMenuController script to the canvas
5. Connect the button objects with the script
6. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Interface/InterfaceScripts/MainMenuController.cs


# Implement Quests

## Quest, QuestManager & QuestLog
1. Using the Flowchart from [issue 58] I created my script
2. Create a canvas
3. Add a button object that holds the Quest Name
4. Add a text object that holds the quest information
5. Code and attach QuestLog script to the canvas
6. Attach the button and text object to the script
7. Code a GameManager script
8. Create an empty gameobject and attach the GameManager script to it
9. Code a ScriptableObject Quest script
10. Create Quests in the Assets folder
11. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Quest/QuestScript/Quest.cs
    2. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Quest/QuestScript/QuestManager.cs
    3. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Quest/QuestScript/QuestLog.cs

# Implement World Surroundings

## Treasurechest, Bonfire & NPC
1. Create an empty object with the treasurechest Sprite attached to it
2. Code and attach the ChestInteraction script to it
3. Create an empty object with the bonfire Sprite attached to it
4. Code and attach the BonfireInteraction script to it
5. Create an object with the NPC sprites & animations attached to it
6. Code and attach the NPCQuestInteraction & AttackUpgradePanel script to it
7. Attach the ScriptableObject Quest script from ISSUE XX to the NPC that gives the Quests
8. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Items/ItemScripts/ChestInteraction.cs
    2. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/MapObjects/ObstacleScripts/BonfireInteraction.cs
    3. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/NPC/NPCScripts/NPCQuestInteraction.cs
    4.  https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/NPC/NPCScripts/AttackUpgradePanel.cs

# Implement SFX


# Issues encountered


[issue 8]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/8
[issue 9]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/9
[issue 10]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/10
[issue 20]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/20
[issue 28]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/28
[issue 44]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/44
[issue 53]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/53
[issue 58]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/58
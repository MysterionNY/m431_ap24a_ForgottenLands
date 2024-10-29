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
5. Implement Quests
    * Code Quest, QuestManager, QuestLog
6. Implement World Surroundings
    * Code Interactions (Treasurechest, Bonfire, NPC etc)
7. Implement SFX
    * Code AreaMusicTrigger
    * Code FadeInSound
    * Code Player/Enemy Sounds
8. Create Enemy Prefabs
9. Implement Background
10. Implement Testcases
11. List of bugs encountered
12. Glossary
13. References


# Implement Player

## Camera Follow [issue 53]
1. Add a camera object to the hierachy
2. Code and add CameraFollow.cs to the camera object
3. Add player object to the script
4. Committed code: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/CameraFollow.cs

https://github.com/user-attachments/assets/3119ed5f-6dcb-4ca9-adec-56c4de09c5fe


## Player Health [issue 9]
1. Add UI Image
2. Create children background and foreground
3. Code and add script player health to health object
4. Add images to the object
5. Committed Codes: 
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/PlayerHealth.cs

https://github.com/user-attachments/assets/c97c2fbd-9a99-416d-9f35-e915104c26a0


## Player Stamina [issue 44]
1. Add UI Image
2. Create children background and foreground
3. Code and add script player stamina to stamina object
4. Add images to the object
5. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/PlayerStamina.cs



https://github.com/user-attachments/assets/ac5ff147-da64-4a92-a96a-42fc10ba97ea



## Player Attack [issue 9] [issue 20]
1. Using the flowchart from [issue 58] I created my script
2. Add animation to the player object
3. Attach player attack script to the object
4. Adjust code to run the animation via the animator
5. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/RogueAttack.cs



https://github.com/user-attachments/assets/b9c1501b-a380-46db-8f70-7f61aa6e53f3



## Player Movement & Dash [issue 20] [issue 28]
1. Add animation to the player object
2. Attach player movement script to the object
3. Adjust code to run the animation via the animator
4. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/RogueMovement.cs



https://github.com/user-attachments/assets/09cf407f-cf4c-4c77-88dd-6ec0286b04de



# Implement Enemies 

## EnemyAI [issue 10]
1. Using the flowchart from [issue 58] I created my script
2. Create enemy object
3. Add sprites and animations to the object
4. Code and add the EnemyAI script to the enemy object
5. Adjust the values in the script that is on the object
6. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/EnemyAI.cs



https://github.com/user-attachments/assets/20dd670a-ff19-4214-9fb0-2eeb7211b1ef



## EnemyHealth [issue 9]
1. Code and add script EnemyHealth to enemy object
2. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/EnemyHealth.cs

## EnemySpawner [issue 10]
1. Using the flowchart from [issue 58] I created my script
2. Create an empty object
3. Place it to the spot you want your enemies to idle at
4. Add the empty object to the dedicated spot in the script
5. Adjust the values
6. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/EnemySpawner.cs

## BossController [issue 33]
1. Create boss object
2. Add sprites and animations to the object
3. Code and add the BossController script to the boss object
4. Adjust the values in the script that is on the object
5. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/BossController.cs
  


https://github.com/user-attachments/assets/f4d4c0cf-9cb2-4e59-921c-5277c9107aa6



## BossHealth [issue 33]
1. Add UI Image
2. Create Children Background and Foreground
3. Code and add script BossHealth to health object
4. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/BossHealth.cs



https://github.com/user-attachments/assets/e5bdf369-3bcd-4f5f-9305-574b7e1815da



## BossArenaTrigger [issue 34]
1. Create an empty object
2. Define a box collider set to trigger
3. If Player enters that box collider area the Boss HP will appear
4. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Enemy/EnemyScripts/BossArenaTrigger.cs



https://github.com/user-attachments/assets/7a0c8991-b5ce-473f-826e-2091b8727a5f



# Implement GameManager

## CurrencyManager [issue 63]
1. Create a TMP Text object that defines the currency
2. Code the CurrencyManager
3. Create an empty object and add the CurrencyManager to it
4. Add the text object to the object with the CurrencyManager
5. Committed code:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/CurrencyManager.cs

![Currency with Gold][currencyManagerWG]
![Currency with no Gold][currencyManagerNG]

## PotionManager [issue 29]
1. Create a TMP text object that defines the current amount of potions
2. Create an image object, that switches between health, stamina and empty potion
3. Code and add PotionManager script to PotionManager object
4. Add image and text object to the PotionManager script
5. PotionManager references to PlayerHP & PlayerStamina
6. Committed codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Interface/InterfaceScripts/PotionManager.cs
    2. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/PlayerHealth.cs
    3. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/PlayerStamina.cs



https://github.com/user-attachments/assets/2e9a999a-9f9b-4571-8d31-2b86bddd19c1



## GameData, GameManager & SaveData [issue 11]
1. Using the flowchart from [issue 58] I created my script
2. Create an empty object
3. Code and attach the GameManager script to the object
4. Encountered [issue 52], quest progress wasn't saved
5. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/GameData.cs
    2. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/GameManager.cs
    3. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/SaveData.cs



https://github.com/user-attachments/assets/7f9d3f87-2eca-4d65-a244-e45c1d012817



# Implement Interface

## EscapeMenu [issue 30]
1. Create a canvas
2. Create and attach 3 button objects to it
3. Name them "Resume", "Controls" and "Back to Menu"
4. Code and attach EscapeMenu script to the canvas
5. Connect the button objects with the script
6. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Interface/InterfaceScripts/EscapeMenu.cs

![Escapemenu][escapemenu]

## MainMenuController [issue 30]
1. Create a canvas
2. Create and attach 4 button objects to the canvas
3. Name them "New Game", "Load Game", "Controls" and "Exit"
4. Code and attach MainMenuController script to the canvas
5. Connect the button objects with the script
6. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Interface/InterfaceScripts/MainMenuController.cs

![Main menu][mainMenu]

# Implement Quests

## Quest, QuestManager & QuestLog [issue 31]
1. Using the flowchart from [issue 58] I created my script
2. Create a canvas
3. Add a button object that holds the quest name
4. Add a text object that holds the quest information
5. Code and attach QuestLog script to the canvas
6. Attach the button and text object to the script
7. Code a GameManager script
8. Create an empty object and attach the GameManager script to it
9. Code a scriptableobject quest script
10. Create quests in the assets folder
11. Encountered [issue 62], quest key can be collected before quest was accepted - Quest can't progress
12. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Quest/QuestScript/Quest.cs
    2. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Quest/QuestScript/QuestManager.cs
    3. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Quest/QuestScript/QuestLog.cs

![Questlog][questlog]
![Accept Quest][acceptQuest]
![Quest still active][questStillActive]

# Implement World Surroundings

## Treasurechest, Bonfire & NPC [issue 17] [issue 32] [issue 47] [issue 49]
1. Create an empty object with the treasurechest sprite attached to it
2. Code and attach the ChestInteraction script to it
3. Create an empty object with the bonfire sprite attached to it
4. Code and attach the BonfireInteraction script to it
5. Create an object with the NPC sprites & animations attached to it
6. Code and attach the NPCQuestInteraction & AttackUpgradePanel script to it
7. Attach the scriptableobject quest script from [issue 31] to the NPC that gives the quests
8. AttackUpgradePanel NPC references to PlayerAttack
9. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Items/ItemScripts/ChestInteraction.cs
    2. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/MapObjects/ObstacleScripts/BonfireInteraction.cs
    3. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/NPC/NPCScripts/NPCQuestInteraction.cs
    4. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/NPC/NPCScripts/AttackUpgradePanel.cs
    5. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/RogueAttack.cs



https://github.com/user-attachments/assets/8a727a73-70fc-41f2-9674-5e07be32f388



# Implement SFX

## AreaMusicTrigger [issue 36]
1. Create 2 empty objects
2. Add box collider to both of them
3. Place them side by side
4. Code and Attach the AreaMusicTrigger to both objects
5. Add the prefered sounds to both of the object's scripts
6. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/AreaMusicTrigger.cs

## FadeInSound
1. Create an empty object
2. Add a soundmixer to it
3. Code and attach the FadeInSound script to the object
4. Choose the music you want to be played
5. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/main/02_ForgottenLands/Assets/GameManager/FadeInAudio.cs

## Player/Enemy Sounds [issue 36]
1. _Attach a soundmixer to both the player and the enemy objects_
2. _Code and attach the PlayerSounds script to the the designated objects_
3. _Obtained sounds, I used soundsnap to obtain a few sounds, more can be found under the [issue 36] tab:_
    1. https://www.soundsnap.com/wind_blizzard_forest_woods_trees_winter_storm_snow_loop_blastwavefx_31873
    2. https://www.soundsnap.com/fire_an_intense_fire_raging_with_strong_flames_and_heavy_crackling_burning_house_or_other_large_structure_seamless_loop_wav
    3. https://www.soundsnap.com/gore_weapon_knife_slashing_no_gore_1
    4. https://www.soundsnap.com/builder_game_footstep_run_snow_2_wav

# Enemy Prefabs
1. Move the enemy object from the hierachy to the assets folder
2. Attach the prefab to the script from [issue 10]



https://github.com/user-attachments/assets/944f5c96-cad2-4e7d-bbee-874da1ef61b9



# Implement Background [issue 16]
1. Create a 2D tilemap object
2. Add Tilemap Renderer to it
3. Open Tile Palette
4. Implement the map

![Background 1][background1]
![Background 2][background2]

# Implement Testcases [issue 64]
1. By checking through the requirements, I created my testcases
![Testcase 1][testcases1]
![Testcase 2][testcases2]
![Testcase 3][testcases3]
![Testcase 4][testcases4]

# Bugs encountered
1. [issue 52] - SaveData - the quest progress wasn't saved by the save system
2. [issue 62] - Quest - Questkey can be collected before the quest was accepted, hence the quest progress didn't work

## Glossary
* HP = Health Points
* SFX = Sound effects
* Dash = Move from point A to point B quickly
* UI = User Interface
* Prefab = Fully functional objects which can be reused

## References
* Prevent scriptable objects from saving values inbetween sessions
    * Reddit
    * Retrieved: October 6, 2024
    * from: https://www.reddit.com/r/Unity3D/comments/hhfzqt/how_to_stop_scriptable_objects_from_saving/
* How to prevent faster movement when walking diagonally
    * Youtube
    * Retrieved: September 12, 2024
    * from: https://www.youtube.com/shorts/0cYjreg7dpg
* Create a Quest System with scriptable objects
    * Reddit
    * Retrieved: September 8, 2024
    * from: https://www.reddit.com/r/Unity2D/comments/qq6dlg/learn_to_create_a_storyquest_system_in_unity_and/
* Set up main menu buttons
    * Youtube
    * Retrieved: September 6, 2024
    * from: https://www.youtube.com/watch?v=DX7HyN7oJjE
* Set the hierachy of objects
    * Unity discussions
    * Retrieved: September 1, 2024
    * from: https://discussions.unity.com/t/walking-in-front-of-behind-object-with-conditions/832982
* Set up gitignore for Unity project Github
    * Youtube
    * Retrieved: August 28, 2024
    * from: https://www.youtube.com/watch?v=qpXxcvS-g3g&t


[issue 8]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/8
[issue 9]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/9
[issue 10]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/10
[issue 11]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/11
[issue 16]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/16
[issue 17]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/17
[issue 20]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/20
[issue 28]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/28
[issue 29]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/29
[issue 30]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/30
[issue 31]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/31
[issue 32]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/32
[issue 33]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/33
[issue 34]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/34
[issue 36]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/36
[issue 44]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/44
[issue 47]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/47
[issue 49]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/49
[issue 52]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/52
[issue 53]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/53
[issue 58]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/58
[issue 62]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/62
[issue 63]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/63
[issue 64]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/64

[testcases1]: ../02_Resources/Images/04c_Testcases1.png
[testcases2]: ../02_Resources/Images/04c_Testcases2.png
[testcases3]: ../02_Resources/Images/04c_Testcases3.png
[testcases4]: ../02_Resources/Images/04c_Testcases4.png
[currencyManagerNG]: ../02_Resources/Images/04c_CurrencyNoGold.png
[currencyManagerWG]: ../02_Resources/Images/04c_CurrencyWithGold.png
[escapeMenu]: ../02_Resources/Images/04c_EscapeMenu.png
[mainMenu]: ../02_Resources/Images/04a_MainMenuBackground.jpeg
[questlog]: ../02_Resources/Images/04c_QuestLog.png
[acceptQuest]: ../02_Resources/Images/04c_AcceptQuest.png
[questStillActive]: ../02_Resources/Images/04c_QuestStillActive.png
[background1]: ../02_Resources/Images/04c_background1.png
[background2]: ../02_Resources/Images/04c_background2.png
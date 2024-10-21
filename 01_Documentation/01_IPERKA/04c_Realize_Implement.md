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
3. Implement GameManager
    * Code a CurrencyManager
    * Code GameData, GameManager & SaveData
4. Implement Interface
    * Code Escape Menu
    * Code PotionManager
    * Code Tutorial
    * Code Minimap
6. Implement Quests
    * Code Quest, QuestManager, QuestLog
7. Implement World Surroundings
    * Code Interactions (Chest, Bonfire, NPC etc)
8. Implement SFX
    * Code FadeInSound
    * Code Player Sounds
9. Create Enemy Prefabs


# Implement Player

## Camera Follow [issue 53]
1. Add a camera object to the hierachy
2. code and add CameraFollow.cs to the camera object
3. Add Player object to the script
4. Committed code: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/1.0.0.0/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/CameraFollow.cs

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
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/1.0.0.0/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/RogueAttack.cs


## Player Movement & Dash [issue 20] [issue 28]
1. Add animation to the player gameobject
2. Attach Player Movement script to the gameobject
3. Adjust code to run the animation via the Animator
4. Committed Codes:
    1. https://github.com/MysterionNY/m431_ap24a_ForgottenLands/blob/1.0.0.0/02_ForgottenLands/Assets/Rogue_Character/CharacterScripts/RogueMovement.cs

# Implement Enemies 

## EnemyAI [issue 10]

## EnemyHealth [issue 9]




[issue 8]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/8
[issue 9]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/9
[issue 10]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/10
[issue 20]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/20
[issue 28]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/28
[issue 44]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/44
[issue 53]: https://github.com/MysterionNY/m431_ap24a_ForgottenLands/issues/53

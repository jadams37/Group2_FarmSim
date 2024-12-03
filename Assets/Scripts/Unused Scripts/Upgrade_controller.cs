using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_controller : MonoBehaviour
{
    /// This class tracks all in-game upgrades, such as 
    ///player level, player experience, barn level, tools level, and more. <summary>
    /// This class tracks all in-game upgrades, such as 
    
    int player_level { get; set; }
    int player_experience { get; set; }
    int barn_level {  get; set; }
    int tools_level { get; set; }
    bool is_active { get; set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void level_up_player()
    {
        if (is_active)
        {
            player_level++;
            player_experience = 0;
        }
    }
    int generate_needed_experience(int level)
    {
        if (is_active) {
            return player_level * 100;
        }
        return player_experience;
    }
    public void DisplayStatus()
    {
        Debug.Log("Player Level: " + player_level);
        Debug.Log("Player Experience: " + player_experience);
        Debug.Log("Barn Level: " + barn_level);
        Debug.Log("Tools Level: " + tools_level);
    }
}

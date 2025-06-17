using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int level = 1;
    public float currentExp = 0f;
    public float maxExp = 100f;
    public float currentHp = 100f;
    public float maxHp = 100f;
    public float currentAp = 50f;
    public float maxAp = 50f;
    public float attack = 10f;
    public float magic = 10f;
    public float defense = 10f;
    [Range(-100, 100)]
    public float dexterity = 0f; // Percentage based

    void Start()
    {
        UpdateStats();
    }

    public void TakeDamage(float amount)
    {
        currentHp -= amount;
        if (currentHp <= 0)
        {
            currentHp = 0;
            Die();
        }
        Debug.Log("Player took " + amount + " damage. Current HP: " + currentHp);
    }

    public void GainExp(float amount)
    {
        currentExp += amount;
        if (currentExp >= maxExp)
        {
            LevelUp();
        }
        Debug.Log("Player gained " + amount + " EXP. Current EXP: " + currentExp);
    }

    void LevelUp()
    {
        level++;
        currentExp -= maxExp; // Carry over remaining exp
        maxExp *= 1.2f; // Increase max exp for next level

        // Increase core stats on level up
        maxHp += 10;
        currentHp = maxHp;
        attack += 2;
        magic += 2;
        defense += 2;

        Debug.Log("Player Leveled Up! New Level: " + level);
        UpdateStats();
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // Implement game over logic
    }

    void UpdateStats()
    {
        // Logic to update UI or other systems based on stat changes
        Debug.Log($"Stats Updated: Level {level}, HP: {currentHp}/{maxHp}, AP: {currentAp}/{maxAp}, Atk: {attack}, Mgk: {magic}, Def: {defense}, Dex: {dexterity}%");
    }

    public void RestoreHp(float amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
        Debug.Log("HP Restored. Current HP: " + currentHp);
    }

    public void RestoreAp(float amount)
    {
        currentAp = Mathf.Min(currentAp + amount, maxAp);
        Debug.Log("AP Restored. Current AP: " + currentAp);
    }
}



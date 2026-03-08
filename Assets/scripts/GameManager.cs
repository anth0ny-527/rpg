using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
// Controls game flow and UI
public class GameManager : MonoBehaviour
{
    public TMP_Text playerHealthText;
    public TMP_Text enemyHealthText;
    public TMP_Text resultText;

    public AudioSource audioSource;
    public AudioClip damageSound;

    public Button attackButton;
    public Button defendButton;
    public Button healButton;

    public Button classfighterButton;
    public Button classtankButton;
    public Button classrogueButton;

    private Player player;
    private Enemy enemy;

    void Start()
    {
        // Create player and enemy objects
        player = new Player(100, 10, 5, 5);
        enemy = new Enemy(100, 12, 4, 4);

        // Disable action buttons until class is selected
        attackButton.interactable = false;
        defendButton.interactable = false;
        healButton.interactable = false;

        UpdateUI();
    }

    // ===== CLASS SELECTION =====

    public void ChooseTank()
    {
        player.SetStats(150, 20, 5, 15);
        EnableActionButtons();
UpdateUI();
    }

    public void ChooseFighter()
    {
        player.SetStats(120, 30, 15, 10);
        EnableActionButtons();
UpdateUI();
    }

    public void ChooseRogue()
    {
        player.SetStats(100, 35, 25, 5);
        EnableActionButtons();
UpdateUI();
    }

    void EnableActionButtons()
    {
        attackButton.interactable = true;
        defendButton.interactable = true;
        healButton.interactable = true;
    }

    // ===== PLAYER ACTIONS =====

    public void PlayerAttack()
    {
        int damage = player.Attack();
        enemy.TakeDamage(damage);
        audioSource.PlayOneShot(damageSound);

        if (enemy.IsDead())
        {
            EndGame();
            return;
        }

        EnemyTurn();
    }

    public void PlayerDefend()
    {
        player.Defend();
        EnemyTurn();
    }

    public void PlayerHeal()
    {
        player.Heal();
        EnemyTurn();
    }

    // ===== ENEMY TURN =====

    void EnemyTurn()
    {
print("turn");
        int action = enemy.ChooseAction();

        if (action == 0) // Attack
        {
            int damage = enemy.Attack();
            player.TakeDamage(damage);
            audioSource.PlayOneShot(damageSound);
        }
        else if (action == 1) // Defend
        {
            enemy.Defend();
        }
        else // Heal
        {
            enemy.Heal();
        }

        if (player.IsDead())
        {
            EndGame();
            return;
        }

        UpdateUI();
    }

    // ===== UI & GAME STATE =====

    void UpdateUI()
    {
        playerHealthText.text =
            "HP: " + player.CurrentHealth +
            "\nSTR: " + player.Strength +
            "\nDEF: " + player.Defense +
            "\nDEX: " + player.Dexterity;

        enemyHealthText.text =
            "HP: " + enemy.CurrentHealth +
            "\nSTR: " + enemy.Strength +
            "\nDEF: " + enemy.Defense +
            "\nDEX: " + enemy.Dexterity;
    }

    void EndGame()
    {
        if (player.IsDead())
            resultText.text = "You Lost!";
        else
            resultText.text = "You Won!";

        DisableButtons();
        UpdateUI();
    }

    void DisableButtons()
    {
        attackButton.interactable = false;
        defendButton.interactable = false;
        healButton.interactable = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
using UnityEngine;

public class QuestIndicatorController : MonoBehaviour
{
    public Sprite exclamationMark;
    public Sprite questionMarkGrey;
    public Sprite questionMarkGold;

    private SpriteRenderer spriteRenderer;
    public static QuestIndicatorController instance;

    // Once the game instance has started, these are the starting arguments
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Keeps one single instance of the object, even when loading out
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update quest indicators depending on the state of current quest
    // Parameter calls Queststate to check what the current quest state is
    public void UpdateQuestIndicator(QuestState state)
    {
        switch (state)
        {
            case QuestState.NotStarted:
                spriteRenderer.sprite = exclamationMark;
                break;
            case QuestState.Accepted:
                spriteRenderer.sprite = questionMarkGrey;
                break;
            case QuestState.Completed:
                spriteRenderer.sprite = questionMarkGold;
                break;
            default:
                spriteRenderer.sprite = null; // Hide indicator if no quest state applies
                break;
        }
    }
}
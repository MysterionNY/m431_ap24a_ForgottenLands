using UnityEngine;

public class QuestIndicatorController : MonoBehaviour
{
    public Sprite exclamationMark;
    public Sprite questionMarkGrey;
    public Sprite questionMarkGold;

    private SpriteRenderer spriteRenderer;
    public static QuestIndicatorController instance;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
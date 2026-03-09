using UnityEngine;
using UnityEngine.UIElements;

public class Score : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private int totalScore;

    private VisualElement root;
    private Label scoreLabel;

    void OnEnable()
    {
        totalScore = 0;
        root = uiDocument.rootVisualElement;
        scoreLabel = root.Q<Label>("scoreLabel");
        UpdateUI(0);
    }

    public void UpdateUI(int score)
    {
        scoreLabel.text = $"Score: {totalScore + score}";
        totalScore++;
    }
}

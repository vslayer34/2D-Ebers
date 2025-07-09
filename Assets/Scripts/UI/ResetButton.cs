using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    private Button _resetBtn;

    private float _endYPosition;
    private float _startYPosition = -300.0f;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _resetBtn = GetComponent<Button>();
    }

    private void Start()
    {
        _endYPosition = transform.position.y;

        transform.position = new(transform.position.x, _startYPosition, transform.position.z);

        _resetBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        // LeanTween.moveLocalY(gameObject, 100.0f, 2.0f);
    }

    private void OnEnable()
    {
        LeanTween.moveY(gameObject, 100.0f, 1.5f);
    }
}

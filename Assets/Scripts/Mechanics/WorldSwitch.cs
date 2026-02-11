using UnityEngine;
using UnityEngine.Events;

public class WorldSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite OffSprite;
    [SerializeField] private Sprite OnSprite;
    [SerializeField] private UnityEvent onActivated;

    private SpriteRenderer sRend;
    private bool isFlipped = false;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        isFlipped = !isFlipped;
        sRend.sprite = isFlipped ? OffSprite : OnSprite;
        if (isFlipped)
        {
            onActivated.Invoke();
        }
    }
}

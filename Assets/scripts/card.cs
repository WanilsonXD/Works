using UnityEngine;

public class Card : MonoBehaviour
{
    public string figureOfSpeech;
    public Sprite cardBack;
    public Sprite cardFront;
    public bool isFlipped = false;
    public int id; // Adicionei um ID para cada carta

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        FlipCard(false); // Inicialmente, a carta está virada para baixo
    }

    private void OnMouseDown()
    {
        if (!isFlipped)
        {
            FlipCard(true);
            FindObjectOfType<GameManager>().CardSelected(this);
        }
    }

    public void FlipCard(bool faceUp)
    {
        isFlipped = faceUp;
        spriteRenderer.sprite = faceUp ? cardFront : cardBack;
    }
}

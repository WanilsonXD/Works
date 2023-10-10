using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Card> cards;
    private Card firstCard;
    private Card secondCard;
    public int playerScore;

    private void Start()
    {
        Shuffle(cards);
    }

    private void Update()
    {
        if (secondCard == null)
            return;

        if (firstCard.id == secondCard.id)
        {
            Debug.Log("Match!");
            // Aumenta a pontuação do jogador
            playerScore += 10;
            firstCard.gameObject.SetActive(false);
            secondCard.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("No match!");
            // Diminui a pontuação do jogador
            playerScore -= 5;
            firstCard.FlipCard(false);
            secondCard.FlipCard(false);
        }

        firstCard = null;
        secondCard = null;
    }

    public void CardSelected(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else if (secondCard == null)
        {
            secondCard = card;
        }
    }

    // Função para embaralhar a ordem das cartas na lista
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

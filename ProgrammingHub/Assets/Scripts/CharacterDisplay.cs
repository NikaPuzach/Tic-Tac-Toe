using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TextField = TMPro.TextMeshProUGUI;

public class CharacterDisplay : MonoBehaviour
{
    public List<CharacterCard> characterCards;
    public TextField nameText;
    public Image playerPhoto;

    public Button next;
    public Button previous;


    //Какая команда выбирает игрока, с помощью этого экземпляра.
    public Player.Teams team;

    // Start is called before the first frame update
    public void Display(CharacterCard card)
    {
        MainManager.Instance.teamsToCharacters[team] = card;
        displayedCard = card;
        nameText.text = card.name;
        playerPhoto.sprite = card.photo;
    }
    private void Start()
    {
        var indexRandom = Random.Range(0, characterCards.Count);
        Display(characterCards[indexRandom]);

        next.onClick.AddListener(OnClickNext);
        previous.onClick.AddListener(OnClickPrevious);

    }
    //атрибут переменной 
    //[HideInInspector] 
    public CharacterCard displayedCard;
    public void OnClickNext()
    {
        var currentIndex = characterCards.IndexOf(displayedCard);
        if (currentIndex == characterCards.Count - 1)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }
        Display(characterCards[currentIndex]);
    }

    public void OnClickPrevious()
    {
        var currentIndex = characterCards.IndexOf(displayedCard);
        if (currentIndex == 0)
        {
            currentIndex = characterCards.Count - 1;
        }
        else
        {
            currentIndex--;
        }
        Display(characterCards[currentIndex]);
    }
}

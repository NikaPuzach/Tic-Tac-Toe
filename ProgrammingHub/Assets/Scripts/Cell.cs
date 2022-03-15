using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    //Создаем 2 переменные игровых объектов,
    //которым присваиваем в инспекторе соответствующие значения
    public Image chosenImage;
    public GameObject highLight;

    //Переменная для проверки клетки
    public bool isChecked;

    //Кто нажал клетку
    public Player touchedPlayer;

    //Метод, позволяющий проявить нужный объект на сцене
    public void OnPointerClick(PointerEventData eventData)
    {
        //Проверяем с помощью условного оператора была ли клетка проверена
        if (isChecked || GamePlayController.Instance.isOver)
            return;

        //Запоминаем, что клетка была проверена
        isChecked = true;

        //Создаем переменную какого именно персонажа выбрали + запоминаем кто нажал
        touchedPlayer = GamePlayController.Instance.chosenPlayer;

        //Пробуждаем конкретного выбранного персонажа (переменную инициализировали выше)
        //в конкретной клетке
        GameplayEvents.onCellChecked.Invoke(this, touchedPlayer.team);

        chosenImage.gameObject.SetActive(true);
        chosenImage.sprite =
            MainManager.Instance.teamsToCharacters[touchedPlayer.team].photo;

        //Переключаемся между игровыми объектами
        //switch (touchedPlayer.team)
        //{
        //    case Player.Teams.Circle:
        //        //Включаем этот игровой объект
        //        //turning this game object on 
        //        circle.gameObject.SetActive(true);
        //        circle.sprite = MainManager.Instance.teamsToCharacters[touchedPlayer.team].photo;
        //        break;

        //    case Player.Teams.Cross:
        //        cross.gameObject.SetActive(true);
        //        cross.sprite = MainManager.Instance.teamsToCharacters[touchedPlayer.team].photo;
        //        break;

        //    default:
        //        break;
        //}
    }
}

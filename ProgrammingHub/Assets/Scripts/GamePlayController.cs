using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class GamePlayController : MonoBehaviour
{
    public GameObject finishScreen;
    public Text winnerText;
    public Button restart;
    public Button backToMenu;
    

    //Свойство для пробуждения того или иного объекта
    public static GamePlayController Instance { get; private set; }

    //Список игроков
    public List <Player> players;

    private void Awake()
    {
        //Ссылка на свойство
        Instance = this;

        //Выбор персонажа с нулевым индексом
        ChoosePlayer(players[0]);

        //Кешируем ссылки на ячейки (в табле)
        cells = new Cell[,]
        {
            {cell00,cell01,cell02 },
            {cell10,cell11,cell12 },
            {cell20,cell21,cell22 }
        };
    }

    private void Start()
    {
        //Подписываемся на событие
        GameplayEvents.onCellChecked += OnCellChecked;

        restart.onClick.AddListener(OnClickRestart);
        backToMenu.onClick.AddListener(OnBackToMenu);
    }

    private void OnBackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnClickRestart()
    {
        SceneManager.LoadScene(1);
    }

    //Переменная конкретного выбранного игрока
    public Player chosenPlayer;

    //Метод, задающий выбранного игрока
    public void ChoosePlayer(Player player)
    {
        //Коретно выбранный игрок соотвествует игроку, которого укажут в аргументе
        chosenPlayer = player;
    }

    //Проверяем клетку и какая команда сейчас играет
    public void OnCellChecked(Cell cell, Player.Teams team)
    {
        if (CheckGameOver(out var winner))
        {
            //Вообще можно загрузить компонент, что человек выиграл/проиграл и возврат в главное меню/рестарт игры
            //SceneManager.LoadScene(0);
            if (winner == null)
            {
                winnerText.text = "It's a draw!";
                //это ничья - рестарт, возврат в главное меню
            }
            else
            {
                var name = MainManager.Instance.teamsToCharacters[winner.team].name;
                winnerText.text = $"{name} won!";
                //поздравление - рестарт, возврат в главное меню
            }

            finishScreen.SetActive(true);

        }
        else
        {
            //Индекс действующего игрока
            var index = players.IndexOf(chosenPlayer);
            if (index == players.Count - 1)
            {
                //Возврат в начало списка
                index = 0;
            }
            else
            {
                //След по списку
                index++;
            }
            //Выбираем игрока с определенным индексом, который указали выше
            ChoosePlayer(players[index]);
        }
    }

    private void OnDestroy()
    {
        //Отписываемся от события
        GameplayEvents.onCellChecked -= OnCellChecked;
    }

    [SerializeField] Cell   cell00,
                            cell01,
                            cell02,
                            cell10,
                            cell11,
                            cell12,
                            cell20,
                            cell21,
                            cell22;

    private Cell[,] cells;

    //Переводим клетки в нули и единицы
    public byte[,] TakeSnapShot(Player player)
    {
        var results = new byte[3,3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (cells[i, j].isChecked)
                {
                    if(player == cells[i, j].touchedPlayer)
                    {
                        results[i, j] = 1;
                    }
                    else
                    {
                        results[i, j] = 0;
                    }
                }
                else
                {
                    results[i, j] = 0;
                }
            }
        }
        return results;


    }


    //Чекнуть если все клетки заняты
    private bool CheckGameOver(out Player winner)
    {
        var snapShot = TakeSnapShot(chosenPlayer);

        foreach (var option in winOptions)
        {
            var check = CheckOption(snapShot, option);
            if (check)
            {
                var highLightCells = GetCells(option);
                winner = chosenPlayer;
                foreach (var cell in highLightCells)
                {
                    cell.highLight.SetActive(true);
                }
                return true;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(cells[i, j].isChecked == false)
                {
                    winner = null;
                    return false;
                }
            }
        }
        winner = null;
        return true;
        
    }

    private bool CheckOption(byte[,]snapShot, byte[,] winOptions )
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (winOptions[i, j] == 0)
                {
                    continue;
                }
                else if (snapShot[i, j] != 1)
                {
                    return false;
                }
                
            }
        }
        return true;
    }

}

public partial class GamePlayController
{
    //Создаем матрицы, в которых определяем двумерный массив
    public static byte[,] optionA = new byte[,]
    {
        {1,1,1 },
        {0,0,0 },
        {0,0,0 }
    };

    public static byte[,] optionB = new byte[,]
    {
        {0,0,0 },
        {1,1,1 },
        {0,0,0 }
    };

    public static byte[,] optionC = new byte[,]
    {
        {0,0,0 },
        {0,0,0 },
        {1,1,1 }
    };

    public static byte[,] optionD = new byte[,]
    {
        {1,0,0 },
        {1,0,0 },
        {1,0,0 }
    };

    public static byte[,] optionE = new byte[,]
    {
        {0,1,0 },
        {0,1,0 },
        {0,1,0 }
    };

    public static byte[,] optionF = new byte[,]
    {
        {0,0,1 },
        {0,0,1 },
        {0,0,1 }
    };

    public static byte[,] optionG = new byte[,]
    {
        {1,0,0 },
        {0,1,0 },
        {0,0,1 }
    };

    public static byte[,] optionH = new byte[,]
    {
        {0,0,1 },
        {0,1,0 },
        {1,0,0 }
    };

    //Список выйгрышных матриц 
    public static List<byte[,]> winOptions = new List<byte[,]>
        {optionA, optionB, optionC, optionD, optionE, optionF, optionG, optionH};


    //option - расклад
    public Cell[] GetCells(byte[,] option)
    {
        var result = new List<Cell>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (option[i, j] == 1)
                {
                    result.Add(cells[i, j]);
                }
            }
        }

        return result.ToArray();
    }
}



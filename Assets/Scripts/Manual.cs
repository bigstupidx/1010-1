using UnityEngine;
using System.Collections;

public class Manual : MonoBehaviour {

	public int index;
	public string[,] langPack = new string[,]{

		{"Gather figures,\n that shows the top",
			"To undo your last move, \n swipe left \n on the screen",
			"Score 500 points \n to open the hammer, \n which destroys \n 6x6 cubes",
			"The game ends \n if no valid moves",
			"To change theme\n shake device",
			"Congratulations!\n Now You are ready \n TO PLAY"},


		{"Собирайте фигуры,\n которые будут\n показаны сверху", 
			"Чтобы отменить ход,\n проведите влево \n по экруну",
			"Набери 500 очков,\n чтобы открыть молоточек,\n который уничтожает\n 6х6 кубиков",
			"Игра заканчивается, \nесли нет \nдопустимых ходов",
			"Чтобы изменить тему,\n потрусите устройство",
		"Поздравляем!,\n Теперь Вы готовы\n ИГРАТЬ"},



		{"Збирайте фігури,\n які будуть \nзображені зверху",
			"Щоб відмінити останній хід\n проведіть вліво\n по екрану",
			"Набери 500 очок, \n щоб відкрити молоточок, \n який знищує \n 6х6 кубиків",
			"Гра закінчується, \nякщо немає \nдоступних ходів",
			"Щоб змінити тему,\n потрусіть пристрій",
			"Вітаємо!,\n Тепер Ви готові\n ДО ГРИ"}

	};
	void Start(){
		switch (Application.systemLanguage.ToString()){
		case "Russian":
			GetComponent<TextMesh>().text = langPack[1,index];
			break;
		case "Ukrainian":
			GetComponent<TextMesh>().text = langPack[2,index];
			break;
		case "Belarusian":
			GetComponent<TextMesh>().text = langPack[1,index];
			break;
		default:
			GetComponent<TextMesh>().text = langPack[0,index];
			break;
		}
	}
	void OnMouseUp(){


		if (index == 4){
			Application.LoadLevel(1);
		}
		else Application.LoadLevel(Application.loadedLevel+1);
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel(Application.loadedLevel-1);
		}
	}
}

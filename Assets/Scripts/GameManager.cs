using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	private void Awake()
	{
		if (GameManager.instance != null)
		{
			Destroy (gameObject);
			return;
		}

		instance = this;
		SceneManager.sceneLoaded += LoadState;
		DontDestroyOnLoad(gameObject);
	}

	public List<Sprite> playerSprites;
	public List<Sprite> weaponSprites;
	public List<int> weaponPrices;
	public List<int> xpTable;

	public Player player;
	public Animator deathMenuAnim;
	public Animator winMenuAnim;

	public int pesos;
	public int experience;

	// Save State
	/*
	 * INT preferedSkin
	 * INT pesos
	 * INT experience
	 * INT weaponLevel
	 */

	public void SaveState()
	{
		string s = "";
		s += "0" + "|";
		s += pesos.ToString() + "|";
		s += experience.ToString() + "|";
		s += "0";

		PlayerPrefs.SetString("SaveState", s);


	}

	public void LoadState(Scene s, LoadSceneMode mode)
	{
		if (!PlayerPrefs.HasKey("SaveState"))
			return;

		string[] data = PlayerPrefs.GetString("SaveState").Split('|');
		pesos = int.Parse (data [1]);
		experience = int.Parse (data [1]);


	}

	public void Respawn()
	{
		deathMenuAnim.SetTrigger("Hide");
		UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
	}
}

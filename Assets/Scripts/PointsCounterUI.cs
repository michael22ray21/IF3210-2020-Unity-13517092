using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class PointsCounterUI : MonoBehaviour
{
	private Text pointsText;

	void Awake()
	{
		pointsText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		pointsText.text = "POINTS: " + GameMaster.playerPoints.ToString();
		Debug.Log(pointsText.text);
	}
}
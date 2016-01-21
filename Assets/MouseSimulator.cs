using UnityEngine;
using UnityEngine.UI;
public class MouseSimulator : MonoBehaviour 
{
	public RectTransform uImage;

	private void Update()
	{
		if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
		{
			Vector3 imgOffset = new Vector3( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0 );
			uImage.position += imgOffset;
		}
	}
}

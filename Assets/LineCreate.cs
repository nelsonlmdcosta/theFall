using UnityEngine;
using System.Collections;

public class LineCreate : MonoBehaviour 
{
	CustomLR line;

	int colliderID = 0;

	bool hooked = false;

	LayerMask mask;

	GameObject currentLineObject;

	private void Start()
	{
		mask = (1 << LayerMask.NameToLayer("LineConnectors")) | (1 << LayerMask.NameToLayer("Table"));
	}

	private void Update () 
	{
		if(hooked)
		{

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
			{
				if(Input.GetKeyDown(KeyCode.Mouse0))
				{
					if(hit.collider.CompareTag("LineConnector"))
					{
						if(hit.collider.GetInstanceID() != colliderID)
						{
							currentLineObject.transform.parent = gameObject.transform;
							line.SetPosition(1, hit.collider.transform.position + new Vector3(0,0.15f,0));
							hooked = false;
							return;
						}
					}
				}

					line.SetPosition(1, hit.point);

			}
			else
			{
				Destroy(currentLineObject);
				line = null;
				hooked = false;
			}

		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Mouse0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				RaycastHit hit;

				if(Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
				{				
					if(hit.collider.CompareTag("LineConnector"))
					{
						currentLineObject = new GameObject("LineRenderer", typeof(CustomLR));
						line = currentLineObject.GetComponent<CustomLR>();

						//line.SetWidth(0.1f, 0.1f);
						line.SetPosition(0, hit.collider.transform.position + new Vector3(0,0.15f,0));
						
						hooked = true;

						colliderID = hit.collider.GetInstanceID();
					}
				}
			}
		}
	}
}

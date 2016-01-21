using UnityEngine;
using System.Collections;

public class DropAt : MonoBehaviour 
{
	InterpolateTowards myCurrentItem;

	LayerMask itemMask;
	LayerMask itemConnectorMask;

    private void Start()
	{
		itemMask = (1 << LayerMask.NameToLayer("Items"));
		itemConnectorMask = (1 << LayerMask.NameToLayer("ItemConnectors") );
    }

	private void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //holding item
            if (myCurrentItem != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, itemConnectorMask))
                {
                    myCurrentItem.BeginInterpolation(hit.collider.transform.position, new Vector3(90, 0, 0));
                    myCurrentItem = null;
                }
            }
            else // not holding
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, itemMask))
                {
                    myCurrentItem = hit.collider.GetComponent<InterpolateTowards>();
                }
            }
        }
	}
}

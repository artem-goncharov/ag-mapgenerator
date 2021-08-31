using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileLocator : MonoBehaviour
{
    public TMP_InputField tileName;

    public void LocateTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit)
        {
            GameObject hitGameObject = hit.collider.gameObject;

            // Debug.Log(hitGameObject.GetComponent<SpriteRenderer>().sprite.name);

            tileName.text = hitGameObject.GetComponent<SpriteRenderer>().sprite.name;
        }
    }
}

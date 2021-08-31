using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonRead : MonoBehaviour
{
    public TextAsset jsonFile;

    public GameObject mapCarrier;
    public GameObject tilePrefab;

    void Start()
    {
        ListFull map = JsonUtility.FromJson<ListFull>(jsonFile.text);

        Transform mapCarrierTransform = mapCarrier.transform;

        float parentXPos = mapCarrierTransform.position.x;
        float parentYPos = mapCarrierTransform.position.y;
        float parentZPos = mapCarrierTransform.position.z;

        string tileSpriteLoc = "Sprites/";

        foreach (ListElement tile in map.List)
        {
            // Debug.Log(tile.Id + " | " + tile.Type + " | " + tile.X + " | " + tile.Y + " | " + tile.Width + " | " + tile.Height);
            // Debug.Log(" --- ");

            GameObject newTileGO = Instantiate(tilePrefab, new Vector3(parentXPos + tile.X, parentYPos + tile.Y, parentZPos), Quaternion.identity) as GameObject;

            SpriteRenderer tileSpriteR = newTileGO.GetComponent<SpriteRenderer>();
            tileSpriteR.sprite = Resources.Load<Sprite>(tileSpriteLoc + tile.Id) as Sprite;
        }
    }
}

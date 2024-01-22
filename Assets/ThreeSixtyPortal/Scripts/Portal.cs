using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    public GameObject Room;
    public Material[] RoomMaterials;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Material mat in RoomMaterials)
        {
            mat.SetInt("stest", (int)CompareFunction.Equal);
        }
    }

    void OnTriggerStay(Collider collide)
    {
        if (collide.gameObject.CompareTag("MainCamera"))
        {
            foreach (Material mat in RoomMaterials)
            {
                if (transform.position.z > collide.transform.position.z) mat.SetInt("stest", (int)CompareFunction.Equal);
                else mat.SetInt("stest", (int)CompareFunction.NotEqual);
            }
            //GetChildRecursive(Room, transform.position.z > collide.transform.position.z);
        }

    }

    private void GetChildRecursive(GameObject obj, bool equal)
    {
        if (null == obj)
            return;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;
            List<Material> myMaterials = child.gameObject.GetComponent<Renderer>().materials.ToList();
            foreach (Material mat in myMaterials)
            {
                if (equal) mat.SetInteger("stest", (int)CompareFunction.Equal);
                else mat.SetInteger("stest", (int)CompareFunction.NotEqual);
            }
            GetChildRecursive(child.gameObject, equal);
        }
    }
}

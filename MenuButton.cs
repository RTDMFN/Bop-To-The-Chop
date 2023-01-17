using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private void OnMouseOver(){
        this.transform.localScale = new Vector3(1.2f,1.2f,1);
    }

    private void OnMouseExit(){
        this.transform.localScale = Vector3.one;
    }

    public void OnMouseDown(){
        
    }
}

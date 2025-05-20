using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
 [SerializeField]
    private GameObject gameover;
    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.gameover.SetActive(true);
    }

}

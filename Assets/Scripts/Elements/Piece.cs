using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Piece : MonoBehaviour
{
    private GameDirector gameDirector;
    public TextMeshPro healthTMP;
    public Vector2 startHealthRange;

    public int startHealth;
    private int _cureHealth;
    public SpriteRenderer sr;

  

    public void Init()
    {
        gameDirector = FindObjectOfType<GameDirector>();
        startHealth = Mathf.RoundToInt(UnityEngine.Random.Range(startHealthRange.x, startHealthRange.y));
        healthTMP.text = startHealth.ToString();
        _cureHealth = startHealth;
    }

    public void ReduceHealth()
    {
        _cureHealth -= 1;
        UpdateHealthText();
        if (_cureHealth <= 0)
        {
            DestroyPiece();
        }
    }

    public void UpdateHealthText()
    {
        healthTMP.text = _cureHealth.ToString();
        gameDirector.audioManager.PlayDamageAS();
        healthTMP.transform.DOKill();
        healthTMP.transform.localScale = Vector3.one;
        healthTMP.transform.DOScale(1.2f, .15f).SetLoops(2, LoopType.Yoyo);
        
        sr.DOKill();
        sr.color = new Color(1,1,1,.27f);
        sr.DOColor(Color.red, .1f).SetLoops(2, LoopType.Yoyo);
    }

    private void DestroyPiece()
    {
        gameObject.SetActive(false);
    }
}

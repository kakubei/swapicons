using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerAction : MonoBehaviour {

    [SerializeField]
    private Sprite altIcon;
    private SpriteRenderer _spriteRenderer;
    private Sprite originalIcon;
    
    void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        originalIcon = _spriteRenderer.sprite;
    }

    IEnumerator SwapIcons(Sprite newIcon) {
        float duration = 0.2f;
        Color c = _spriteRenderer.material.color;
        for (float timer = 0; timer < duration; timer += Time.deltaTime) {
            c = Color.Lerp(_spriteRenderer.color,Color.clear,timer/duration);

            _spriteRenderer.material.color = c;
            yield return null;
        }

        _spriteRenderer.sprite = newIcon;
        
        for (float timer = 0; timer < duration; timer += Time.deltaTime) {
            c = Color.Lerp( Color.clear, _spriteRenderer.color,timer/duration);

            _spriteRenderer.material.color = c;
            yield return null;
        }
    }
    
    private void ChangeSprite(Sprite newSprite) {
        StartCoroutine(SwapIcons(newSprite));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            ChangeSprite(altIcon);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        ChangeSprite(originalIcon);
    }
}

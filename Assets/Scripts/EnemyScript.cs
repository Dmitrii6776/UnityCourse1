using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject explosionFX;

    [SerializeField] private Transform fxParent;

    private ScoreScript _score;
    // Start is called before the first frame update
    void Start()
    {
        _score = FindObjectOfType<ScoreScript>();
    }

    private void OnParticleCollision(GameObject other)
    {
        var fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        fx.transform.parent = fxParent;
        Destroy(gameObject);
        _score.ScoreHit();
    }
}

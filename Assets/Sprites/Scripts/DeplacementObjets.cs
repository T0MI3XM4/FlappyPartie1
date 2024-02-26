using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementObjets : MonoBehaviour
{
    public float vitesse;
    public float positionFin;
    public float positionDebut;
    public float deplacementAleatoire;


    // Conditionnelle qui fait avancer le ciel, le nuage et les colonnes
    void Update()
    {
        transform.Translate(vitesse, 0f, 0f);

        if (transform.position.x < positionFin)
        {
            float valeurAleatoireY = Random.Range(-deplacementAleatoire, deplacementAleatoire);  // Génère une valeur aléatoire
            transform.position = new Vector2(positionDebut, valeurAleatoireY);  // positionnement vertical de l'objet

            transform.position = new Vector3(positionDebut, transform.position.y, 0);

        }


    }
}

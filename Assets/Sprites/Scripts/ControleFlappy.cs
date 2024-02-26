using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFlappy : MonoBehaviour
{
    public float vitesseX;
    public float vitesseY;

    public Sprite flappyBlesse;
    public Sprite flappyNormal;

    public GameObject pieceOr;
    public GameObject packVie;
    public GameObject champignon;


    // Bouger Flappy à l'aide des touches et des flèches du clavier
    void Update()
    {
        // La flèche de gauche ou la touche A fait reculer Flappy
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
                vitesseX = -1;
        }
        
        // La flèche de droite ou la touche D fait avancer Flappy
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
                vitesseX = 1;
        }

        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;
        }

        // La flèche de haut ou la touche W fait sauter Flappy
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
                vitesseY = 3;
        }

        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);
    }


    // Condition pour les détections de collision
    void OnCollisionEnter2D(Collision2D infoOjetFlappy)
    {
        // Si Flappy touche une colonne, son sprite se change et il devient blessé
        if (infoOjetFlappy.gameObject.name == "Colonne")
        {
            GetComponent<SpriteRenderer>().sprite = flappyBlesse;
        }
        
        // Si Flappy touche une piece d'or, celle-ci disparait
        if (infoOjetFlappy.gameObject.name == "PieceOr")
        {
            infoOjetFlappy.gameObject.SetActive(false);
            Invoke("ActiverPieceOr", 7f);

            float  valeurAleatoireY = Random.Range(-1, 1);  // Génère une valeur aléatoire
            infoOjetFlappy.gameObject.transform.position  =  new Vector2 (transform.position.x, valeurAleatoireY);	// positionnement vertical de l'objet
        }

        // Si Flappy touche un pack de vie, son sptite redevien normal et le pack de vie disparait
        if (infoOjetFlappy.gameObject.name == "PackVie")
        {
            GetComponent<SpriteRenderer>().sprite = flappyNormal;

            infoOjetFlappy.gameObject.SetActive(false);
            Invoke("ActiverPackVie", 7f);
        }

        // Si Flappy touche un champignon, celui-ci disparait et Flappy grossit pendant quelques secondes
        if (infoOjetFlappy.gameObject.name == "Champignon")
        {
            infoOjetFlappy.gameObject.SetActive(false);
            Invoke("ActiverChampignon", 7f);

            transform.localScale *= 1.3f;
            Invoke("TailleFlappy", 12f);
        }

    }

        // Fonction fait réapparaître la pièce d'or après quelques secondes
        void ActiverPieceOr()
        {
            pieceOr.SetActive(true);
        }

        // Fonction fait réapparaître la pièce d'or après quelques secondes
        void ActiverPackVie()
        {
            packVie.SetActive(true);
        }

        // Fonction fait réapparaître la pièce d'or après quelques secondes
        void ActiverChampignon()
        {
            champignon.SetActive(true);
        }

        // Fonction réduit la taille de flappy à sa taille original
        void TailleFlappy()
        {
            transform.localScale /= 1.3f;	 
        }







}

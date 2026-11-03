using OpenGLDotNet;
using System;

namespace NEO_PONG.CODE;

public class JOUEUR_1
{
    public const double LARGEUR = TABLE.LARGEUR_VOIE * 1.7;
    public const double HAUTEUR = LARGEUR * 1.2;

    public static uint Texture_Idle_01;
    public static uint Texture_Idle_02;
    public static uint Texture_Idle_03;
    public static uint Texture_Idle_04;

    public static uint Texture_Swing_01;
    public static uint Texture_Swing_02;
    public static uint Texture_Swing_03;
    public static uint Texture_Swing_04;

    public static uint Texture_Photo;
    public static uint Texture_Vie_Plein;
    public static uint Texture_Vie_Vide;

    public const int DUREE_SWING = 200; // durée du swing, en nombre d'images affichées
    public static int Compteur_Texture = 0; // avancement de l'animation (choix de la texture)
    public static int Compteur_Swing = DUREE_SWING; // décompte jusqu'à la fin du swing

    public static int Vies = 3;
    public static bool Peut_Enlever_Une_Vie = true; // évite de perdre plusieurs vies sur une même balle

    public static int Voie = 0; // -1 gauche, 0 milieu, 1 droite
    public static bool Swing_En_Cours = false;

    public static double R = 0;
    public static double V = 0;
    public static double B = 1;

    public const double TAILLE_PHOTO = 5.0;
    public const double LARGEUR_VIE = TAILLE_PHOTO / 3;
    public const double HAUTEUR_VIE = 1;

    /// <summary>
    /// Remet le joueur à son état de départ : 3 vies, voie centrale.
    /// </summary>
    public static void Initialise_Toi()
    {
        Vies = 3;
        Voie = 0;
        Peut_Enlever_Une_Vie = true;
    }

    /// <summary>
    /// Dessine le joueur, sa photo et ses points de vie.
    /// Le personnage est animé sur 4 images (idle ou swing selon l'état),
    /// et le décompte du swing avance à chaque appel tant qu'il est en cours.
    /// </summary>
    public static void Affiche_Toi()
    {
        uint Texture_Personnage;
        uint Texture_Vie;

        //personnage
        GL.Color3d(R, V, B);
        if (Swing_En_Cours) {
            Texture_Personnage = Texture_Swing_01;
            if (Compteur_Texture > DUREE_SWING * 0.25) Texture_Personnage = Texture_Swing_02;
            if (Compteur_Texture > DUREE_SWING * 0.5) Texture_Personnage = Texture_Swing_03;
            if (Compteur_Texture > DUREE_SWING * 0.75) Texture_Personnage = Texture_Swing_04;
            if (Compteur_Texture > DUREE_SWING) Compteur_Texture = 0;
        }
        else {
            Texture_Personnage = Texture_Idle_01;
            if (Compteur_Texture > DUREE_SWING * 0.25) Texture_Personnage = Texture_Idle_02;
            if (Compteur_Texture > DUREE_SWING * 0.5) Texture_Personnage = Texture_Idle_03;
            if (Compteur_Texture > DUREE_SWING * 0.75) Texture_Personnage = Texture_Idle_04;
            if (Compteur_Texture > DUREE_SWING) Compteur_Texture = 0;
        }
        OUTILS.Affiche_Sprite(Texture_Personnage, Voie * TABLE.LARGEUR_VOIE, (-TABLE.HAUTEUR / 2), 0, LARGEUR, HAUTEUR);
        Compteur_Texture++;

        //photo
        OUTILS.Affiche_Sprite(Texture_Photo, (-SCENE.LARGEUR / 2) + (TAILLE_PHOTO / 2), (SCENE.HAUTEUR / 2) - (TAILLE_PHOTO / 2), 0, TAILLE_PHOTO, TAILLE_PHOTO);

        //points de vie
        for (int Compteur = 0; Compteur < 3; Compteur++) {
            if (Compteur >= Vies) {
                GL.Color3d(0, .3, 0);
                Texture_Vie = Texture_Vie_Vide;
            }
            else {
                GL.Color3d(0, .6, 0);
                Texture_Vie = Texture_Vie_Plein;
            }
            OUTILS.Affiche_Sprite(Texture_Vie, (-SCENE.LARGEUR / 2) + (LARGEUR_VIE / 2) + (LARGEUR_VIE * Compteur), (SCENE.HAUTEUR / 2) - TAILLE_PHOTO - HAUTEUR_VIE / 2, 0, LARGEUR_VIE, HAUTEUR_VIE);
        }

        if (Swing_En_Cours) Compteur_Swing--;
    }

    /// <summary>
    /// Déplace le joueur sur la voie indiquée.
    /// </summary>
    public static void Change_De_Voie(int Voie)
    {
        JOUEUR_1.Voie = Voie;
    }

    /// <summary>
    /// Déclenche un swing sur la voie indiquée (ignoré si un swing est déjà en cours).
    /// Le personnage est assombri pendant le swing.
    /// </summary>
    /// <param name="Voie">Voie sur laquelle le joueur frappe.</param>
    public static void Swing(int Voie)
    {
        if (Swing_En_Cours) {
            return;
        }

        Compteur_Texture = 0;

        Swing_En_Cours = true;
        Change_De_Voie(Voie);
        B = .5;
    }
}

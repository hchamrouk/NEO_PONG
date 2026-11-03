using OpenGLDotNet;
using System;

namespace NEO_PONG.CODE;

public class BALLE
{
    public static uint Texture;

    public static int Voie = 0; // -1 gauche, 0 milieu, +1 droite
    public static int Cote = 1; // +1 côté adversaire, -1 côté joueur
    public static double Vitesse = .0025;
    public const double PAS = .00005; // augmentation de la vitesse
    public const double TAILLE = .7;

    public static double X = Voie * TABLE.LARGEUR_VOIE;
    public static double Y = Cote * TABLE.HAUTEUR / 2;

    // necessaire pour le calcul du vecteur (pour pouvoir bouger la balle)
    public static double Distance_X;
    public static double Distance_Y;

    public static bool En_Mouvement = false;
    public static bool Est_Swingable = true;
    public static double Marge_Erreur = .25;

    /// <summary>
    /// Réinitialise la balle à son état de départ : voie centrale,
    /// côté adversaire, vitesse initiale et à l'arrêt.
    /// </summary>
    public static void Initialise_Toi()
    {
        Voie = 0;
        Cote = 1;
        Vitesse = .0025;
        X = Voie * TABLE.LARGEUR_VOIE;
        Y = Cote * TABLE.HAUTEUR / 2;
        En_Mouvement = false;
        Est_Swingable = true;
    }

    /// <summary>
    /// Dessine la balle à l'écran (sprite OpenGL) à sa position actuelle.
    /// </summary>
    public static void Affiche_Toi()
    {
        GL.Color3d(.5, .5, .5);
        OUTILS.Affiche_Sprite(Texture, X, Y, 0, TAILLE, TAILLE);
    }

    /// <summary>
    /// Replace la balle en position de service, sur la voie du milieu,
    /// du côté indiqué.
    /// </summary>
    /// <param name="Cote">Côté du service : +1 adversaire, -1 joueur.</param>
    public static void Retour_Au_Service(int Cote)
    {
        Voie = 0;
        BALLE.Cote = Cote;

        X = Voie * TABLE.LARGEUR_VOIE;
        Y = BALLE.Cote * TABLE.HAUTEUR / 2;
    }

    /// <summary>
    /// Prépare le déplacement de la balle vers une nouvelle voie, sur le côté opposé.
    /// Calcule la distance à parcourir jusqu'à la cible et lance le mouvement.
    /// </summary>
    /// <param name="Voie">Voie de destination : -1 gauche, 0 milieu, +1 droite.</param>
    public static void Deplace_Toi(int Voie)
    {
        BALLE.Voie = Voie;
        Cote = -Cote;

        double X2 = BALLE.Voie * TABLE.LARGEUR_VOIE;
        double Y2 = Cote * TABLE.HAUTEUR / 2;

        Distance_X = X2 - X;
        Distance_Y = Y2 - Y;

        En_Mouvement = true;
    }
}

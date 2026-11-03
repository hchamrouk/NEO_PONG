using OpenGLDotNet;
using System;

namespace NEO_PONG.CODE;

public class SCENE
{
    const int FENETRE_LARGEUR = 800;
    const int FENETRE_HAUTEUR = 600;
    public const double DEMI_HAUTEUR = 10.0;
    public const double LARGEUR = FENETRE_LARGEUR / (FENETRE_HAUTEUR / (DEMI_HAUTEUR * 2)); // garde le ratio de la fenêtre
    public const double HAUTEUR = DEMI_HAUTEUR * 2;

    public static uint Texture_Jeu;

    public static uint Texture_Menu;
    public static uint Texture_Menu_Titre;
    public static uint Texture_Menu_Bouton_Solo;
    public static uint Texture_Menu_Bouton_Solo_Alt;
    public static uint Texture_Menu_Bouton_Multi;
    public static uint Texture_Menu_Bouton_Multi_Alt;
    public static uint Texture_Menu_Direction;

    public static uint Texture_Game_Over;
    public static uint Texture_Game_Over_Bouton_Menu;
    public static uint Texture_Game_Over_Bouton_Menu_Alt;
    public static uint Texture_Game_Over_Bouton_Quitter;
    public static uint Texture_Game_Over_Bouton_Quitter_Alt;
    public static uint Texture_Game_Over_Gagnant_1;
    public static uint Texture_Game_Over_Gagnant_2;
    public static uint Texture_Game_Over_Gagnant_3;

    public static bool Game_Over = false;
    public static bool Menu = true;
    public static int Bouton = -1; // bouton survolé, -1 si aucun
    public static int Choix_Mode = Bouton;
    public static int Compteur_Service = 0; // délai avant que l'ordinateur serve

    /// <summary>
    /// Dessine le fond de la scène de jeu.
    /// </summary>
    public static void Affiche_Toi()
    {
        GL.Color3d(.2, .2, .2);
        OUTILS.Affiche_Sprite(Texture_Jeu, 0, 0, 0, LARGEUR, HAUTEUR);
    }

    /// <summary>
    /// Dessine l'écran de fin de partie : titre, message du gagnant
    /// et boutons "Menu" / "Quitter" (mis en évidence selon le bouton survolé).
    /// </summary>
    /// <param name="Gagnant">-1 si le joueur 1 gagne, 1 si le joueur 2 gagne.</param>
    public static void Affiche_Game_Over(int Gagnant)
    {
        uint Bouton_1;
        uint Bouton_2;

        uint Texture_Gagnant;

        GL.Color3d(.6, .6, .6);
        OUTILS.Affiche_Sprite(Texture_Menu, 0, 0, 0, LARGEUR, HAUTEUR);

        GL.Color3d(0, 0, .9);
        OUTILS.Affiche_Sprite(Texture_Game_Over, 0, (HAUTEUR / 2) - 5 / 2 - 2, 0, LARGEUR - 3, 5);

        // Message du gagnant (en solo, une seule texture est utilisée dans le dernier cas)
        if (Choix_Mode == 0 && Gagnant == -1) {
            GL.Color3d(0, .9, 0);
            Texture_Gagnant = Texture_Game_Over_Gagnant_1;
        }
        else if (Choix_Mode == 0 && Gagnant == 1) {
            GL.Color3d(0, .6, 0);
            Texture_Gagnant = Texture_Game_Over_Gagnant_2;
        }
        else {
            GL.Color3d(0, .3, 0);
            Texture_Gagnant = Texture_Game_Over_Gagnant_3;
        }
        OUTILS.Affiche_Sprite(Texture_Gagnant, 0, (HAUTEUR / 2) - 5 / 2 - 5 - 2 - 1, 0, LARGEUR - 3, 5);

        if (Bouton == 0) {
            GL.Color3d(0, .6, 0);
            Bouton_1 = Texture_Game_Over_Bouton_Menu_Alt;
        }
        else {
            GL.Color3d(0, .3, 0);
            Bouton_1 = Texture_Game_Over_Bouton_Menu;
        }
        OUTILS.Affiche_Sprite(Bouton_1, -(LARGEUR - 4.5) / 4 - 1.5 / 2, (HAUTEUR / 2) - 5 / 2 - 10 - 2 - 2, 0, (LARGEUR - 4.5) / 2, 5);

        if (Bouton == 1) {
            GL.Color3d(0, .6, 0);
            Bouton_2 = Texture_Game_Over_Bouton_Quitter_Alt;
        }
        else {
            GL.Color3d(0, .3, 0);
            Bouton_2 = Texture_Game_Over_Bouton_Quitter;
        }
        OUTILS.Affiche_Sprite(Bouton_2, (LARGEUR - 4.5) / 4 + 1.5 / 2, (HAUTEUR / 2) - 5 / 2 - 10 - 2 - 2, 0, (LARGEUR - 4.5) / 2, 5);
    }

    /// <summary>
    /// Dessine le menu principal : titre, boutons "Multi" / "Solo"
    /// (mis en évidence selon le bouton survolé) et l'image des directions.
    /// </summary>
    public static void Affiche_Menu()
    {
        uint Bouton_1;
        uint Bouton_2;

        GL.Color3d(.6, .6, .6);
        OUTILS.Affiche_Sprite(Texture_Menu, 0, 0, 0, LARGEUR, HAUTEUR);

        GL.Color3d(0, 0, .9);
        OUTILS.Affiche_Sprite(Texture_Menu_Titre, 0, (HAUTEUR / 2) - 5 / 2 - 2, 0, LARGEUR - 3, 5);

        if (Bouton == 0) {
            GL.Color3d(0, .6, 0);
            Bouton_1 = Texture_Menu_Bouton_Multi_Alt;
        }
        else {
            GL.Color3d(0, .3, 0);
            Bouton_1 = Texture_Menu_Bouton_Multi;
        }
        OUTILS.Affiche_Sprite(Bouton_1, -(LARGEUR - 4.5) / 4 - 1.5 / 2, (HAUTEUR / 2) - 5 / 2 - 5 - 2 - 1, 0, (LARGEUR - 4.5) / 2, 5);

        if (Bouton == 1) {
            GL.Color3d(0, .6, 0);
            Bouton_2 = Texture_Menu_Bouton_Solo_Alt;
        }
        else {
            GL.Color3d(0, .3, 0);
            Bouton_2 = Texture_Menu_Bouton_Solo;
        }
        OUTILS.Affiche_Sprite(Bouton_2, (LARGEUR - 4.5) / 4 + 1.5 / 2, (HAUTEUR / 2) - 5 / 2 - 5 - 2 - 1, 0, (LARGEUR - 4.5) / 2, 5);

        GL.Color3d(.9, 0, 0);
        OUTILS.Affiche_Sprite(Texture_Menu_Direction, 0, (HAUTEUR / 2) - 5 / 2 - 10 - 2 - 2, 0, LARGEUR - 3, 5);
    }

    /// <summary>
    /// Définit le bouton actuellement sélectionné.
    /// </summary>
    /// <param name="Bouton">Indice du bouton (0 ou 1), -1 pour aucun.</param>
    public static void Change_Bouton(int Bouton)
    {
        SCENE.Bouton = Bouton;
    }

    /// <summary>
    /// Désélectionne le bouton après un clic.
    /// </summary>
    public static void Clique_Bouton()
    {
        Bouton = -1;
    }

    /// <summary>
    /// Renvoie un nombre aléatoire entre 0 et 9.
    /// </summary>
    public static int Nombre_Aleatoire()
    {
        return new Random().Next(10);
    }

    /// <summary>
    /// Boucle de jeu du mode deux joueurs : affiche la scène, puis met à jour
    /// la balle (déplacement, renvois, vies perdues, fin de partie, retour au service)
    /// et termine les animations de swing.
    /// </summary>
    public static void Mode_Joueur_Contre_Joueur()
    {
        SCENE.Affiche_Toi();

        JOUEUR_2.Affiche_Toi();

        TABLE.Affiche_Toi();
        //TABLE.Affiche_Tes_Voies();

        JOUEUR_1.Affiche_Toi();

        BALLE.Affiche_Toi();

        //==============================================
        if (BALLE.En_Mouvement && !SCENE.Game_Over) {
            BALLE.X += BALLE.Distance_X * BALLE.Vitesse;
            BALLE.Y += BALLE.Distance_Y * BALLE.Vitesse;

            // condition de fin
            if (JOUEUR_1.Vies == 0 || JOUEUR_2.Vies == 0) {
                BALLE.En_Mouvement = false;
                SCENE.Game_Over = true;
            }

            // bon swing : le joueur du bon côté frappe sur la bonne voie, au bon moment
            if (
                JOUEUR_1.Swing_En_Cours
                && JOUEUR_1.Voie == BALLE.Voie
                && BALLE.Cote == -1
                && BALLE.Est_Swingable
                && BALLE.Y < 0
                ||
                JOUEUR_2.Swing_En_Cours
                && JOUEUR_2.Voie == BALLE.Voie
                && BALLE.Cote == 1
                && BALLE.Est_Swingable
                && BALLE.Y > 0
                ) {
                BALLE.Deplace_Toi((Nombre_Aleatoire() % 3) - 1);
                BALLE.Vitesse += BALLE.PAS;
            }

            // vies : la balle est passée derrière un joueur
            if (
                BALLE.Cote == -1
                && BALLE.Y < -(TABLE.HAUTEUR / 2) - BALLE.Marge_Erreur
                && JOUEUR_1.Peut_Enlever_Une_Vie
                ) {
                JOUEUR_1.Vies--;
                JOUEUR_1.Peut_Enlever_Une_Vie = false;
            }
            if (
                BALLE.Cote == 1
                && BALLE.Y > TABLE.HAUTEUR / 2 + BALLE.Marge_Erreur
                && JOUEUR_2.Peut_Enlever_Une_Vie
                ) {
                JOUEUR_2.Vies--;
                JOUEUR_2.Peut_Enlever_Une_Vie = false;
            }

            // timing : la balle est frappable seulement près d'un bord de la table
            if (
                BALLE.Y > (TABLE.HAUTEUR / 2) - BALLE.Marge_Erreur
                && BALLE.Y < (TABLE.HAUTEUR / 2) + BALLE.Marge_Erreur
                ||
                BALLE.Y < -(TABLE.HAUTEUR / 2) + BALLE.Marge_Erreur
                && BALLE.Y > -(TABLE.HAUTEUR / 2) - BALLE.Marge_Erreur
                ) {
                BALLE.Est_Swingable = true;
            }
            else {
                BALLE.Est_Swingable = false;
            }

            // limite : la balle sort de la scène, retour au service
            if (BALLE.Y > SCENE.DEMI_HAUTEUR || BALLE.Y < -SCENE.DEMI_HAUTEUR) {
                BALLE.En_Mouvement = false;

                if (BALLE.Y > 0) JOUEUR_2.Peut_Enlever_Une_Vie = true;
                else JOUEUR_1.Peut_Enlever_Une_Vie = true;

                BALLE.Retour_Au_Service(-BALLE.Cote);
                BALLE.Vitesse = .0025;
            }
        }

        // animations : fin du swing, le joueur reprend sa voie et sa couleur d'origine
        if (JOUEUR_1.Swing_En_Cours && JOUEUR_1.Compteur_Swing == 0) {
            JOUEUR_1.Swing_En_Cours = false;
            JOUEUR_1.Change_De_Voie(0);

            JOUEUR_1.B = 1;
            JOUEUR_1.Compteur_Swing = JOUEUR_1.DUREE_SWING;
        }
        if (JOUEUR_2.Swing_En_Cours && JOUEUR_2.Compteur_Swing == 0) {
            JOUEUR_2.Swing_En_Cours = false;
            JOUEUR_2.Change_De_Voie(0);

            JOUEUR_2.R = 1;
            JOUEUR_2.Compteur_Swing = JOUEUR_2.DUREE_SWING;
        }
    }

    /// <summary>
    /// Boucle de jeu du mode solo : même logique que le mode deux joueurs,
    /// avec en plus les décisions de l'ordinateur (renvoi de la balle et service
    /// après un délai).
    /// </summary>
    public static void Mode_Joueur_Contre_Ordinateur()
    {
        SCENE.Affiche_Toi();

        ORDINATEUR.Affiche_Toi();

        TABLE.Affiche_Toi();
        //TABLE.Affiche_Tes_Voies();

        JOUEUR_1.Affiche_Toi();

        BALLE.Affiche_Toi();

        //==============================================
        if (BALLE.En_Mouvement && !SCENE.Game_Over) {
            BALLE.X += BALLE.Distance_X * BALLE.Vitesse;
            BALLE.Y += BALLE.Distance_Y * BALLE.Vitesse;

            // condition de fin
            if (JOUEUR_1.Vies == 0 || ORDINATEUR.Vies == 0) {
                BALLE.En_Mouvement = false;
                SCENE.Game_Over = true;
            }

            // bon swing : le joueur du bon côté frappe sur la bonne voie, au bon moment
            if (
                JOUEUR_1.Swing_En_Cours
                && JOUEUR_1.Voie == BALLE.Voie
                && BALLE.Cote == -1
                && BALLE.Est_Swingable
                && BALLE.Y < 0
                ||
                ORDINATEUR.Swing_En_Cours
                && ORDINATEUR.Voie == BALLE.Voie
                && BALLE.Cote == 1
                && BALLE.Est_Swingable
                && BALLE.Y > 0
                ) {
                BALLE.Deplace_Toi((Nombre_Aleatoire() % 3) - 1);
                BALLE.Vitesse += BALLE.PAS;
            }

            // vies : la balle est passée derrière un joueur
            if (
                BALLE.Cote == -1
                && BALLE.Y < -(TABLE.HAUTEUR / 2) - BALLE.Marge_Erreur
                && JOUEUR_1.Peut_Enlever_Une_Vie
                ) {
                JOUEUR_1.Vies--;
                JOUEUR_1.Peut_Enlever_Une_Vie = false;
            }
            if (
                BALLE.Cote == 1
                && BALLE.Y > TABLE.HAUTEUR / 2 + BALLE.Marge_Erreur
                && ORDINATEUR.Peut_Enlever_Une_Vie
                ) {
                ORDINATEUR.Vies--;
                ORDINATEUR.Peut_Enlever_Une_Vie = false;
            }

            // timing : la balle est frappable seulement près d'un bord de la table
            if (
                BALLE.Y > (TABLE.HAUTEUR / 2) - BALLE.Marge_Erreur
                && BALLE.Y < (TABLE.HAUTEUR / 2) + BALLE.Marge_Erreur
                ||
                BALLE.Y < -(TABLE.HAUTEUR / 2) + BALLE.Marge_Erreur
                && BALLE.Y > -(TABLE.HAUTEUR / 2) - BALLE.Marge_Erreur
                ) {
                BALLE.Est_Swingable = true;
            }
            else {
                BALLE.Est_Swingable = false;
            }

            // limite : la balle sort de la scène, retour au service
            if (BALLE.Y > SCENE.DEMI_HAUTEUR || BALLE.Y < -SCENE.DEMI_HAUTEUR) {
                BALLE.En_Mouvement = false;

                if (BALLE.Y > 0) ORDINATEUR.Peut_Enlever_Une_Vie = true;
                else JOUEUR_1.Peut_Enlever_Une_Vie = true;

                BALLE.Retour_Au_Service(-BALLE.Cote);
                BALLE.Vitesse = .0025;
            }
        }

        // animations : fin du swing, le joueur reprend sa voie et sa couleur d'origine
        if (JOUEUR_1.Swing_En_Cours && JOUEUR_1.Compteur_Swing == 0) {
            JOUEUR_1.Swing_En_Cours = false;
            JOUEUR_1.Change_De_Voie(0);

            JOUEUR_1.B = 1;
            JOUEUR_1.Compteur_Swing = JOUEUR_1.DUREE_SWING;
        }
        if (ORDINATEUR.Swing_En_Cours && ORDINATEUR.Compteur_Swing == 0) {
            ORDINATEUR.Swing_En_Cours = false;
            ORDINATEUR.Change_De_Voie(0);

            ORDINATEUR.R = 1;
            ORDINATEUR.Compteur_Swing = ORDINATEUR.DUREE_SWING;
        }

        // swing ordinateur : il frappe dès que la balle est à portée
        if (BALLE.En_Mouvement && BALLE.Est_Swingable && BALLE.Cote == 1 && BALLE.Y > 0) {
            ORDINATEUR.Swing(BALLE.Voie);
        }

        // service ordinateur : attend 200 images avant de servir
        if (!BALLE.En_Mouvement && !ORDINATEUR.Swing_En_Cours && BALLE.Y > 0 && Compteur_Service == 200) {
            ORDINATEUR.Swing(BALLE.Voie);
            BALLE.Deplace_Toi((Nombre_Aleatoire() % 3) - 1);
            Compteur_Service = 0;
        }
        if (!BALLE.En_Mouvement && !ORDINATEUR.Swing_En_Cours && BALLE.Y > 0 && Compteur_Service < 200) {
            Compteur_Service++;
        }
    }
}
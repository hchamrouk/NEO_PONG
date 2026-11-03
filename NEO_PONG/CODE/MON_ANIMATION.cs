using NEO_PONG.CODE;
using OpenGLDotNet;
using System;

/*
 * Exemple de base d'une application OPENGL. Cet exemple est destiné au SIO 1B CCI de Nîmes. 
 * 
 * C'est une base pour développer un ensemble de projets - session 2026 (.Net 10.0)
 */

namespace NEO_PONG;

partial class Program
{
    //==========================================================
    // Cette fonction est invoquée qu'une seule fois avant que le moteur OpenGl travaille.
    // Elle est utile pour initialiser des éléments globaux à l'application.
    static void Initialisation_Animation()
    {
        OUTILS.Active_Reflexion(); // Remarque : Peut être desactivé pour augmenter les performances pour des GPU faibles

        // texture du menu
        SCENE.Texture_Menu = OUTILS.Charge_Texture(@"TEXTURES\MENU\menu.png");
        SCENE.Texture_Menu_Titre = OUTILS.Charge_Texture(@"TEXTURES\MENU\titre.png");
        SCENE.Texture_Menu_Bouton_Solo = OUTILS.Charge_Texture(@"TEXTURES\MENU\solo.png");
        SCENE.Texture_Menu_Bouton_Multi = OUTILS.Charge_Texture(@"TEXTURES\MENU\multi.png");
        SCENE.Texture_Menu_Bouton_Solo_Alt = OUTILS.Charge_Texture(@"TEXTURES\MENU\solo_alt.png");
        SCENE.Texture_Menu_Bouton_Multi_Alt = OUTILS.Charge_Texture(@"TEXTURES\MENU\multi_alt.png");
        SCENE.Texture_Menu_Direction = OUTILS.Charge_Texture(@"TEXTURES\MENU\direction.png");

        // texture de l'écran de fin
        SCENE.Texture_Game_Over = OUTILS.Charge_Texture(@"TEXTURES\GAME_OVER\titre.png");
        SCENE.Texture_Game_Over_Bouton_Menu = OUTILS.Charge_Texture(@"TEXTURES\GAME_OVER\retour_menu.png");
        SCENE.Texture_Game_Over_Bouton_Menu_Alt = OUTILS.Charge_Texture(@"TEXTURES\GAME_OVER\retour_menu_alt.png");
        SCENE.Texture_Game_Over_Bouton_Quitter = OUTILS.Charge_Texture(@"TEXTURES\GAME_OVER\quitter.png");
        SCENE.Texture_Game_Over_Bouton_Quitter_Alt = OUTILS.Charge_Texture(@"TEXTURES\GAME_OVER\quitter_alt.png");
        SCENE.Texture_Game_Over_Gagnant_1 = OUTILS.Charge_Texture(@"TEXTURES\GAME_OVER\gagnant_1.png");
        SCENE.Texture_Game_Over_Gagnant_2 = OUTILS.Charge_Texture(@"TEXTURES\GAME_OVER\gagnant_2.png");
        SCENE.Texture_Game_Over_Gagnant_3 = OUTILS.Charge_Texture(@"TEXTURES\GAME_OVER\gagnant_3.png");

        // texture du jeu
        SCENE.Texture_Jeu = OUTILS.Charge_Texture(@"TEXTURES\JEU\jeu.png");
        TABLE.Texture = OUTILS.Charge_Texture(@"TEXTURES\JEU\table.png");

        // texture des animations des personnages
        JOUEUR_1.Texture_Idle_01 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_1\idle_01.png");
        JOUEUR_1.Texture_Idle_02 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_1\idle_02.png");
        JOUEUR_1.Texture_Idle_03 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_1\idle_03.png");
        JOUEUR_1.Texture_Idle_04 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_1\idle_04.png");
        JOUEUR_1.Texture_Swing_01 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_1\swing_01.png");
        JOUEUR_1.Texture_Swing_02 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_1\swing_02.png");
        JOUEUR_1.Texture_Swing_03 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_1\swing_03.png");
        JOUEUR_1.Texture_Swing_04 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_1\swing_04.png");

        JOUEUR_2.Texture_Idle_01 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_2\idle_01.png");
        JOUEUR_2.Texture_Idle_02 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_2\idle_02.png");
        JOUEUR_2.Texture_Idle_03 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_2\idle_03.png");
        JOUEUR_2.Texture_Idle_04 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_2\idle_04.png");
        JOUEUR_2.Texture_Swing_01 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_2\swing_01.png");
        JOUEUR_2.Texture_Swing_02 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_2\swing_02.png");
        JOUEUR_2.Texture_Swing_03 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_2\swing_03.png");
        JOUEUR_2.Texture_Swing_04 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\JOUEUR_2\swing_04.png");

        ORDINATEUR.Texture_Idle_01 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\ORDINATEUR\idle_01.png");
        ORDINATEUR.Texture_Idle_02 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\ORDINATEUR\idle_02.png");
        ORDINATEUR.Texture_Idle_03 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\ORDINATEUR\idle_03.png");
        ORDINATEUR.Texture_Idle_04 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\ORDINATEUR\idle_04.png");
        ORDINATEUR.Texture_Swing_01 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\ORDINATEUR\swing_01.png");
        ORDINATEUR.Texture_Swing_02 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\ORDINATEUR\swing_02.png");
        ORDINATEUR.Texture_Swing_03 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\ORDINATEUR\swing_03.png");
        ORDINATEUR.Texture_Swing_04 = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\ORDINATEUR\swing_04.png");

        // texture des photo de profil des personnages
        JOUEUR_1.Texture_Photo = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\PROFIL\joueur_1.png");
        JOUEUR_2.Texture_Photo = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\PROFIL\joueur_2.png");
        ORDINATEUR.Texture_Photo = OUTILS.Charge_Texture(@"TEXTURES\PERSONNAGES\PROFIL\ordinateur.png");

        // texture de la vie des personnages
        JOUEUR_1.Texture_Vie_Plein = OUTILS.Charge_Texture(@"TEXTURES\VIE\vie_pleine.png");
        JOUEUR_1.Texture_Vie_Vide = OUTILS.Charge_Texture(@"TEXTURES\VIE\vie_vide.png");

        JOUEUR_2.Texture_Vie_Plein = OUTILS.Charge_Texture(@"TEXTURES\VIE\vie_pleine.png");
        JOUEUR_2.Texture_Vie_Vide = OUTILS.Charge_Texture(@"TEXTURES\VIE\vie_vide.png");

        ORDINATEUR.Texture_Vie_Plein = OUTILS.Charge_Texture(@"TEXTURES\VIE\vie_pleine.png");
        ORDINATEUR.Texture_Vie_Vide = OUTILS.Charge_Texture(@"TEXTURES\VIE\vie_vide.png");

        BALLE.Texture = OUTILS.Charge_Texture(@"TEXTURES\BALLE\balle.png");
    }

    //==========================================================
    // Cette fonction est invoquée par le Moteur de manière périodique
    // pour Afficher une Frame.
    // L'écran est d'abord effacé avant l'invocation de cette focntion.
    // Le repère est au centre de l'écran (0,0,0)
    static void Afficher_Ma_Scene()
    {
        // c'est ici que vous pouvez coder l'affichage d'une frame
        // Rappel : en début de cette fonction, le repère est en 0,0,0 qui est le centre de l'écran

        /*
         * On affiche dans un premier temps le Menu.
         * Le menu doit avoir 2 boutons (pour les modes de jeu):
         * - le mode solo (contre l'ordinateur)
         * - le mode multi (contre un autre joueur)
         */
        if (SCENE.Menu && SCENE.Choix_Mode == -1) {
            SCENE.Affiche_Menu();

            // on initialise les caractéristiques des perosnnages
            // et de la balle dans le menu.
            JOUEUR_1.Initialise_Toi();
            JOUEUR_2.Initialise_Toi();
            ORDINATEUR.Initialise_Toi();
            BALLE.Initialise_Toi();
        }
        else {
            // une fois un bouton cliqué,
            // on affiche le mode sélectionné.

            if (SCENE.Choix_Mode == 0) {
                if (!SCENE.Game_Over) SCENE.Mode_Joueur_Contre_Joueur();
                else SCENE.Affiche_Game_Over(JOUEUR_1.Vies == 0 ? 1 : -1);
            }
            else {
                if (!SCENE.Game_Over) SCENE.Mode_Joueur_Contre_Ordinateur();
                else SCENE.Affiche_Game_Over(JOUEUR_1.Vies == 0 ? 1 : -1);
            }
        }
    }


    //=========================================================
    // Cette fonction est invoquée en boucle par openGl.
    // Elle peut être utilisée pour modifier des variables globales utilisée
    // dans "Afficher_Ma_Scene"
    static void Animation_Scene()
    {

        //fortement recommandé
        FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //======================================================================
    // Cette fonction est invoquée par OpenGl lorsqu'on appuie sur
    // une touche spéciale (flèches, Fx, ...).
    //
    // P_Touche contient le code de la touche,
    // P_X et P_Y contiennent les coordonnées de la souris quand on appuie sur une touche
    static void Gestion_Touches_Speciales(int P_Touche, int P_X, int P_Y)
    {
        if (P_Touche == FG.GLUT_KEY_F1) FG.FullScreen();       // Basculer en plein écran. La résolution est celle du système
        if (P_Touche == FG.GLUT_KEY_F2) FG.LeaveFullScreen();  // retourner en mode fenêtre. La résolution est 800x600


        //fortement recommandé
        FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //======================================================================
    // Cette fonction est invoquée par OpenGl lorsqu'on relache
    // une touche spéciale (flèches, Fx, ...).
    //
    // P_Touche contient le code de la touche,
    // P_X et P_Y contiennent les coordonnées de la souris quand on relache sur une touche
    static void Gestion_Touches_Speciales_Relachees(int P_Touche, int P_X, int P_Y)
    {

        // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //======================================================================
    // Cette fonction est invoquée par OpenGl lorsqu'on appuie
    // sur une touche normale (A,Z,E, ...)
    //
    // P_Touche contient le code de la touche,
    // P_X et P_Y contiennent les coordonnées de la souris quand on appuie sur une touche
    static void Gestion_Clavier(byte P_Touche, int P_X, int P_Y)
    {

        if (P_Touche == 27) FG.LeaveMainLoop(); // 27 est le code de la touche "Echap"
                                                // LeaveMainLoop() permet de sortir de la boucle d'analyse des events et d'affichage.
                                                // On retourne dans le Main() puis le programme se termine.

        /*
         * 3 touches suffise pour controller 1 joueur,
         * puisqu'il y a un mode à 2 joueurs on a besoin d'un total
         * de 6 touches.
         * 
         * J'ai décidé de prendre Q S D et K L M pour que ce soit pratique.
         * 
         * Pour le menu pas besoin de le faire via la souris ou de prendre d'autres touches,
         * Q S D feront l'affaire.
         */

        // gestion du menu et de l'écran de fin.
        if (SCENE.Menu || SCENE.Game_Over) {

            // choix des boutons via les touches Q et D.
            if (P_Touche == 'q') SCENE.Change_Bouton(0);
            if (P_Touche == 'd') SCENE.Change_Bouton(1);

            // validation (clique bouton) via la touche S.
            if (P_Touche == 's' && SCENE.Menu) {
                SCENE.Menu = false;
                SCENE.Choix_Mode = SCENE.Bouton;

                SCENE.Clique_Bouton();
            }
            if (P_Touche == 's' && SCENE.Game_Over) {
                if (SCENE.Bouton == 0) {
                    SCENE.Game_Over = false;
                    SCENE.Choix_Mode = -1;
                    SCENE.Menu = true;

                    SCENE.Clique_Bouton();
                }

                // le 2eme choix dans l'écran de fin c'est de quitter.
                else FG.LeaveMainLoop();
            }
        }

        // commandes joueur 1
        if (!JOUEUR_1.Swing_En_Cours && SCENE.Choix_Mode != -1) {
            if (P_Touche == 'q') JOUEUR_1.Swing(-1);
            if (P_Touche == 's') JOUEUR_1.Swing(0);
            if (P_Touche == 'd') JOUEUR_1.Swing(1);
        }

        // commandes joueur 2
        if (!JOUEUR_2.Swing_En_Cours && SCENE.Choix_Mode == 0) {
            if (P_Touche == 'k') JOUEUR_2.Swing(-1);
            if (P_Touche == 'l') JOUEUR_2.Swing(0);
            if (P_Touche == 'm') JOUEUR_2.Swing(1);
        }

        // service
        if (!BALLE.En_Mouvement) {
            if ((BALLE.Cote == -1 && P_Touche == 's') || (BALLE.Cote == 1 && P_Touche == 'l' && SCENE.Choix_Mode == 0)) {
                BALLE.Deplace_Toi((SCENE.Nombre_Aleatoire() % 3) - 1);
            }
        }

        //fortement recommandé
        FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //======================================================================
    // Cette fonction est invoquée par OpenGl lorsqu'on relache
    // une touche normale (A,Z,E, ...).
    //
    // P_Touche contient le code de la touche,
    // P_X et P_Y contiennent les coordonnées de la souris quand on relache sur une touche
    static void Gestion_Clavier_Relache(byte P_Touche, int P_X, int P_Y)
    {


        // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //==================================================================================
    // Cette fonction est invoquée par OpenGl lorsqu'on appuie
    // sur un bouton de la souris.
    //
    // P_Bouton contient le code du bouton (gauche ou droite),
    // P_Etat son etat,
    // les coordonnées de la souris quand on appuie sur un bouton sont dans P_X et P_Y
    static void Gestion_Bouton_Souris(int P_Bouton, int P_Etat, int P_X, int P_Y)
    {

        //fortement recommandé
        FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //====================================================================
    // Cette fonction est invoquée par OpenGl lorsqu'on tourne
    // la molette de la souris.
    //
    // P_Molette contient le code de la molette,
    // P_Sens son sens de rotation,
    // Les coordonnées de la souris quand on tourne la molette sont dans P_X et P_Y
    static void Gestion_Molette(int P_Molette, int P_Sens, int P_X, int P_Y)
    {

        //  FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //====================================================================
    // Cette fonction est invoquée par OpenGl lorsqu'on bouge la souris
    // sans appuyer sur un bouton.
    // Les coordonnées de la souris ont dans P_X et P_Y
    static void Gestion_Souris_Libre(int P_X, int P_Y)
    {

        // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }


    //====================================================================
    // Cette fonction est invoquée par OpenGl lorsqu'on bouge la souris
    // tout en appuyant sur un bouton.
    // Les coordonnées de la souris ont dans P_X et P_Y
    static void Gestion_Souris_Clique(int P_X, int P_Y)
    {
        // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }


    //====================================================================
    // Cette fonction est invoquée périodiquement par OpenGl. La période est par défaut 16ms (60Hz).
    // Elle peut aussi être spécifiée en paramètre TIMER::Demarre_Timer(Periode).   
    // sous réserve que TIMER::Demarre_Timer() est invoqué
    // TIMER::Stoppe_Timer() permet l'arret de l'invocation périodique
    static void Evenement_Timer()
    {
        // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //###################################################################
}

using OpenGLDotNet;
namespace NEO_PONG.CODE;

public class TABLE
{
    public const double LARGEUR = SCENE.LARGEUR / 2.4;
    public const double HAUTEUR = SCENE.LARGEUR / 2;
    public const double LARGEUR_VOIE = LARGEUR / 3; // la table est divisée en 3 voies égales

    public static uint Texture;

    /// <summary>
    /// Dessine la table de jeu au centre de la scène.
    /// </summary>
    public static void Affiche_Toi()
    {
        GL.Color3d(0, 1, 0);
        OUTILS.Affiche_Sprite(Texture, 0, 0, 0, LARGEUR, HAUTEUR);
    }

    /// <summary>
    /// Dessine les 3 voies avec des teintes différentes (utile pour le débogage).
    /// </summary>
    public static void Affiche_Tes_Voies()
    {
        for (int Compteur = 0; Compteur < 3; Compteur++) {
            GL.Color3d(0, .3 + .3 * Compteur, 0);
            OUTILS.Affiche_Sprite(Texture, (Compteur - 1) * LARGEUR_VOIE, 0, 0, LARGEUR_VOIE, HAUTEUR);
        }
    }
}
using System;
namespace HeroBook
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum Object
    {
        None,

        // Armes
        Poignard,
        Lance,
        MasseDArmes,
        Sabre,
        MarteauDeGuerre,
        Arc,
        Hache,
        Epee,
        Baton,
        Glaive,

        // Objets de base
        Carquois,
        Corde,
        Lanterne,
        RationsSpeciales,
        GrainesDeFeu,
        Fleche,

        // Potions
        PotionDeLaumspur,  // Récupère 4 points d'ENDURANCE

        // Nourriture
        Repas,

        // Or
        PiecesDOr,

        // Objets spéciaux
        GiletDeCuirDouble,   // Augmente ENDURANCE de 2
        Casque,              // Augmente ENDURANCE de 2
        CleDePouvoir,
        AmuletteEnPlatine,   // Protège contre les hautes températures
        PilulesBleues,      // Permet de respirer sous l'eau
        Couverture,
        BouteilleDeVin,

        // Autres objets
        SphereDeFeuDeKalte,  // Utilisé pour éclairer
        BriquetDAmadou      // Utilisé pour allumer un feu
    }

    public enum Equipement
    {
        None = Object.None,
        Poignard = Object.Poignard,
        Lance = Object.Lance,
        MasseDArmes = Object.MasseDArmes,
        Sabre = Object.Sabre,
        MarteauDeGuerre = Object.MarteauDeGuerre,
        Arc = Object.Arc,
        Hache = Object.Hache,
        Epee = Object.Epee,
        Baton = Object.Baton,
        Glaive = Object.Glaive,
    }

    public enum Discipline
    {
        None, // None
        ScienceDesArmes,  // Maîtrise de diverses armes
        Invisibility,     // Technique d'invisibilité
        ArtDeLaChasse,    // Compétence de chasse et survie
        Exploration,      // Maîtrise des environnements et des langues
        FoudroiementPsychique, // Attaques mentales
        EcranPsychique,   // Protection contre les attaques mentales
        Nexus,            // Maîtrise de la résistance aux températures extrêmes et télékinésie
        Intuition,        // Détection des dangers et télépathie
        ScienceMedicale,  // Récupération de points d'ENDURANCE et soins
        ContrôleAnimal    // Communication et contrôle des animaux
    }
}

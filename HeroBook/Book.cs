using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroBook
{
    public class Book
    {
        // Progress & Player
        public Player Player { get; set; } = new();
        public int BookSection { get; set; } = 1;

        public Section CurrentSection => Sections.Find(s => s.Id == BookSection);

        // Book & Data
        public string Title { get; set; }
        public List<Item> Items { get; set; }
        public List<Section> Sections { get; set; }
        public List<Class> Classes { get; set; }
        public List<Race> Races { get; set; }

        private AIHandler AIHandler { get; set; } = new();

        public void OpenBook()
        {
            Setup();
            ReadSection();
        }

        public void Setup()
        {
            Console.Title = "Aventure d'Azeroth";

            Prompt.WriteLine("=== Bienvenue dans l'Aventure d'Azeroth ===", PromptType.Title);
            Console.WriteLine("Avant de commencer votre quête, il est temps de forger votre destin.");
            Console.WriteLine("Vous allez choisir une race, une classe et un nom pour votre personnage.\n");

            SelectRace();
            SelectClass();
            SelectName();

            Console.WriteLine($"\nBienvenue, {Player.PlayerName}, {Player.Class.Name} de la race {Player.Race.Name} !");

            Prompt.WriteLine("\nAppuyez sur Entrée pour commencer votre aventure !");
            Console.ReadLine();
        }

        public void SelectRace()
        {
            Console.WriteLine("Choisissez votre race et entrez le numéro voulu :");
            for (int i = 0; i < Races.Count; i++)
            {
                Console.WriteLine($"- {i}:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {Races[i].Name}");
                Console.ResetColor();
                Console.Write($" ({Races[i].Description})");
            }

            string prompt;
            do
            {
                prompt = Console.ReadLine();
            }
            while (!int.TryParse(prompt, out int raceId) || (raceId < 0 || raceId >= Races.Count));

            Player.Race = Races[int.Parse(prompt)];
            Prompt.WriteLine($"\nVous avez choisi : {Player.Race.Name}.\n", PromptType.Log);
        }

        public void SelectClass()
        {
            Console.WriteLine("Choisissez votre class et entrez le numéro voulu :");
            for (int i = 0; i < Classes.Count; i++)
            {
                Console.WriteLine($"- {i}:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" {Classes[i].Name}");
                Console.ResetColor();
                Console.Write($" ({Classes[i].Description})");
            }

            string prompt;
            do
            {
                prompt = Console.ReadLine();
            }
            while (!int.TryParse(prompt, out int classId) || (classId < 0 || classId >= Classes.Count));

            Player.Class = Classes[int.Parse(prompt)];

            Prompt.WriteLine($"\nVous avez choisi : {Player.Class.Name}.\n", PromptType.Log);
        }

        public void SelectName()
        {
            Console.Write("Entrez le nom de votre personnage : ");
            string nomJoueur = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nomJoueur))
            {
                Console.Write("Le nom ne peut pas être vide. Entrez un nom valide : ");
                nomJoueur = Console.ReadLine();
            }

            Player.PlayerName = nomJoueur;
        }

        public void ReadPrompt(string prompt)
        {
            if (prompt.ToLower() == "inventaire")
            {
                ShowInventory();
            }

            if (int.TryParse(prompt, out int choice))
            {
                ChooseSection(choice);
            }

            Prompt.WriteLine($"- [Inventaire] : Afficher l'inventaire", PromptType.Log);
            Prompt.WriteLine($"- [Quitter] : Quitter le jeu", PromptType.Log);
        }

        private void ShowInventory()
        {
            Prompt.WriteLine($"=== Inventaire ===\n", PromptType.Title);
            Console.WriteLine(new string('-', 50));

            foreach (Item item in Player.Bag)
            {
                Prompt.WriteLine($"- [{item.Name}] : {item.Description}", PromptType.Inventory);
            }

            Console.WriteLine("\nAppuyez sur n'importe quelle touche pour quitter l'inventaire");
        }

        public void ReadSection()
        {
            //AIHandler.CallAI("");

            Prompt.WriteLine($"=== Section {CurrentSection.Id} ===\n", PromptType.Title);
            Console.WriteLine($"{CurrentSection.Text}\n");

            Console.WriteLine(new string('-', 50));

            if (CurrentSection.Choices.Any())
            {
                Console.WriteLine("\nVos choix :");
                foreach (var choice in CurrentSection.Choices)
                {
                    if (!choice.Requirement.IsMet(Player)) continue;

                    Prompt.WriteLine($"- [Page {choice.SectionId}] : {choice.Description}", PromptType.Log);
                }
            }

            if (CurrentSection.Choices.Any()) Console.WriteLine("\nEntrez le numéro de la page à laquelle vous souhaitez vous rendre :");
        }

        public void ChooseSection(int nextSectionId)
        {
            if (!Sections.Any(s => s.Id == nextSectionId)) return;

            if (!CurrentSection.Choices.Any(c => c.SectionId == nextSectionId)) return;

            BookSection = nextSectionId;
        }
    }

    public class Section
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Choice> Choices { get; set; }
        // requirement -> item / skill
        // type -> battle, loot, use item

        //Chemins à emprunter.
        //Objets à utiliser ou conserver.
        //Combats à mener ou éviter.
        //Compétences à utiliser.
        //Décisions morales.
        //Gestion des ressources.
        //Résolution d’énigmes.
        //Interactions avec PNJ.
        //Quêtes secondaires.
        //Choix contextuels.
    }

    public class Choice
    {   
        public string Description { get; set; }
        public int SectionId { get; set; }

        public ChoiceRequirement Requirement { get; set; }
        public ChoiceReward Reward { get; set; }

        public class ChoiceReward
        {
            public Item Item { get; set; }
            public int Gold { get; set; }
            public int Experience { get; set; }

            public void ReceiveReward(Player player)
            {
                if (Item != null) player.Bag.AddItem(Item);
                player.Gold += Gold;
            }
        }

        public class ChoiceRequirement
        {
            public Item Item { get; set; }
            public Class Class { get; set; }
            public Race Race { get; set; }

            public bool IsMet(Player player)
            {
                return (Item == null || player.Bag.HasItem(Item))
                        && (Class == null || player.Class.Id == Class.Id)
                        && (Race == null || player.Race.Id == Race.Id);
            }
        }
    }

    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

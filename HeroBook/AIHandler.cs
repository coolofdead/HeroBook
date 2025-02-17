using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Chat;

namespace HeroBook
{
    public class AIHandler
    {
        private const string API_KEY = "";
        private const string TEXT_INTRODUCTION = "Tu es narrateur de jeu de role dans le style de dungeon et dragon ou le livre dont vous êtes le héro. Je serai le joueur et j'incarnerai le héro. Le jeu se passe dans l'univers de World of Warcarft avec les classes et races de ce meme univers. J'aimerai que tu rédiges des textes allant de 30 à 700 mots et que tu termines tes phrases par des choix (de minimum 1 jusqu'à maximum 3 au hasard) que le joueur pourra choisir. Le joueur devra d'abbord choisir son nom, sa classe et sa race avant de commencer l'aventure. J'aimerai que le style d'écriture soit assez romancé et fantaisy. Tu devras commencer par un long texte d'introduction de l'histoire avec une présentation de l'univers, des personnages et de l'objectif du joueur en t'inspirant uniquement du lore de World of Warcraft. Le texte sera légerement sombre pour bien mettre en avant le conflit et l'objectif. Comme tous les jeux de ce style, le joueur aura une bourse avec de l'or, de la nourriture et des objets dans son sac avec une place limite et des compétences selon sa classe à toi de les définir, également selon sa race il pourra lire certains languages qui permettront de découvrir des objets, parler avec des PNJ ou de décripter des reliques et débloquer des passages. Le joueur ne sera pas seul et sera accompagné d'autres personnages de l'univers de World of Warcraft en fonction de sa race choisie et de si il est dans la horde ou l'alliance. J'aimerai que tu présentes le texte de manière lisible et formatté avec de l'espace entre les choix et l'histoire. J'aimerai que tu fasses avancer l'histoire en fonction des choix du joueur.";

        private readonly ChatClient chat;
        private readonly List<ChatMessage> chatMessages = new() {  };

        public AIHandler()
        {
            var openAiService = new OpenAIClient(API_KEY);
            chat = openAiService.GetChatClient("gpt-4o");
        }

        public async Task<string> CallAI(string prompt)
        {
            chatMessages.Add(prompt);

            var chatResult = await chat.CompleteChatAsync(chatMessages);

            return chatResult.Value.Content[0].Text;
        }

        public async Task<string> ShowIntroduction()
        {
            var chatResult = await chat.CompleteChatAsync(chatMessages);

            return chatResult.Value.Content[0].Text;
        }
    }
}

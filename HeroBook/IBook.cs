using System.Collections.Generic;

namespace HeroBook
{
    public interface IBook
    {
        int BookSection { get; set; }
        string Title { get; set; }
        List<Section> Sections { get; set; }
        Section CurrentSection { get; }

        void ChooseSection(int nextSectionId);
        void OpenBook();
        void ReadSection();
    }

    public interface IBookSection
    {
        int Id { get; set; }
        string Text { get; set; }
        List<Choice> Choices { get; set; }

        // requirement -> item / skill
        // type -> battle, loot, custom prompt

        void ReadSection();
    }

}
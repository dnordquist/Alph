using Alph.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alph.Lib
{
    public class Artist
    {
        public string ArtistName { get; set; }
        public string FamilyName { get; set; }

        private string _sortName;

        public Dictionary<string, string> UtilizedAbbreviations { get; set; }


        public string PersonNameInGroupName { get; set; }

        public Artist()
        {
            UtilizedAbbreviations = new Dictionary<string, string>();
        }

        public Artist(string artistName) : this()
        { 
            ArtistName = artistName;
        }

        public string SortName
        {
            get
            {
                _sortName = ArtistName;

                // first things first swap out The and A and An
                SwapArticlesLast();

                // DJ and MC have to go to the end too
                MoveAbbreviatedTitlesLast();


                // OK time for Ben Folds Five
                if (!string.IsNullOrEmpty(PersonNameInGroupName))
                {
                    PutPersonNameFirstAccordingToRules();
                }
                // if we have been told this is a person, follow those rules. 
                if (!string.IsNullOrEmpty(FamilyName))
                    PersonArtistNameRules();

                // if we're using abbreviations, explode them
                if (UtilizedAbbreviations.Count > 0)
                {
                    ExplodeAbbreviations();
                }

                // all done! 
                return _sortName;

            }
        }

        private void PutPersonNameFirstAccordingToRules()
        {
            var groupRemainder = _sortName.Replace(PersonNameInGroupName, "").Trim();
            _sortName = $"{PersonNameInGroupName}, {groupRemainder}";
            // so this prevents the problem with "Sensational  Band"
            _sortName = _sortName.Replace("  ", " ");
            // and this prevents problems with "Estefan, Gloria, and the Miami Sound Machine" because apparently
            // it would be some sort of sin to keep the comma before the "and". 
            _sortName = _sortName.Replace(", and", " and").Replace(", &", " &");
        }

        void ExplodeAbbreviations()
        {
            foreach (var x in UtilizedAbbreviations)
            {
                _sortName = _sortName.Replace(x.Key, x.Value);
            }
        }

        void SwapArticlesLast()
        {
            foreach (string article in HelperData.Articles)
            {
                if (_sortName.StartsWith($"{article} "))
                {
                    string remainder = _sortName.Replace($"{article} ", "");
                    _sortName = $"{remainder}, {article}";
                }
            }
        }

        string GetAbbreviatedTitle()
        {
            foreach (string title in HelperData.AbbreviatedTitles)
            {
                if (_sortName.StartsWith($"{title} "))
                {
                    return title;
                }
            }
            return null;
        }

        private void PersonArtistNameRules()
        {
            // Prince / Madonna: we don't know their last name so that's fine. No more processing necessary. 

            string nameRemainder = _sortName.Replace($" {FamilyName}", "").Trim();
            _sortName = $"{FamilyName}, {nameRemainder}";

        }

        private void MoveAbbreviatedTitlesLast()
        {
            // putting an abbreviated title last - MC Hammer -> Hammer, MC
            if (!string.IsNullOrEmpty(GetAbbreviatedTitle()))
            {
                string title = GetAbbreviatedTitle();
                string remainder = _sortName.Replace($"{title} ", "").Trim();
                _sortName = $"{remainder}, {title}";
            }
        }
    }
}

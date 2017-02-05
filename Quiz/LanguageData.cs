using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Quiz.XmlModel;

namespace Quiz
{
   class LanguageData
   {
      private class LanguageItemInfo
      {
         public LanguageItemInfo(LanguageItem item, LanguageItemCategory category)
         {
            this.Item = item;
            this.Category = category;
         }

         public LanguageItem Item
         {
            get;
            private set;
         }

         public LanguageItemCategory Category
         {
            get;
            private set;
         }

      }

      private Random random = new Random();
      private List<LanguageItemInfo> allItems = new List<LanguageItemInfo>();
      private List<LanguageItemState> itemStates = new List<LanguageItemState>();

      public LanguageData()
      {
         // load items
         PresentIndicative pi = XMLLoader.Load<PresentIndicative>("PresentIndicative.xml");
         Adverbs adverbs = XMLLoader.Load<Adverbs>("Adverbs.xml");
         Nouns nouns = XMLLoader.Load<Nouns>("Nouns.xml");
         Phrases phrases = XMLLoader.Load<Phrases>("Phrases.xml");

         // add them to our collection
         AddItems(pi.VerbConjugations, LanguageItemCategory.PresentIndicative);
         AddItems(adverbs.AdverbList, LanguageItemCategory.Adverb);
         AddItems(phrases.PhraseList, LanguageItemCategory.Phrase);
         AddItems(nouns.NounList, LanguageItemCategory.Noun);

         // get item states
         foreach (var item in allItems)
            itemStates.Add(GetLanguageItemState(item));
      }

      public LanguageItem GetRandomItem()
      {
         int nextIndex = random.Next(allItems.Count);
         return allItems.ToArray()[nextIndex].Item;
      }

      private void AddItems(IEnumerable<LanguageItem> items, LanguageItemCategory category)
      {
         foreach (var item in items)
            allItems.Add(
               new LanguageItemInfo(item, category)
               );
      }

      private LanguageItemState GetLanguageItemState(LanguageItemInfo itemInfo)
      {
         // for now just return a default
         return new LanguageItemState(itemInfo.Category, itemInfo.Item.Key);
      }
   }
}

using System;
using MatrixCalc.ViewModel;
using System.Collections.Generic;

namespace MatrixCalc.Model
{
	public class FontManager
    {
        private MatrixVM matrixPageVM;

        public List<InputEntry> EntryList { get; set; }
        public List<GetInfoButton> ButtonList { get; set; }

        public FontManager()
		{
        }

        public static List<InputEntry> UpdateFontInputEntry(List<InputEntry> ItemList)
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                ItemList[i] = (InputEntry)UpdateFont(ItemList[i]);
            }

            return ItemList;
        }


        public static void UpdateFontInputEntryVoid(List<InputEntry> ItemList)
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                ItemList[i] = (InputEntry)UpdateFont(ItemList[i]);
            }
        }

        public static List<GetInfoButton> UpdateFontGetInfoButton(List<GetInfoButton> ItemList)
        {
            for (int i = 0; i < ItemList.Count; i++)
            {
                ItemList[i] = (GetInfoButton)UpdateFont(ItemList[i]);
            }

            return ItemList;
        }

        public static IUpdatableFont UpdateFont(IUpdatableFont item)
        {
            item.FontSize = item.UpdateFontSize();

            return item;
        }
    }
}


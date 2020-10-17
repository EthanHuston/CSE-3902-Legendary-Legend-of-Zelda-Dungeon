using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

namespace LegendOfZelda.Rooms
{
    class CVSReader
    {
        string[,] roomString = new string[Constants.roomWidth, Constants.roomHeight];

        public CVSReader(string fileName)
        {
            TextFieldParser parser = new TextFieldParser(fileName);
            parser.Delimiters = new string[] { "," }; //Delimiters are like separators in NextWordOrSeparator
            int j = 0;
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                for(int i = 0; i < fields.Length; i++)
                {
                    roomString[i, j] = fields[i];
                }
            }
        }

    }
}

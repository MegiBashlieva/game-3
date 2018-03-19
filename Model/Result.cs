using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee3.Model
{
    class Result
    {
        private  int[] getResults=new int[13];


        public int[] GetResults
        {
            get
            {
                return getResults;
            }
            set
            {
                getResults = value;
            }
        }

        

     

        public void GetResultsMe(int[] dies)
        {
            int[] count = new int[6];

            for (int i = 0; i < dies.Length; i++)
            {
                switch(dies[i])
                {
                    case 1: GetResults[0] += 1; count[0]++; break;
                    case 2: GetResults[1] += 2; count[1]++; break;
                    case 3: GetResults[2] += 3; count[2]++; break;   // ones-sixes
                    case 4: GetResults[3] += 4; count[3]++; break;
                    case 5: GetResults[4] += 5; count[4]++; break;
                    case 6: GetResults[5] += 6; count[5]++; break;
                }           

            }
            GetResults[11] = GetResults[0] + GetResults[1] + GetResults[2] + GetResults[3] + GetResults[4] + GetResults[5]; //chance
            bool flagFortwo = false;
            bool flagForThree = false;
            for (int i = 0; i < 6; i++)
            {
                if (count[i] == 2)
                {
                    flagFortwo = true;
                }

                if(count[i]==3)
                {
                  
                       GetResults[6] = GetResults[11]; //threeofkind     
                       flagForThree = true;
                }

                if (count[i] == 4)
                {
                    GetResults[6] = GetResults[11]; //three of kind
                    GetResults[7] = GetResults[11]; // four of kind
                }
                if (count[i]== 5)
                {
                    GetResults[12] = 50;
                    GetResults[6] = GetResults[11];
                    GetResults[7] = GetResults[11];
                    //Yathzee
                }
            }

            if (flagFortwo && flagForThree)
            {
                GetResults[8] = 25; //Fullhouse
            }
            flagForThree = false;
            flagFortwo = false;

            if ((GetResults[0] == 1 && GetResults[1] == 2 && GetResults[2] == 3 && GetResults[3] == 4 && GetResults[4] == 5)
               || (GetResults[1] == 2 && GetResults[2] == 3 && GetResults[3] == 4 && GetResults[4] == 5 && GetResults[5] == 6))
            {
                GetResults[10] = 40; //large straight
            }
            if ((GetResults[0] == 1 && GetResults[1] == 2 && GetResults[2] == 3 && GetResults[3] == 4)
               || (GetResults[1] == 2 && GetResults[2] == 3 && GetResults[3] == 4 && GetResults[4] == 5)
                || (GetResults[2] == 3 && GetResults[3] == 4 && GetResults[4] == 5 && GetResults[5] == 6))
            {
                GetResults[9] = 30; //small straight
            }

        }
        public void ClearResults()
        {
            for (int i = 0; i < GetResults.Length; i++)
            {
                GetResults[i] = 0;
            }
        }


    }
}

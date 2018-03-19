using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Yahtzee3.Model;

namespace Yahtzee3.ViewModel
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]String propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
         private ObservableCollection<string> valuesOfSecondPlayer;
         public ObservableCollection<string> ValuesOfSecondPlayer
         {
             get
             {
                 return valuesOfSecondPlayer;
             }
             set
             {
                 valuesOfSecondPlayer = value;
                 NotifyPropertyChanged();
             }
         }



         private int[] finalResults = new int[13];
         public int[] FinalResults
         {
             get
             {
                 return finalResults;
             }
             set
             {
                 finalResults = value;
                 NotifyPropertyChanged();
             }
         }

         private string score="";
         public string Score
         {
             get
             {
                 return score;
             }
             set
             {
                 score = value;
                 NotifyPropertyChanged();
             }
         }
        
         private List<string> clickedB;
        

         public List<string> ClickedB
         {
             get
             {
                 return clickedB;
             }
             set
             {
                   clickedB = value;
                 NotifyPropertyChanged();
             }
         }
        
         private Uri img0 ;

         public Uri Img0
         {
             get
             {
                 return img0;
             }
             set
             {
                 img0 = value;
                 NotifyPropertyChanged();
             }
         }

         private Uri img1;

         public Uri Img1
         {
             get
             {
                 return img1;
             }
             set
             {
                 img1 = value;
                 NotifyPropertyChanged();
             }
         }
         private Uri img2;

         public Uri Img2
         {
             get
             {
                 return img2;
             }
             set
             {
                 img2 = value;
                 NotifyPropertyChanged();
             }
         }

         private Uri img3;

         public Uri Img3
         {
             get
             {
                 return img3;
             }
             set
             {
                 img3 = value;
                 NotifyPropertyChanged();
             }
         }

         private Uri img4;

         public Uri Img4
         {
             get
             {
                 return img4;
             }
             set
             {
                 img4 = value;
                 NotifyPropertyChanged();
             }
         }




         public ICommand FillImages { get; set; }
         public ICommand GetButtonClickedResults { get; set; }
                 
        private int[] values=new int[6];

         public int[] Values
         {
             get
             {
                 return values;
             }
             set
             {
                 values = value;
                 NotifyPropertyChanged();
             }
         }
         int count = 1;
         public void GetButtonClickedResult(object o)
         {
             
             Button c = o as Button;
             if (count == 1)
             {

                 c.Background = Brushes.Yellow;
                 FinalResults[Convert.ToInt32(c.Tag)] = int.Parse(ValuesOfSecondPlayer[Convert.ToInt32(c.Tag)]);
                 count++;
                 countResult = 0;
             }
         }

        public void ButtonClicked(object  o)
        {
             Button c = o as Button;
             
             ClickedB.Add(c.Tag.ToString());
           
        }

        public void FillImage( )
        {
            Die d = new Die();
            Random rand = new Random();
            int[] arr =new int[5];

            for (int i = 0; i < 5; i++)
            {
                arr[i] = rand.Next(1, 6 + 1);
            }

            if (!ClickedB.Contains("1"))
            {
                
                Img0 = d.Image[arr[0]];
                Values[0] = arr[0];
                
            }
            if (!ClickedB.Contains("2"))
            {
                Img1 = d.Image[arr[1]];
                Values[1] = arr[1];
            }

            if (!ClickedB.Contains("3"))
            {
                Img2 = d.Image[arr[2]];
                Values[2] = arr[2];
            }
            if (!ClickedB.Contains("4"))
            {
                Img3 = d.Image[arr[3]];
                Values[3] = arr[3];
            }
            if (!ClickedB.Contains("5"))
            {
                Img4 = d.Image[arr[4]];
                Values[4] = arr[4];
            }



        }
        public bool IsEnd()
        {
            int count = 0;
            for (int i = 0; i < 13; i++)
            {
                if (FinalResults[i] != -1)
                {
                    count++;
                }
            }

            if (count == 13)
            {
                return true;
            }
            else return false;

        }
        public ICommand FillSecondPlayer { get; set; }
        int countResult = 0;
        public void FillValues(object obj)
        {
            countResult++;
            bool isEnd = IsEnd();
            if (isEnd)
            {
                Score = "Your score is  " + FinalResults.Sum();
                System.Windows.MessageBox.Show(obj.ToString());
            }
            else
            {

                if (countResult < 4)
                {
                    if (countResult == 3)
                    {

                        string show = "you have 0 rolls left";

                        System.Windows.MessageBox.Show(show.ToString());
                    }
                    FillImage();
                    
                    
                }
                //int[] arr = new int[] { 1, 2, 3, 4, 6 };

                Result r = new Result();
                r.GetResultsMe(Values);

                for (int i = 0; i < r.GetResults.Length; i++)
                {
                    ValuesOfSecondPlayer[i] = r.GetResults[i].ToString();

                }
                for (int i = 0; i < 13; i++)
                {
                    if (FinalResults[i] != -1)
                    {
                        ValuesOfSecondPlayer[i] = FinalResults[i].ToString();

                    }

                }


                count = 1;
                ClickedB.Clear();
                r.ClearResults();
            }
        }



        public MainWindowVM()
        {

            
            ClickedB = new List<string>() { "", "", "", "", "" };
            FinalResults = new int[] { -1,-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,-1};
            GetButtonClickedResults = new RelayCommand(GetButtonClickedResult);
            FillSecondPlayer = new RelayCommand(FillValues);
            FillImages = new RelayCommand(ButtonClicked);
            ValuesOfSecondPlayer = new ObservableCollection<string>() { "", "", "", "", "", "", "", "", "", "", "", "", ""};
        }

    }
}

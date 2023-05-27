namespace Develope03;

    public class Reference 
    {
        private string _book = "3 Nephi";
        private string _chapter = "11";
        private string _startVerse = "10";
        private string _endVerse = "11";

        public string Ref(){
            //creates the scripture reference
            string verse;

            if (_endVerse != ""){
                verse = _book + " " + _chapter + ":" + _startVerse + "-" + _endVerse;
            }
            else{
                verse = _book +" " + _chapter + ";" + _startVerse;
            }
            return verse;
        }


    }


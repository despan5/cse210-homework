//class that handles the scripture reference being entered. 
//Has multiple methods depending on what is inputted.
namespace Develope03;
    class Reference 
    {
        //attributes.
        private string _book = "";
        private string _chapter = "";
        private string _startVerse = "";
        private string _endVerse = "";

        //method for only 1 verse.
        public Reference(string book, string chapter, string startVerse){
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
   
        }

        //method for multiple verses.
        public Reference(string book, string chapter, string startVerse, string endVerse){
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        //method for if the reference is 1 string.
        public Reference(string reference){
            string identifier = reference;
            string[] verse = identifier.Split(" ");
            _book = verse[0];
            _chapter = verse[1];
            _startVerse = verse[2];
            _endVerse = verse[3];
        }

        //puts it all together to return to user.
        public override string ToString()
        {
        if (_endVerse != ""){
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
        else{
            return $"{_book} {_chapter}:{_startVerse}";
        }
        
        }

    }
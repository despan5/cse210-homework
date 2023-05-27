namespace Develope03;
    
    public class Scripture
    {
        Reference reference = new Reference();
        List<Words> words = new List<Words>();
        int wordsToHide = 0;
        public bool isFinished(){
            //decides whether all of the words are gone or not
            bool finish = true;
            return finish;
        }

        public void parseScripture(string scripture){
            //iterates through the full scripture verse

        }

        public string display(string scripture, Reference reference, int wordsToHide){
            //displays the verse with the reference and the right number of words hidden
            string fullVerse = scripture + reference + wordsToHide;
            return fullVerse;
        }

        public void setVisibility(){
            //makes certain words visible or not

        }

    }
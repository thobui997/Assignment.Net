class Question
{
    public string questionText;
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;
    public char correctAnswerLetter;
    private char defaultCorrectAnswerLetter = 'X';

    public Question()
    {
        questionText = null;
        optionA = null;
        optionB = null;
        optionC = null;
        optionD = null;
        correctAnswerLetter = defaultCorrectAnswerLetter;
    }

    public Question(string questionText)
    {
        this.questionText = questionText;
        optionA = null;
        optionB = null;
        optionC = null;
        optionD = null;
        correctAnswerLetter = defaultCorrectAnswerLetter;
    }

    public Question(string questionText, string optionA, string optionB, string optionC, string optionD, char correctAnswerLetter)
    {
        this.questionText = questionText;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.optionD = optionD;
        if (correctAnswerLetter == 'A' || correctAnswerLetter == 'B' || correctAnswerLetter == 'C' || correctAnswerLetter == 'D')
            this.correctAnswerLetter = correctAnswerLetter;
        else
            this.correctAnswerLetter = defaultCorrectAnswerLetter;
    }

    public bool AreOptionValid()
    {
        return (optionA != null || optionB != null) && (optionC != null || optionD != null);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Question question1 = new Question(); //Create an object of Question class and pass no arguments to the constructor
        Question question2 = new Question("In which continent is costa rica situated?"); //Create an object of Question class and pass value for questionText only to the constructor.
        Question question3 = new Question("In which continent is costa rica situated?", "Asia", "North America", "South America", "Africa", 'B'); //Create an object of Question class and pass values for questionText, optionA, optionB, optionC, optionD and correctAnswerLetter to the constructor.
        Question question4 = new Question() { questionText = "In which continent is costa rica situated?", optionA = "Asia", optionB = "North America", optionC = "South America", optionD = "Africa" }; //Create an object for Question class and pass values for questionText, optionA, optionB, optionC, optionD only to the constructor.
    }

}
class DebitClass
{
    private string _pin;
    public string Pin
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length == 4 || value.Length == 6)
                {
                    bool isValid = true;
                    for (int i = 0; i < value.Length; i++) //loop through each character in the value
                    {
                        if (value[i] < 48 || value[i] > 57) //ASCII codes 48 to 57 are equal to digits (0 to 9)  Refer: https://www.asciitable.com/
                            isValid = false; //if the character is not a digit, make isValid as false
                    }
                    if (isValid)
                        _pin = value; //PIN is valid
                    else
                        Console.WriteLine("PIN contains one or more non-digit characters.");
                }
                else
                    Console.WriteLine("PIN should contain either 4 digits or 6 digits");
            }
            else
                Console.WriteLine("PIN value can't be blank");
        }

        get { return _pin; }
    }
}
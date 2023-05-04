
using System.Reflection;

class MedicalBot
{
    public const string BotName = "Bob";

    public static string GetBotName()
    {
        return BotName;
    }

    public void PrescribeMedication(Patient patient)
    {
        switch (patient.GetSymptoms().ToLower())
        {
            case "headache":
                patient.SetPrescription(GetDosage("ibuprofen"));
                break;
            case "rashes":
                patient.SetPrescription(GetDosage("diphenhydramine"));
                break;
            case "dizziness":
                if (patient.GetMedicalHistory() == "Diabetes")
                {
                    patient.SetPrescription(GetDosage("metformin"));
                }
                else
                {
                    patient.SetPrescription(GetDosage("dimenhydrinate"));
                }
                break;
        }

        string GetDosage(string medicineName)
        {
            if (medicineName == "ibuprofen")
            {
                return $"Your prescription based on your age, symptoms and medical history: {medicineName} {(patient.GetAge() < 18 ? 400 : 800)} mg";
            }

            if (medicineName == "diphenhydramine")
            {
                return $"Your prescription based on your age, symptoms and medical history: {medicineName} {(patient.GetAge() < 18 ? 50 : 300)} mg";
            }

            if (medicineName == "metformin")
            {
                return $"Your prescription based on your age, symptoms and medical history: {medicineName} 500 mg";

            }

            return "unknown";

        }


    }
}

class Patient
{
    private string Name;
    private int Age;
    private string Gender;
    private string MedicalHistory;
    private string SymptomCode;
    private string Prescription;

    public string GetName()
    {
        return Name;
    }

    public bool SetName(string name, out string errorMessage)
    {
        errorMessage = string.Empty;
        if (string.IsNullOrEmpty(name) || name.Length < 2)
        {
            errorMessage = "name invalid";
            return false;
        }
        Name = name;
        return true;
    }

    public int GetAge()
    {
        return Age;
    }

    public bool SetAge(int age, out string errorMessage)
    {
        errorMessage = string.Empty;
        if (age <= 0 || age > 100)
        {
            errorMessage = "age invalid";
            return false;
        }
        Age = age;
        return true;
    }

    public string GetGender()
    {
        return Gender;
    }

    public bool SetGender(string gender, out string errorMessage)
    {
        errorMessage = string.Empty;
        if (gender.ToLower() != "male" && gender != "female".ToLower())
        {
            errorMessage = "gender invalid";
            return false;
        }
        Gender = gender;
        return true;
    }

    public string GetMedicalHistory()
    {
        return MedicalHistory;
    }

    public void SetMedicalHistory(string medicalHistory)
    {
        MedicalHistory = medicalHistory;
    }

    public string GetSymptoms()
    {
        string symptom;

        // Use a switch statement to determine the symptom based on the symptom code
        switch (SymptomCode)
        {
            case "S1":
            case "s1": symptom = "Headache"; break;

            case "S2":
            case "s2": symptom = "Skin rashes"; break;

            case "S3":
            case "s3": symptom = "Dizziness"; break;

            default: symptom = "Unknown"; break;
        }

        return symptom;
    }

    public string GetSymptomCode()
    {
        return SymptomCode;
    }

    public bool SetSymptomCode(string symptomCode, out string errorMessage)
    {
        // Check if the symptom code is valid
        if (symptomCode != "S1" && symptomCode != "S2" && symptomCode != "S3" && symptomCode != "s1" && symptomCode != "s2" && symptomCode != "s3")
        {

            errorMessage = "Symptom Code should either be S1, S2, or S3.";
            return false;
        }

        errorMessage = "";

        // Set the symptom code for the patient
        SymptomCode = symptomCode;
        return true;
    }

    public string GetPrescription()
    {
        return Prescription;
    }

    public void SetPrescription(string prescription)
    {
        Prescription = prescription;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hi, I'm " + MedicalBot.GetBotName() + ". I'm here to help you in your medication.");
        Console.WriteLine("Enter your (patient) details:");

        Patient patient = new Patient();
        Console.Write("Enter Patient Name: ");

        while (!patient.SetName(Console.ReadLine(), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.WriteLine("Enter Patient Name: ");
        }

        Console.Write("Enter Patient Age: ");
        while (!patient.SetAge(Convert.ToInt32(Console.ReadLine()), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Enter Patient Age: ");
        }

        Console.Write("Enter Patient Gender: ");
        while (!patient.SetGender(Console.ReadLine(), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Enter Patient Gender: ");
        }

        Console.Write("Enter Medical History. Eg: Diabetes. Press Enter for None: ");
        patient.SetMedicalHistory(Console.ReadLine());

        // Display patient details
        Console.WriteLine($"\nWelcome, " + patient.GetName() + ", " + patient.GetAge() + ".");
        Console.WriteLine("Which of the following symptoms do you have:");
        Console.WriteLine("S1. Headache");
        Console.WriteLine("S2. Skin rashes");
        Console.WriteLine("S3. Dizziness");

        // Read patient's symptom code and validate it
        Console.Write("Enter the symptom code from above list (S1, S2 or S3): ");
        while (!patient.SetSymptomCode(Console.ReadLine(), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Enter the symptom code from above list (S1, S2 or S3): ");
        }

        // Create a new MedicalBot and prescribe medication for the patient
        MedicalBot doctorBot = new MedicalBot();
        doctorBot.PrescribeMedication(patient);

        // Display the prescription for the patient
        Console.WriteLine(patient.GetPrescription());

        // Goodbye message
        Console.WriteLine("\nThank you for coming.");
        Console.ReadKey();
    }
}
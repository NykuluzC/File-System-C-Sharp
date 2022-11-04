using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

namespace FileSystem
{
    public class FileAPP
    {
        public static void Main(string[] args)
        {
            Dots();
            int n = 1;
            do
            {


                Console.Clear();
                Console.WriteLine("\t\t\t\t\t" +
                 "***EXISTING FILES WITHIN THE DIRECTORY***");
                var txtFiles = new DirectoryInfo("C:\\File System").GetFiles("*.txt");
                for (int i = 0; i < txtFiles.Length; i++)
                {
                    var firsttxtFilename = txtFiles[i].Name;
                    Console.WriteLine(firsttxtFilename);
                }

                Console.WriteLine("[1] Create A New File");
                Console.WriteLine("[2] Open Existing File");
                Console.WriteLine("[3] Manage Data");
                Console.WriteLine("[4] Delete a File");
                Console.WriteLine("[5] Exit");
                Console.Write("Your Choice: ");
                var choice1st = Console.ReadLine();


                //Get The List of all Files inside the directory

                switch (choice1st)
                {
                    case "1":
                        {
                            Dots();
                            Console.Write("What is your desired file name: ");
                            string? filename = Console.ReadLine();
                            string filepath = fileLocation(filename);
                            if (!File.Exists(filepath))
                            {
                                Console.WriteLine("Do you want to Create This File?" + "\n Type YES/yes or NO/no");
                                string createDecision = Console.ReadLine().ToUpper();
                                fileMaker(createDecision, filepath);
                                string textChoice3 = ("---------------------------------------------------------------------------------------------------\r\nRec\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\t\tGender\r\n----------------------------------------------------------------------------------------------------");
                                File.AppendAllText(filepath, textChoice3);
                                Dots();

                            }
                            else
                            {
                                Console.WriteLine("\n\n\t\t\t\t\t\t" +
                                    "*File already Exists :<*\n\n");
                                break;
                            }
                            break;
                        }
                    case "2":
                        {
                            Dots();
                            Console.Write("Name of the file that you want to Open: ");
                            string? filename1 = Console.ReadLine();
                            var filepath1 = fileLocation(filename1);


                            if (!File.Exists(filepath1))
                            {
                                Console.WriteLine("Do you want to Create This File?" + "\n Type YES/yes or NO/no");
                                string createDecision = Console.ReadLine().ToUpper();
                                fileMaker(createDecision, filepath1);
                                string textChoice3 = ("---------------------------------------------------------------------------------------------------\r\nRec\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\t\tGender\r\n----------------------------------------------------------------------------------------------------");
                                File.AppendAllText(filepath1, textChoice3);
                                Dots();

                            }

        
                            StreamReader fileOpen = new StreamReader(filepath1);
                            string fO = fileOpen.ReadToEnd();
                            Console.WriteLine(fO);
                            fileOpen.Close();
                      
                            break;
                        }





                    case "3":
                        {
                            Console.Write("What is your desired file name: ");
                            string? modifyfile = Console.ReadLine();
                            string Location = fileLocation(modifyfile);
                            string Location1 = fileLocation(modifyfile);

                            if (!File.Exists(Location))
                            {
                                Dots();
                                Console.WriteLine("\n\t\t\t\t\t" + "***The Desired Text File is not existing!!!***");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\n");
                            }
                            StringBuilder newString = new StringBuilder();
                            Console.WriteLine("\n" + "[A]dd  [E]dit [D]elete  [S]ort  [F]ilter  e[X]it");

                            string? manageInput = Console.ReadLine();

                            Dots();
                            string alltext = File.ReadAllText(Location);

                            if (manageInput.ToUpper() == "A")
                            {
                                Dots();
                                Console.Clear();
                                //ID PROCESSING
                                Console.Write("ID NUMBER: ");
                                string idProcess = Console.ReadLine();

                                //Conditions of ID input
                                if (!Regex.IsMatch(idProcess, @"^[0-9]+$")) //Assumes a situation that the inputted value is not numeric
                                {
                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                    break;
                                }
                                else if (idProcess.Length != 8) //VSU ID format is only 8 length value
                                {

                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed wrong format of an ID number****");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("");
                                }

                                //Creates the format of the final output of ID VALUE
                                string idVal = idProcess.Substring(0, 2) + "-" + idProcess.Substring(2, 1) + "-" + idProcess.Substring(3, 5);

                                //LAST NAME PROCESSING
                                Console.Write("LAST NAME: ");
                                string lastVal = Console.ReadLine().ToUpper();

                                //Conditions of Last Name Output
                                if (!Regex.IsMatch(lastVal, @"^[a-zA-Z]+$")) //assumes a situation that the input value is not able to meet to the condition that limits its values to be only letters
                                {
                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non letter input****");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("");
                                }

                                //FIRST NAME PROCESSING
                                Console.Write("FIRST NAME: ");
                                string firstVal = Console.ReadLine().ToUpper();

                                //Conditions of First Name Output
                                if (!Regex.IsMatch(firstVal, @"^[a-zA-Z]+$")) //assumes a situation that the input value is not able to meet to the condition that limits its values to be only letters
                                {
                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non letter input****");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("");
                                }

                                //BIRTHDATE PROCESSING
                                Console.WriteLine("###BIRTHDATE###");

                                //year processing
                                bool priorDecision = false;
                                Console.Write("Year:");
                                string yearString = Console.ReadLine();
                                if (!Int32.TryParse(yearString, out int yearInt)) //assumes a situation that there is no equivalent int to the string value
                                {
                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                    break;
                                }
                                else if (yearInt >= 2023 || yearInt <= 0) //Limits the input to a realistic year choice.
                                {
                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed invalid YEAR input****");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("");
                                }
                                string yearVal = (yearInt % 100).ToString("00"); //takes the remainder of the modulo 100 process to make the format /00/ - /99/
                                bool finalDecision = leapOrNot(yearInt, priorDecision); //creates a condition for a value to hold if it is leap year or not, true or false return


                                //month processing
                                Console.Write("Month:");
                                string monthString = Console.ReadLine();
                                if (!Int32.TryParse(monthString, out int monthInt)) //assumes a situation that there is no equivalent int to the string value
                                {
                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                    break;
                                }
                                else if (monthInt > 12 || monthInt <= 0) //Limits the input to a realistic month choice.
                                {
                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed invalid MONTH input****");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("");
                                }
                                string monthVal = String.Format("{0:00}", monthInt); //formats the month to have preceeding 0 if it lesser than 10


                                //day processing
                                int dayLimit = daysOfMonth(monthInt, finalDecision); //creates a condition for the day input to be tested if it is a genuine day within that month
                                                                                     //based if it either meets the leap year day count change of February or the regular count day counts of every month.
                                Console.Write("Day:");
                                string dayString = Console.ReadLine();
                                if (!Int32.TryParse(dayString, out int dayInt))
                                {
                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                    break;
                                }
                                else if (dayInt > dayLimit || dayInt <= 0)
                                {
                                    Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed invalid Day input****");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("");
                                }
                                string dayVal = String.Format("{0:00}", dayInt); //formats the day to have preceeding 0 if it lesser than 10


                                //birthdate value processing
                                string birthVal = monthVal + "/" + dayVal + "/" + yearVal;

                                //GENDER PROCESSING
                                Console.Write("GENDER: ");
                                string genderVal = Console.ReadLine().ToUpper(); //sets the supposed to be assumed value by genderVal variable to be uppercase
                                if (genderVal != "M" && genderVal != "F")
                                {
                                    Console.WriteLine("\t\t\t\t" + "Input is Invalid, inputed value is not either of the choices");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("");
                                }
                                //



                                string numberingFormat = numberingLines(Location).ToString();

                                string[] dataOutput = dataInputs(idVal, lastVal, firstVal, birthVal, genderVal);

                                string dataOutputString = "\t" + dataOutput[0] + "\t" + dataOutput[1] + "\t" + dataOutput[2] + "\t" + "\t" + "\t" + dataOutput[3] + "\t" + "\t" + dataOutput[4] + "\t";


                                Console.WriteLine("---------------------------------------------------------------------------------------------------\r\n\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\t\tGender\r\n----------------------------------------------------------------------------------------------------");

                                Console.WriteLine(dataOutputString);

                                Console.WriteLine("Enter V if you want to save your input");
                                string? saveOrNot = Console.ReadLine();
                                string decisionV = saveOrNot.ToUpper();

                                if (decisionV == "V")
                                {
                                    File.AppendAllText(Location, "\n" + numberingFormat + dataOutputString);

                                }
                                else
                                {
                                    Console.WriteLine("\n\t\t\t\t\t\t" + "Data was not Saved!");
                                }

                            }
                            // end of Append

                            if (manageInput.ToUpper() == "E")//Start of edit
                            {
                                bool parser = true;
                                do
                                {
                                    Console.Clear();

                                    string readEdit = File.ReadAllText(Location);
                                    Console.WriteLine(readEdit);
                                    string[] strings = Regex.Split(readEdit, Environment.NewLine);
                                    string Numbering;

                                    for (int p = 0; p < strings.Length; p++)
                                    {
                                        if (p == strings.Length - 1)
                                        {
                                            Console.Write("Which Record Line do you want to edit:");
                                            string lineChoice = Console.ReadLine();

                                            List<string> quotelist = File.ReadAllLines(Location).ToList();

                                            if (int.TryParse(lineChoice, out int lineChoiceInt) & quotelist.Count >= lineChoiceInt + 3) //controls that the user should input integer else the system detects the else statement
                                            {
                                                lineChoiceInt = lineChoiceInt + 2;
                                                string[] fields = quotelist[lineChoiceInt].Split('\t');

                                                showField(fields);


                                                Console.WriteLine("[Input this to choose]Choose data to change: [I]ID-NUMBER, [L]LASTNAME, [F]FIRSTNAME, [B]BIRTHDATE, [G]GENDER, [A]ALL");
                                                string valueDecision = Console.ReadLine().ToUpper();


                                                switch (valueDecision.ToUpper())
                                                {

                                                    case "I":
                                                        {
                                                            Console.Write("New ID Value: ");
                                                            string newID = Console.ReadLine();
                                                            if (!Regex.IsMatch(newID, @"^[0-9]+$")) //Assumes a situation that the inputted value is not numeric
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                                                break;
                                                            }
                                                            else if (newID.Length != 8) //VSU ID format is only 8 length value
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed wrong format of an ID number****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }


                                                            Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nRec\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\t\tGender\r\n----------------------------------------------------------------------------------------------------");

                                                            //formatting id
                                                            string idVal = newID.Substring(0, 2) + "-" + newID.Substring(2, 1) + "-" + newID.Substring(3, 5);
                                                            fields[1] = idVal;

                                                            //formatting output
                                                            string dataOutputStringID = fields[0] + "\t" + fields[1] + "\t" + fields[2] + "\t" + fields[3] + "\t" + "\t" + "\t" + fields[6] + "\t" + "\t" + fields[8] + "\t";
                                                            string dataOutputHolder = dataOutputStringID;
                                                            Console.WriteLine(dataOutputHolder);

                                                            //change processing
                                                            Console.WriteLine("\n\nDo you want to save this Change/s?, [1] if yes or [2] if no");
                                                            string idChange = Console.ReadLine();
                                                            if (idChange == "2")
                                                            {
                                                                Console.WriteLine("Changes has been Aborted!");
                                                            }
                                                            else if (idChange == "1")
                                                            {
                                                                //Actual value changing processs
                                                                valueChange(Location, quotelist, lineChoiceInt, dataOutputStringID);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid Input");
                                                                break;
                                                            }



                                                            break;
                                                        }
                                                    case "L":
                                                        {
                                                            Console.Write("New LastName Value: ");
                                                            string newlName = Console.ReadLine().ToUpper();
                                                            //Conditions of Last Name Output
                                                            if (!Regex.IsMatch(newlName, @"^[a-zA-Z]+$")) //assumes a situation that the input value is not able to meet to the condition that limits its values to be only letters
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non letter input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");

                                                            }

                                                            Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nRec\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\t\tGender\r\n----------------------------------------------------------------------------------------------------");

                                                            //formatting lastname
                                                            fields[2] = newlName;

                                                            //formatting output
                                                            string dataOutputStringlastName = fields[0] + "\t" + fields[1] + "\t" + fields[2] + "\t" + fields[3] + "\t" + "\t" + "\t" + fields[6] + "\t" + "\t" + fields[8] + "\t";

                                                            Console.WriteLine(dataOutputStringlastName);

                                                            //change processing
                                                            Console.WriteLine("\n\nDo you want to save this Change/s?, [1] if yes or [2] if no");
                                                            string lastNChange = Console.ReadLine();
                                                            if (lastNChange == "2")
                                                            {
                                                                Console.WriteLine("Changes has been Aborted!");
                                                                break;
                                                            }
                                                            else if (lastNChange == "1")
                                                            {
                                                                //Actual value changing processs
                                                                valueChange(Location, quotelist, lineChoiceInt, dataOutputStringlastName);
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid Input");
                                                                break;
                                                            }
                                                            break;
                                                        }
                                                    case "F":
                                                        {
                                                            Console.Write("New FirstName Value: ");
                                                            string newfName = Console.ReadLine().ToUpper();
                                                            //Conditions of First Name Output
                                                            if (!Regex.IsMatch(newfName, @"^[a-zA-Z]+$")) //assumes a situation that the input value is not able to meet to the condition that limits its values to be only letters
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non letter input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }
                                                            Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nRec\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\t\tGender\r\n----------------------------------------------------------------------------------------------------");

                                                            //formatting firstname
                                                            fields[3] = newfName;

                                                            //formatting output
                                                            string dataOutputStringfirstName = fields[0] + "\t" + fields[1] + "\t" + fields[2] + "\t" + fields[3] + "\t" + "\t" + "\t" + fields[6] + "\t" + "\t" + fields[8] + "\t";

                                                            Console.WriteLine(dataOutputStringfirstName);

                                                            //change processing
                                                            Console.WriteLine("\n\nDo you want to save this Change/s?, [1] if yes or [2] if no");
                                                            string firstNChange = Console.ReadLine();
                                                            if (firstNChange == "2")
                                                            {
                                                                Console.WriteLine("Changes has been Aborted!");
                                                            }
                                                            else if (firstNChange == "1")
                                                            {
                                                                //Actual value changing processs
                                                                valueChange(Location, quotelist, lineChoiceInt, dataOutputStringfirstName);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid Input");
                                                            }
                                                            break;

                                                        }
                                                    case "B":
                                                        {
                                                            //New BIRTHDATE PROCESSING
                                                            Console.WriteLine("### NEW BIRTHDATE VALUE###");

                                                            //new year processing
                                                            bool priorDecision = false;
                                                            Console.Write("New Year Value:");
                                                            string yearString = Console.ReadLine();
                                                            if (!Int32.TryParse(yearString, out int yearInt)) //assumes a situation that there is no equivalent int to the string value
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                                                break;
                                                            }
                                                            else if (yearInt >= 2023 || yearInt <= 0) //Limits the input to a realistic year choice.
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed invalid YEAR input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }
                                                            string yearVal = (yearInt % 100).ToString("00"); //takes the remainder of the modulo 100 process to make the format /00/ - /99/
                                                            bool finalDecision = leapOrNot(yearInt, priorDecision); //creates a condition for a value to hold if it is leap year or not, true or false return


                                                            //new month processing
                                                            Console.Write("New Month Value:");
                                                            string monthString = Console.ReadLine();
                                                            if (!Int32.TryParse(monthString, out int monthInt)) //assumes a situation that there is no equivalent int to the string value
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                                                break;
                                                            }
                                                            else if (monthInt > 12 || monthInt <= 0) //Limits the input to a realistic month choice.
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed invalid MONTH input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }
                                                            string monthVal = String.Format("{0:00}", monthInt); //formats the month to have preceeding 0 if it lesser than 10


                                                            //new day processing
                                                            int dayLimit = daysOfMonth(monthInt, finalDecision); //creates a condition for the day input to be tested if it is a genuine day within that month
                                                                                                                 //based if it either meets the leap year day count change of February or the regular count day counts of every month.
                                                            Console.Write("New Day Value:");
                                                            string dayString = Console.ReadLine();
                                                            if (!Int32.TryParse(dayString, out int dayInt))
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                                                break;
                                                            }
                                                            else if (dayInt > dayLimit || dayInt <= 0)
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed invalid Day input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }
                                                            string dayVal = String.Format("{0:00}", dayInt); //formats the day to have preceeding 0 if it lesser than 10


                                                            //birthdate value processing
                                                            string newbDate = monthVal + "/" + dayVal + "/" + yearVal;

                                                            Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nRec\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\t\tGender\r\n----------------------------------------------------------------------------------------------------");

                                                            //formatting firstname
                                                            fields[6] = newbDate;

                                                            //formatting output
                                                            string dataOutputStringbDate = fields[0] + "\t" + fields[1] + "\t" + fields[2] + "\t" + fields[3] + "\t" + "\t" + "\t" + fields[6] + "\t" + "\t" + fields[8] + "\t";

                                                            Console.WriteLine(dataOutputStringbDate);

                                                            //change processing
                                                            Console.WriteLine("\n\nDo you want to save this Change/s?, [1] if yes or [2] if no");
                                                            string bDateChange = Console.ReadLine();
                                                            if (bDateChange == "2")
                                                            {
                                                                Console.WriteLine("Changes has been Aborted!");
                                                                break;
                                                            }
                                                            else if (bDateChange == "1")
                                                            {
                                                                //Actual value changing processs
                                                                valueChange(Location, quotelist, lineChoiceInt, dataOutputStringbDate);
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid Input");
                                                                break;
                                                            }
                                                        }
                                                        break;

                                                    //New Gender Processing
                                                    case "G":
                                                        {
                                                            Console.Write("New Gender Value: ");
                                                            String newGenderVal = Console.ReadLine().ToUpper();
                                                            if (newGenderVal != "M" && newGenderVal != "F")
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "Input is Invalid, inputed value is not either of the choices");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }
                                                            fields[8] = newGenderVal;

                                                            //formatting output
                                                            string dataOutputStringGender = fields[0] + "\t" + fields[1] + "\t" + fields[2] + "\t" + fields[3] + "\t" + "\t" + "\t" + fields[6] + "\t" + "\t" + fields[8] + "\t";

                                                            Console.WriteLine(dataOutputStringGender);

                                                            //change processing
                                                            Console.WriteLine("\n\nDo you want to save this Change/s?, [1] if yes or [2] if no");
                                                            string genderChange = Console.ReadLine();
                                                            if (genderChange == "2")
                                                            {
                                                                Console.WriteLine("Changes has been Aborted!");
                                                                break;
                                                            }
                                                            else if (genderChange == "1")
                                                            {
                                                                //Actual value changing processs
                                                                valueChange(Location, quotelist, lineChoiceInt, dataOutputStringGender);
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid Input");
                                                                break;
                                                            }
                                                            break;
                                                        }
                                                    case "A":
                                                        {
                                                            //ID
                                                            Console.Write("New ID Value: ");
                                                            string newIDAll = Console.ReadLine();

                                                            //Conditions of Id Output
                                                            if (!Regex.IsMatch(newIDAll, @"^[0-9]+$")) //Assumes a situation that the inputted value is not numeric
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                                                break;
                                                            }
                                                            else if (newIDAll.Length != 8) //VSU ID format is only 8 length value
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed wrong format of an ID number****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }


                                                            //LAST NAME
                                                            Console.Write("New LastName Value: ");
                                                            string newlNameAll = Console.ReadLine().ToUpper();

                                                            //Conditions of Last Name Output
                                                            if (!Regex.IsMatch(newlNameAll, @"^[a-zA-Z]+$")) //assumes a situation that the input value is not able to meet to the condition that limits its values to be only letters
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non letter input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");

                                                            }

                                                            //FIRST NAME
                                                            Console.Write("New FirstName Value: ");
                                                            string newfNameAll = Console.ReadLine().ToUpper();

                                                            //Conditions of First Name Output
                                                            if (!Regex.IsMatch(newfNameAll, @"^[a-zA-Z]+$")) //assumes a situation that the input value is not able to meet to the condition that limits its values to be only letters
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non letter input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }

                                                            //New BIRTHDATE PROCESSING
                                                            Console.WriteLine("### NEW BIRTHDATE VALUE###");

                                                            //new year processing
                                                            bool priorDecision1 = false;
                                                            Console.Write("New Year Value:");
                                                            string yearString1 = Console.ReadLine();
                                                            if (!Int32.TryParse(yearString1, out int yearInt1)) //assumes a situation that there is no equivalent int to the string value
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                                                break;
                                                            }
                                                            else if (yearInt1 >= 2023 || yearInt1 <= 0) //Limits the input to a realistic year choice.
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed invalid YEAR input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }
                                                            string yearVal1 = (yearInt1 % 100).ToString("00"); //takes the remainder of the modulo 100 process to make the format /00/ - /99/
                                                            bool finalDecision1 = leapOrNot(yearInt1, priorDecision1); //creates a condition for a value to hold if it is leap year or not, true or false return


                                                            //new month processing
                                                            Console.Write("New Month Value:");
                                                            string monthString1 = Console.ReadLine();
                                                            if (!Int32.TryParse(monthString1, out int monthInt1)) //assumes a situation that there is no equivalent int to the string value
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                                                break;
                                                            }
                                                            else if (monthInt1 > 12 || monthInt1 <= 0) //Limits the input to a realistic month choice.
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed invalid MONTH input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }
                                                            string monthVal1 = String.Format("{0:00}", monthInt1); //formats the month to have preceeding 0 if it lesser than 10


                                                            //new day processing
                                                            int dayLimit1 = daysOfMonth(monthInt1, finalDecision1); //creates a condition for the day input to be tested if it is a genuine day within that month
                                                                                                                    //based if it either meets the leap year day count change of February or the regular count day counts of every month.
                                                            Console.Write("New Day Value:");
                                                            string dayString1 = Console.ReadLine();
                                                            if (!Int32.TryParse(dayString1, out int dayInt1))
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed a non numeric input****");
                                                                break;
                                                            }
                                                            else if (dayInt1 > dayLimit1 || dayInt1 <= 0)
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "****Input is Invalid as you have inputed invalid Day input****");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }
                                                            string dayVal1 = String.Format("{0:00}", dayInt1); //formats the day to have preceeding 0 if it lesser than 10


                                                            //birthdate value processing
                                                            string newbDate1 = monthVal1 + "/" + dayVal1 + "/" + yearVal1;

                                                            //GENDER 
                                                            Console.Write("New Gender Value: ");
                                                            String newGenderVal1 = Console.ReadLine().ToUpper();
                                                            if (newGenderVal1 != "M" && newGenderVal1 != "F")
                                                            {
                                                                Console.WriteLine("\t\t\t\t" + "Input is Invalid, inputed value is not either of the choices");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("");
                                                            }

                                                            Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nRec\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\t\tGender\r\n----------------------------------------------------------------------------------------------------");

                                                            //formatting AllInputs and their own individual formats
                                                            string idValAll = newIDAll.Substring(0, 2) + "-" + newIDAll.Substring(2, 1) + "-" + newIDAll.Substring(3, 5);
                                                            fields[1] = idValAll;
                                                            fields[2] = newlNameAll;
                                                            fields[3] = newfNameAll;
                                                            fields[6] = newbDate1;
                                                            fields[7] = newGenderVal1;
                                                            //formatting output
                                                            string dataOutputStringAll = fields[0] + "\t" + fields[1] + "\t" + fields[2] + "\t" + fields[3] + "\t" + "\t" + "\t" + fields[6] + "\t" + "\t" + fields[8] + "\t";
                                                            string dataOutputHolderAll = dataOutputStringAll;
                                                            Console.WriteLine(dataOutputStringAll);

                                                            //change processing
                                                            Console.WriteLine("\n\nDo you want to save this Change/s?, [1] if yes or [2] if no");
                                                            string idChangeAll = Console.ReadLine();
                                                            if (idChangeAll == "2")
                                                            {
                                                                Console.WriteLine("Changes has been Aborted!");
                                                            }
                                                            else if (idChangeAll == "1")
                                                            {
                                                                //Actual value changing processs
                                                                valueChange(Location, quotelist, lineChoiceInt, dataOutputStringAll);
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid Input");
                                                            }

                                                        }


                                                        break;
                                                    default:
                                                        {
                                                            break;
                                                        }

                                                }
                                            }
                                        }
                                    }
                                } while (true);
                            }
                            if (manageInput.ToUpper() == "D")
                            {
                                var stringDel = File.ReadAllText(Location);
                                Console.WriteLine(stringDel);
                                string[] stringstoDel = Regex.Split(stringDel, Environment.NewLine);


                                int decisionCounter = 1;

                                for (int del = 0; del <= stringstoDel.Length; del++)
                                {
                                    Console.WriteLine("What RECORD NUMBER do you want to delete?");
                                    string deleteDec = Console.ReadLine();
                                    Int32.TryParse(deleteDec, out int deleteDecInt);
                                    if (del + 2 < stringstoDel.Length+2)
                                    {
                                        File_DeleteLine(deleteDecInt + 3, Location);
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("RECORD DOES NOT EXIST");
                                        break;
                                    }
                                    Console.WriteLine("Do you want to delete further?[Y]YES,[N]NO");
                                    String answer = Console.ReadLine().ToUpper();
                                    if (answer == "Y")
                                    {
                                        decisionCounter++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            if (manageInput.ToUpper() == "S")
                            {
                                bool parserR;
                                do
                                {
                                    var stringSort = File.ReadAllText(Location);
                                    Console.WriteLine(stringSort);


                                    List<string> listToDel = File.ReadAllLines(Location).ToList();


                                    for (int i = 1; i < listToDel.Count; i++)
                                    {
                                        if (i >= 3)
                                        {

                                            string[] fields = listToDel[i].Split('\t');

                                        }
                                    }
                                    Console.WriteLine("What value/values you want to be sorted?");

                                    Console.WriteLine("[R]RECORD NUMBER, [I]ID-NUMBER, [L]LASTNAME, [F]FIRSTNAME, [B]BIRTHDATE, [G]GENDER");
                                    string sortInput = Console.ReadLine().ToUpper();
                                    //rec
                                    if (sortInput == "R")
                                    {
                                        SortingRec(Location);
                                    }
                                    //id
                                    else if (sortInput == "I")
                                    {
                                        SortingID(Location);
                                    }
                                    //lastname
                                    else if (sortInput == "L")
                                    {
                                        SortinglName(Location);
                                    }
                                    //fname
                                    else if (sortInput == "F")
                                    {
                                        SortingfName(Location);
                                    }
                                    //bdate
                                    else if (sortInput == "B")
                                    {
                                        SortingbDate(Location);
                                    }
                                    //gender
                                    else if (sortInput == "G")
                                    {
                                        SortingGender(Location);
                                    }
                                    Console.WriteLine("Do you wish to do more Sorting Activity?, Input [Y] if yes; [N] if no");
                                    string SortRep1 = Console.ReadLine();
                                        if (SortRep1.ToUpper() == "Y")
                                        {
                                            parserR = true;
                                            Console.Clear();
                                        }
                                        else if (SortRep1.ToUpper() == "N")
                                        {
                                            parserR = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Input");

                                            break;
                                        }
                                } while (parserR == true);
                            }
                            if (manageInput.ToUpper() == "F")
                            {
                                Console.Clear();

                                bool parserF = true;

                                do
                                {
                                    Dots();
                                    Console.WriteLine("\nWhat do you want to Filter: [I]ID ONLY, [L]LAST NAME ONLY, [F]FIRST NAME ONLY, [B] BIRTHDATE ONLY, [G] GENDER ONLY");
                                    string filterDec = Console.ReadLine().ToUpper();

                                    if (filterDec == "I")
                                    {
                                        Filter(Location, 0, 1, "ID");
                                    }

                                    else if (filterDec == "L")
                                    {
                                        Filter(Location, 0, 2, "LastName");
                                    }

                                    else if (filterDec == "F")
                                    {
                                        Filter(Location, 0, 3, "FirstName");
                                    }
                                    else if (filterDec == "B")
                                    {
                                        Filter(Location, 0, 6, "BirthDate");
                                    }
                                    else if (filterDec == "G")
                                    {
                                        Filter(Location, 0, 8, "Gender");
                                    }
                                 
                                        Console.WriteLine("Do you wish to do more Filtering Activity?, Input [Y] if yes; [N] if no");
                                        string filRep1 = Console.ReadLine();
                                        if (filRep1.ToUpper() == "Y")
                                        {
                                            parserF = true;
                                        }
                                        else if (filRep1.ToUpper() == "N")
                                        {
                                            parserF = false;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                } while (parserF == true);
                            }
                            if(manageInput.ToUpper() == "X")
                            {
                                break;
                            }
                            break;
                        }


                    case "4":
                        {
                            Console.WriteLine("\n" + "What is the name of that you want to delete: ");
                            string? fileDeleteChoice = Console.ReadLine();
                            string fileDelete = fileLocation(fileDeleteChoice);

                            if (File.Exists(fileDelete))
                            {
                                System.IO.File.Delete(fileDelete);

                            }
                            else
                            {
                                Console.WriteLine("\n" + "The File Does not Exist, therefore nothing is deleted!!!");
                            }
                            break;
                        }

                    case "5":
                        {
                            Dots();

                            Console.Write("\nThank you For Using Our System :D \n\n\n\n");
                            System.Environment.Exit(1);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("\n\n\t\t\t\t\t\t" +
                            "***Choice is Invalid!***\n\n");
                            break;
                        }

                }
                n--;
                if (n < 1)
                {
                    Console.Write("\n" + "Type YES/yes If You Still Want To Use The System: ");
                    string? v = Console.ReadLine();
                    string decision = v.ToUpper();

                    if (decision == "YES")
                    {
                        n++;
                    }
                    else
                    {
                        Console.WriteLine("Thank you for using this Program :>");
                    }
                }
            } while (n == 1);
        }

        //Appending
        public static string[] dataInputs(string idNum, string lastName, string firstName, string birthDate, string gender)
        {
            string[] data = new string[5];


            data[0] = idNum;
            data[1] = lastName;
            data[2] = firstName;
            data[3] = birthDate;
            data[4] = gender;


            return data;
        }

        public static bool leapOrNot(int yearprocess1, bool decision)
        {
            if (yearprocess1 % 4 == 0)
            {
                if ((yearprocess1 % 100 == 0) && (yearprocess1 % 400 != 0))
                {
                    decision = false;
                }
                else
                {
                    decision = true;
                }
            }
            return decision;

        }
        public static int daysOfMonth(int month, bool decisionyear)
        {
            if (month == 1)
            {
                return 31;
            }
            else if (month == 2 & decisionyear == true)
            {
                return 29;
            }
            else if (month == 2 & decisionyear == false)
            {
                return 28;
            }
            else if (month == 3)
            {
                return 31;
            }
            else if (month == 4)
            {
                return 30;
            }
            else if (month == 5)
            {
                return 31;
            }
            else if (month == 6)
            {
                return 30;
            }
            else if (month == 7)
            {
                return 31;
            }
            else if (month == 8)
            {
                return 31;
            }
            else if (month == 9)
            {
                return 30;
            }
            else if (month == 10)
            {
                return 31;
            }
            else if (month == 11)
            {
                return 30;
            }
            else if (month == 12)
            {
                return 31;
            }
            else
            {
                return 0;
            }
        }

        public static void Dots()
        {
            bool temp = true;
            while (temp == true)
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine("");


                    if (i == 1)
                    {
                        Console.Write("\t\t\t\t\t" + 'L');
                    }
                    else if (i == 2)
                    {
                        Console.Write("\t\t\t\t\t" + 'O');
                    }
                    else if (i == 3)
                    {
                        Console.Write("\t\t\t\t\t" + 'A');
                    }
                    else if (i == 4)
                    {
                        Console.Write("\t\t\t\t\t" + 'D');
                    }
                    else if (i == 5)
                    {
                        Console.Write("\t\t\t\t\t" + 'I');
                    }
                    else if (i == 6)
                    {
                        Console.Write("\t\t\t\t\t" + 'N');
                    }
                    else if (i == 7)
                    {
                        Console.Write("\t\t\t\t\t" + 'G');
                    }
                    else if (i == 8)
                    {
                        Console.Write("\t\t" + 'F');
                    }
                    else if (i == 9)
                    {
                        Console.Write("\t\t" + 'I');
                    }
                    else if (i == 10)
                    {
                        Console.Write("\t\t" + 'L');
                    }
                    else if (i == 11)
                    {
                        Console.Write("\t\t" + 'E');
                    }
                    else if (i == 12)
                    {
                        Console.Write("\t\t\t\t\t" + 'S');
                    }
                    else if (i == 13)
                    {
                        Console.Write("\t\t\t\t\t" + 'Y');
                    }
                    else if (i == 14)
                    {
                        Console.Write("\t\t\t\t\t" + 'S');
                    }
                    else if (i == 15)
                    {
                        Console.Write("\t\t\t\t\t" + 'T');
                    }
                    else if (i == 16)
                    {
                        Console.Write("\t\t\t\t\t" + 'E');
                    }
                    else if (i == 17)
                    {
                        Console.Write("\t\t\t\t\t" + 'M');
                    }
                    System.Threading.Thread.Sleep(100);

                    if (i == 0)
                    {
                        Console.Clear();
                    }
                    if (i == 19)
                    {
                        temp = false;
                        Console.Clear();
                    }
                }
            }
        }
        public static string dateFormater(int date)
        {
            if (date < 10 && date >= 0)
            {
                string formattedDay = date.ToString("00");
                return formattedDay;

            }

            else
            {
                return date.ToString();
            }

        }
        public static int numberingLines(string Location)
        {
            string output = "";
            string[] lines = File.ReadAllLines(Location);
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == lines.Length - 1)
                {
                    return i - 1;
                }
            }
            return 0;
        }

        //General Use
        public static dynamic fileLocation(string filename)//sets file location
        {
            var filepath = Path.Combine(@"\File System", filename + ".txt");
            return filepath;
        } 

        public static void fileMaker(string createDecision, string Location) // creates a file
        {
            if (createDecision == "YES")
            {
                using (StreamWriter sw = File.CreateText(Location))
                {
                    Console.Write("\n\n\t\t\t\t\t\t" +
                    "   " + "*File is Created*\n\n");
                    sw.Close();
                }
            }
            else if (createDecision == "NO")
            {
                Console.WriteLine("The File still cease to exist");
            }

        }

        public static void valueChange(string Location, List<string> quotelist, int lineChoiceInt, string dataOutputString) //changes the value within the file actual
        {
            StreamReader reader = new StreamReader(File.OpenRead(Location));

            string fileContent = reader.ReadToEnd();

            reader.Close();

            fileContent = fileContent.Replace(quotelist[lineChoiceInt], dataOutputString);

            StreamWriter writer = new StreamWriter(File.OpenWrite(Location));

            writer.Write(fileContent);

            writer.Close();
        }

        public static void showField(string[] fields) //shows all the changed fields - could be unchanged in the actual
        {
            Console.WriteLine("Rec Number:" + fields[0]);
            Console.WriteLine("ID Number:" + fields[1]);
            Console.WriteLine("Last Name:" + fields[2]);
            Console.WriteLine("First Name:" + fields[3]);
            Console.WriteLine("Birthdate:" + fields[6]);
            Console.WriteLine("Sex:" + fields[8]);
        }
        public static void File_DeleteLine(int Line, string Path) // deletes a line
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(Path))
            {
                int Countup = 0;
                while (!sr.EndOfStream)
                {
                    Countup++;
                    if (Countup != Line)
                    {
                        using (StringWriter sw = new StringWriter(sb))
                        {
                            sw.WriteLine(sr.ReadLine());
                        }
                    }
                    else
                    {
                        sr.ReadLine();
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.Write(sb.ToString());
            }

        }
        public static string[] SortLengthDescend(string[] arr)
        {
            string[] sorted = arr
                .OrderBy(x => x.Length) //.OrderByDescending
                .ToArray();

            return sorted;
        }

        public static List<string> query(string[] hatdog, string str)
        {
            var query = hatdog.Where(s => s.Contains(str));
            Func<string, string> sortExpr = s => s.Substring(s.IndexOf(str));

            query = query.OrderBy(sortExpr);

            List<string> queryList = query.ToList();

            return queryList;
        }
      
        //SORTING METHODS
        public static List<string> SortingRec(string Location)
        {
            List<string> quotelist = File.ReadAllLines(Location).ToList();

            List<string> valHolder = new List<string>();
            List<string> recSort = new List<string>();
            List<string> idSort = new List<string>();
            List<string> lNameSort = new List<string>();
            List<string> fNameSort = new List<string>();
            List<string> bDateSort = new List<string>();
            List<string> genderSort = new List<string>();
            List<string> categories = new List<string>();

            string[] data = File.ReadAllLines(Location);
            for (int p = 3; p < data.Length; p++)
            {

                string[] fields1 = quotelist[p].Split('\t');
                valHolder.Add("d%" + fields1[0]);
                valHolder.Add("d!" + fields1[1]);
                valHolder.Add("d@" + fields1[2]);
                valHolder.Add("d#" + fields1[3]);
                valHolder.Add("d^" + fields1[6]);
                valHolder.Add("d*" + fields1[8]);
            }
            var valVariable = valHolder.ToArray();
            List<string> valHolder2 = new List<string>();


            for (int z = 0; z < valVariable.Length; z++)
            {
                int count = 0;
                if (valVariable[z].Contains("%"))
                {
                    recSort.Add(valVariable[z].Split('%')[1]);
                }
                if (valVariable[z].Contains("!"))
                {
                    idSort.Add(valVariable[z].Split('!')[1]);
                }

                else if (valVariable[z].Contains("@"))
                {
                    lNameSort.Add(valVariable[z].Split("@")[1]);

                }
                else if (valVariable[z].Contains("#"))
                {
                    fNameSort.Add(valVariable[z].Split('#')[1]);

                }
                else if (valVariable[z].Contains("^"))
                {
                    bDateSort.Add(valVariable[z].Split('^')[1]);
                }
                else if (valVariable[z].Contains("*"))
                {
                    genderSort.Add(valVariable[z - 5].Split('%')[1].ToString() + "\t" + valVariable[z - 4].Split('!')[1].ToString() + "\t" + valVariable[z - 3].Split('@')[1].ToString() 
                        + "\t" + valVariable[z - 2].Split('#')[1].ToString() + "\t\t\t" + valVariable[z - 1].Split('^')[1].ToString() + "\t" + valVariable[z].Split('*')[1]);
                }
            }

            Console.WriteLine("Do you want to sort by: [A]Ascending or [D]Descending Manner");
            string? sortChoice = Console.ReadLine();

            if (sortChoice.ToUpper() == "D")
            {
                genderSort.Sort();
                genderSort.Reverse();
                Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nRec\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\tGender\r\n----------------------------------------------------------------------------------------------------");
                for (int y = 0; y < genderSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);
                }
            }
            else if (sortChoice.ToUpper() == "A")
            {
                genderSort.Sort();
                Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nRec\tStudent ID\tLastname\t\tFirstname\t\tBirthDate\tGender\r\n----------------------------------------------------------------------------------------------------");
                for (int y = 0; y < genderSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            return (genderSort);
        }
        public static List<string> SortingID(string Location)
        {
            List<string> quotelist = File.ReadAllLines(Location).ToList();

            List<string> valHolder = new List<string>();
            List<string> recSort = new List<string>();
            List<string> idSort = new List<string>();
            List<string> lNameSort = new List<string>();
            List<string> fNameSort = new List<string>();
            List<string> bDateSort = new List<string>();
            List<string> genderSort = new List<string>();
            List<string> categories = new List<string>();

            string[] data = File.ReadAllLines(Location);
            int column = 8;
            for (int p = 3; p < data.Length; p++)
            {

                string[] fields1 = quotelist[p].Split('\t');
                valHolder.Add("d%" + fields1[0]);
                valHolder.Add("d!" + fields1[1]);
                valHolder.Add("d@" + fields1[2]);
                valHolder.Add("d#" + fields1[3]);
                valHolder.Add("d^" + fields1[6]);
                valHolder.Add("d*" + fields1[8]);
            }
            var valVariable = valHolder.ToArray();
            List<string> valHolder2 = new List<string>();


            for (int z = 0; z < valVariable.Length; z++)
            {
                int count = 0;
                if (valVariable[z].Contains("%"))
                {
                    recSort.Add(valVariable[z].Split('%')[1]);
                }
                if (valVariable[z].Contains("!"))
                {
                    idSort.Add(valVariable[z].Split('!')[1]);
                }

                else if (valVariable[z].Contains("@"))
                {
                    lNameSort.Add(valVariable[z].Split("@")[1]);

                }
                else if (valVariable[z].Contains("#"))
                {
                    fNameSort.Add(valVariable[z].Split('#')[1]);

                }
                else if (valVariable[z].Contains("^"))
                {
                    bDateSort.Add(valVariable[z].Split('^')[1]);
                }
                else if (valVariable[z].Contains("*"))
                {
                    genderSort.Add(valVariable[z - 4].Split('!')[1].ToString() + "\t" + valVariable[z - 5].Split('%')[1].ToString()
                        + "\t" + valVariable[z - 3].Split('@')[1].ToString() + "\t" + valVariable[z - 2].Split('#')[1].ToString() +
                        "\t\t\t" + valVariable[z - 1].Split('^')[1].ToString() + "\t" + valVariable[z].Split('*')[1]);
                }
            }

            Console.WriteLine("Do you want to sort by: [A]Ascending or [D]Descending Manner");
            string sortGenderChoice = Console.ReadLine().ToUpper();
            if (sortGenderChoice == "D")
            {
                genderSort.Sort();

                genderSort.Reverse();

                for (int y = 0; y < genderSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);
                }

            }
            else if (sortGenderChoice == "A")
            {
                genderSort.Sort();

                for (int y = 0; y < genderSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nStudent ID\tRec\tLastname\t\tFirstname\t\tBirthDate\tGender\r\n----------------------------------------------------------------------------------------------------");


            return genderSort;
        }
        public static List<string> SortinglName(string Location)
        {
            List<string> quotelist = File.ReadAllLines(Location).ToList();
            List<string> valHolder = new List<string>();
            List<string> recSort = new List<string>();
            List<string> idSort = new List<string>();
            List<string> lNameSort = new List<string>();
            List<string> fNameSort = new List<string>();
            List<string> bDateSort = new List<string>();
            List<string> genderSort = new List<string>();
            List<string> categories = new List<string>();
            string[] data = File.ReadAllLines(Location);
            for (int p = 3; p < data.Length; p++)
            {

                string[] fields1 = quotelist[p].Split('\t');
                valHolder.Add("d%" + fields1[0]);
                valHolder.Add("d!" + fields1[1]);
                valHolder.Add("d@" + fields1[2]);
                valHolder.Add("d#" + fields1[3]);
                valHolder.Add("d^" + fields1[6]);
                valHolder.Add("d*" + fields1[8]);
            }
            var valVariable = valHolder.ToArray();
            List<string> valHolder2 = new List<string>();


            for (int z = 0; z < valVariable.Length; z++)
            {
                int count = 0;
                if (valVariable[z].Contains("%"))
                {
                    recSort.Add(valVariable[z].Split('%')[1]);
                }
                if (valVariable[z].Contains("!"))
                {
                    idSort.Add(valVariable[z].Split('!')[1]);
                }

                else if (valVariable[z].Contains("@"))
                {
                    lNameSort.Add(valVariable[z].Split("@")[1]);

                }
                else if (valVariable[z].Contains("#"))
                {
                    fNameSort.Add(valVariable[z].Split('#')[1]);

                }
                else if (valVariable[z].Contains("^"))
                {
                    bDateSort.Add(valVariable[z].Split('^')[1]);
                }
                else if (valVariable[z].Contains("*"))
                {
                    genderSort.Add(valVariable[z - 3].Split('@')[1].ToString() + "\t" + valVariable[z - 5].Split('%')[1].ToString() + "\t" + valVariable[z - 4].Split('!')[1].ToString() 
                        + "\t" + "\t" + valVariable[z - 2].Split('#')[1].ToString() + "\t\t" + valVariable[z - 1].Split('^')[1].ToString() + "\t" + valVariable[z].Split('*')[1]);
                }
            }
            Console.WriteLine("Do you want to sort by: [N]NORMAL ALPHABET FORMAT[A-Z] or [R]REVERSE ALPHABET FORMAT[Z-A]");
            string sortGenderChoice = Console.ReadLine().ToUpper();
            if (sortGenderChoice == "R")
            {
                genderSort.Sort();
                genderSort.Reverse();
                Console.WriteLine("\t\t\t\tA-Z REVERSE ALPHABET FORMAT");
                Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nLastname\tRec\tStudent ID\t\tFirstname\t\tBirthDate\tGender\r\n----------------------------------------------------------------------------------------------------");


                for (int y = 0; y < genderSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);

                }
            }
            else if (sortGenderChoice == "N")
            {
                genderSort.Sort();
                Console.WriteLine("\t\t\t\tA-Z NORMAL ALPHABET FORMAT");
                Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nLastname\tRec\tStudent ID\t\tFirstname\t\tBirthDate\tGender\r\n----------------------------------------------------------------------------------------------------");

                for (int y = 0; y < genderSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);

                }
            }

            if (sortGenderChoice == "R" || sortGenderChoice == "N")
            {
                List<string> listToDel = File.ReadAllLines(Location).ToList();

                List<string> lNameValues = new List<string>(); //creates a new list holder for values of lastname
                for (int i = 3; i < listToDel.Count; i++) //a loop to process the split solution for retrieving the IDVALUE
                {

                    string[] fields = listToDel[i].Split('\t');
                    lNameValues.Add(fields[2]); //adds the substring 1(which in this case is ID) of fields array to list holder for values of l
                }

                var lNameArr = lNameValues.ToArray(); //converts the list to an array for better modification, assumes the role for array holder for values of ID


                string[] lnameValArr = SortLengthDescend(lNameArr);

                Console.WriteLine("\n\n----------Ascending by length[LENGTH]-----------");
                Console.WriteLine("----------\r\nLastname\r\n----------");

                for (int i = 0; i < lnameValArr.Length; i++)
                {
                    Console.WriteLine(lnameValArr[i]); //printsout each index of the array holder for values of lastname

                }


                Console.WriteLine("\n\n----------Descending by length[LENGTH]-----------");
                Console.WriteLine("----------\r\nLastname\r\n----------");

                Array.Reverse(lnameValArr);

                for (int i = 0; i < lnameValArr.Length; i++)
                {
                    Console.WriteLine(lnameValArr[i]); //printsout each index of the array holder for values of lastname

                }

            }

            else
            {
                Console.WriteLine("Invalid Input");
                
            }


            
            return (genderSort);
        }
        public static List<string> SortingfName(string Location)
        {
            List<string> quotelist = File.ReadAllLines(Location).ToList();

            List<string> valHolder = new List<string>();
            List<string> recSort = new List<string>();
            List<string> idSort = new List<string>();
            List<string> lNameSort = new List<string>();
            List<string> fNameSort = new List<string>();
            List<string> bDateSort = new List<string>();
            List<string> genderSort = new List<string>();
            List<string> categories = new List<string>();

            string[] data = File.ReadAllLines(Location);
            int column = 8;
            for (int p = 3; p < data.Length; p++)
            {

                string[] fields1 = quotelist[p].Split('\t');
                valHolder.Add("d%" + fields1[0]);
                valHolder.Add("d!" + fields1[1]);
                valHolder.Add("d@" + fields1[2]);
                valHolder.Add("d#" + fields1[3]);
                valHolder.Add("d^" + fields1[6]);
                valHolder.Add("d*" + fields1[8]);
            }
            var valVariable = valHolder.ToArray();
            List<string> valHolder2 = new List<string>();


            for (int z = 0; z < valVariable.Length; z++)
            {
                int count = 0;
                if (valVariable[z].Contains("%"))
                {
                    recSort.Add(valVariable[z].Split('%')[1]);
                }
                if (valVariable[z].Contains("!"))
                {
                    idSort.Add(valVariable[z].Split('!')[1]);
                }

                else if (valVariable[z].Contains("@"))
                {
                    lNameSort.Add(valVariable[z].Split("@")[1]);

                }
                else if (valVariable[z].Contains("#"))
                {
                    fNameSort.Add(valVariable[z].Split('#')[1]);

                }
                else if (valVariable[z].Contains("^"))
                {
                    bDateSort.Add(valVariable[z].Split('^')[1]);
                }
                else if (valVariable[z].Contains("*"))
                {
                    genderSort.Add(valVariable[z - 2].Split('#')[1].ToString() + "\t" + valVariable[z - 4].Split('!')[1].ToString() 
                        + "\t" + valVariable[z - 5].Split('%')[1].ToString() + "\t" + "\t" + valVariable[z - 3].Split('@')[1].ToString()
                        + "\t\t\t" + valVariable[z - 1].Split('^')[1].ToString() + "\t" + valVariable[z].Split('*')[1]);
                }
            }

            Console.WriteLine("Do you want to sort by: [N]NORMAL ALPHABET FORMAT[A-Z] or [R]REVERSE ALPHABET FORMAT[Z-A]");
            string sortGenderChoice = Console.ReadLine().ToUpper();
            if (sortGenderChoice == "R")
            {
                genderSort.Sort();

                genderSort.Reverse();
                Console.WriteLine("\t\t\t\tZ-A REVERSE ALPHABET FORMAT");

                Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nFirstname\tRec\tLastname\t\tStudent ID\t\tBirthDate\tGender\r\n----------------------------------------------------------------------------------------------------");

                for (int y = 0; y < genderSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);

                }

            }
            else if (sortGenderChoice == "N")
            {
                genderSort.Sort();
                Console.WriteLine("\t\t\t\tA-Z NORMAL ALPHABET FORMAT");

                Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nFirstname\tRec\tLastname\t\tStudent ID\t\tBirthDate\tGender\r\n----------------------------------------------------------------------------------------------------");

                for (int y = 0; y < genderSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);

                }
            }

            if(sortGenderChoice == "R" || sortGenderChoice == "N")
            {
                List<string> listToDel = File.ReadAllLines(Location).ToList();
                Console.WriteLine("\n\t\t\t\t\t#####BONUS SORTING PROCESSES#####");
                List<string> fNameValues = new List<string>(); //creates a new list holder for values of lastname
                for (int i = 3; i < listToDel.Count; i++) //a loop to process the split solution for retrieving the IDVALUE
                {

                    string[] fields = listToDel[i].Split('\t');
                    fNameValues.Add(fields[3]); //adds the substring 1(which in this case is ID) of fields array to list holder for values of l
                }

                var fNameArr = fNameValues.ToArray(); //converts the list to an array for better modification, assumes the role for array holder for values of ID


                string[] fnameValArr = SortLengthDescend(fNameArr);

                Console.WriteLine("\n\n----------Ascending by length[LENGTH]-----------");
                Console.WriteLine("----------\r\nFirstname\r\n----------");

                for (int i = 0; i < fnameValArr.Length; i++)
                {
                    Console.WriteLine(fnameValArr[i]); //printsout each index of the array holder for values of lastname

                }
                Console.WriteLine("\n\n----------Descending by length[LENGTH]-----------");
                Console.WriteLine("----------\r\nFirstname\r\n----------");

                Array.Reverse(fnameValArr);

                for (int i = 0; i < fnameValArr.Length; i++)
                {
                    Console.WriteLine(fnameValArr[i]); //printsout each index of the array holder for values of lastname

                }
            }
            

            return (genderSort);
        }
        public static List<string> SortingGender(string Location)
        {
            List<string> quotelist = File.ReadAllLines(Location).ToList();

            List<string> valHolder = new List<string>();
            List<string> recSort = new List<string>();
            List<string> idSort = new List<string>();
            List<string> lNameSort = new List<string>();
            List<string> fNameSort = new List<string>();
            List<string> bDateSort = new List<string>();
            List<string> genderSort = new List<string>();
            List<string> categories = new List<string>();

            string[] data = File.ReadAllLines(Location);
            int column = 8;
            for (int p = 3; p < data.Length; p++)
            {

                string[] fields1 = quotelist[p].Split('\t');
                valHolder.Add("d%" + fields1[0]);
                valHolder.Add("d!" + fields1[1]);
                valHolder.Add("d@" + fields1[2]);
                valHolder.Add("d#" + fields1[3]);
                valHolder.Add("d^" + fields1[6]);
                valHolder.Add("d*" + fields1[8]);
            }
            var valVariable = valHolder.ToArray();
            List<string> valHolder2 = new List<string>();


            for (int z = 0; z < valVariable.Length; z++)
            {
                int count = 0;
                if (valVariable[z].Contains("%"))
                {
                    recSort.Add(valVariable[z].Split('%')[1]);
                }
                if (valVariable[z].Contains("!"))
                {
                    idSort.Add(valVariable[z].Split('!')[1]);
                }

                else if (valVariable[z].Contains("@"))
                {
                    lNameSort.Add(valVariable[z].Split("@")[1]);

                }
                else if (valVariable[z].Contains("#"))
                {
                    fNameSort.Add(valVariable[z].Split('#')[1]);

                }
                else if (valVariable[z].Contains("^"))
                {
                    bDateSort.Add(valVariable[z].Split('^')[1]);
                }
                else if (valVariable[z].Contains("*"))
                {
                    genderSort.Add(valVariable[z].Split('*')[1] + "\t" + valVariable[z - 5].Split('%')[1].ToString() + "\t" + valVariable[z - 3].Split('@')[1].ToString() +
                        "\t" + valVariable[z - 2].Split('#')[1].ToString() + "\t\t\t" + valVariable[z - 1].Split('^')[1].ToString() + "\t\t" + valVariable[z - 4].Split('!')[1].ToString());
                }
            }

            Console.WriteLine("Do you want to sort by: [M]Male Priority, [F]Female Priority");
            string sortGenderChoice = Console.ReadLine().ToUpper();
            if (sortGenderChoice == "M")
            {
                genderSort.Sort();

                genderSort.Reverse();


            }
            else if (sortGenderChoice == "F")
            {
                genderSort.Sort();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nGender\tRec\tLastname\t\tFirstname\t\tBirthDate\t\tStudent ID\r\n----------------------------------------------------------------------------------------------------");


            for (int y = 0; y < idSort.Count; y++)
            {
                Console.WriteLine(genderSort[y]);

            }

            return (genderSort);
        }
        public static List<string> SortingbDate(string Location)
        {
            List<string> quotelist = File.ReadAllLines(Location).ToList();

            List<string> valHolder = new List<string>();
            List<string> recSort = new List<string>();
            List<string> idSort = new List<string>();
            List<string> lNameSort = new List<string>();
            List<string> fNameSort = new List<string>();
            List<string> bDateSort = new List<string>();
            List<string> genderSort = new List<string>();
            List<string> categories = new List<string>();

            string[] data = File.ReadAllLines(Location);
            int column = 8;
            for (int p = 3; p < data.Length; p++)
            {

                string[] fields1 = quotelist[p].Split('\t');
                valHolder.Add("d%" + fields1[0]);
                valHolder.Add("d!" + fields1[1]);
                valHolder.Add("d@" + fields1[2]);
                valHolder.Add("d#" + fields1[3]);
                valHolder.Add(fields1[6]);
                valHolder.Add("d*" + fields1[8]);
            }
            var valVariable = valHolder.ToArray();
            List<string> valHolder2 = new List<string>();


            for (int z = 0; z < valVariable.Length; z++)
            {
                int count = 0;
                if (valVariable[z].Contains("%"))
                {
                    recSort.Add(valVariable[z].Split('%')[1]);
                }
                if (valVariable[z].Contains("!"))
                {
                    idSort.Add(valVariable[z].Split('!')[1]);
                }

                else if (valVariable[z].Contains("@"))
                {
                    lNameSort.Add(valVariable[z].Split("@")[1]);

                }
                else if (valVariable[z].Contains("#"))
                {
                    fNameSort.Add(valVariable[z].Split('#')[1]);

                }
                else if (valVariable[z].Contains("^"))
                {
                    bDateSort.Add(valVariable[z].Split('^')[1]);
                }
                else if (valVariable[z].Contains("*"))
                {
                    genderSort.Add(valVariable[z - 1].Trim('/').ToString() + "\t" + valVariable[z - 5].Split('%')[1].ToString()
                        + "\t" + valVariable[z - 4].Split('!')[1].ToString() + "\t\t" + valVariable[z - 2].Split('#')[1].ToString() + "\t\t" + valVariable[z - 3].Split('@')[1].ToString() + "\t" + valVariable[z].Split('*')[1]);
                }
            }

            Console.WriteLine("Do you want to sort by: [A]Ascending or [D]Descending");
            string sortGenderChoice = Console.ReadLine().ToUpper();
            if (sortGenderChoice == "D")
            {
                genderSort.Sort();
                genderSort.Reverse();

                Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nBirthDate\tRec\tStudentID\t\tLastName\t\tFirstName\tGender\r\n----------------------------------------------------------------------------------------------------");

                for (int y = 0; y < idSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);

                }

            }
            else if (sortGenderChoice == "A")
            {
                genderSort.Sort();

                Console.WriteLine("---------------------------------------------------------------------------------------------------\r\nBirthDate\tRec\tStudentID\t\tLastName\t\tFirstName\tGender\r\n----------------------------------------------------------------------------------------------------");

                for (int y = 0; y < idSort.Count; y++)
                {
                    Console.WriteLine(genderSort[y]);

                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            return (genderSort);
        }
        
        //FILTERING METHOD
        public static List<string> Filter(string Location, int reg, int reg1, string text)
        {
            var stringFilt = File.ReadAllText(Location);
            Console.WriteLine(stringFilt);

            Console.Clear();

            List<string> quotelist = File.ReadAllLines(Location).ToList();
            List<string> recFil = new List<string>();
            List<string> idFil = new List<string>();
            List<string> lNameFil = new List<string>();
            List<string> fNameFil = new List<string>();
            List<string> bDateFil = new List<string>();
            List<string> genderFil = new List<string>();
            List<string> filvalHolder = new List<string>();
            string[] data = File.ReadAllLines(Location);
            int column = 8;
            for (int p = 3; p < data.Length; p++)
            {

                string[] fields1 = quotelist[p].Split('\t');

                filvalHolder.Add("d%" + fields1[reg]);

                filvalHolder.Add("d!" + fields1[reg1]);

            }
            var valVariable = filvalHolder.ToArray();

            Console.WriteLine("\n\n----------####Filtering System####-----------");
            Console.WriteLine("\n---------------------\r\nRec\t" + text + "\r\n---------------------");


            for (int z = 0; z < valVariable.Length; z++)
            {
                if (valVariable[z].Contains("%"))
                {
                    recFil.Add(valVariable[z].Split('%')[1]);

                }
                else if (valVariable[z].Contains("!"))
                {
                    idFil.Add(valVariable[z - 1].Split('%')[1].ToString() + "\t" + valVariable[z].Split('!')[1]);
                }

            }

            for (int y = 0; y < idFil.Count; y++)
            {
                Console.WriteLine(idFil[y]);

            }
            return idFil;
        }
    }
}

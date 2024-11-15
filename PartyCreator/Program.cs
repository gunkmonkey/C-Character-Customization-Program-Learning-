/*
This program allows users to create a party in a
fantasy setting. The party can consist of 10 
characters, each with an ID, name, age, gender, class
weapon, and description.
The program allows users to (1) view all characters
created, (2) create a new character, (3) edit a
current character, and (4) delete a character.
*/
using System;
using System.IO;

string? readResult;
int maxCharacters = 10;

string[,] characterArray = new string[maxCharacters, 6];
string characterName = "";
string characterAge = "";
int charAge = 0;
string characterGender = "";
string characterClass = "";
string characterWeapon = "";
string characterDesc = "";

bool validEntry = false;
int charSelect = 0;
string menuSelection = "";

for (int i = 0; i < maxCharacters; i++)
{
    switch (i)
    {
        case 0:
            characterName = "Test";
            characterAge = "999";
            characterGender = "???";
            characterClass = "Default";
            characterWeapon = "???";
            characterDesc = "Test character";
            break;
        default:
            characterName = "";
            characterAge = "";
            characterGender = "";
            characterClass = "";
            characterWeapon = "";
            characterDesc = "";
            break;
    }
    characterArray[i, 0] = "Name: " + characterName;
    characterArray[i, 1] = "Age: " + characterAge;
    characterArray[i, 2] = "Gender: " + characterGender;
    characterArray[i, 3] = "Class: " + characterClass;
    characterArray[i, 4] = "Weapon: " + characterWeapon;
    characterArray[i, 5] = "Description: " + characterDesc;
}

//Menu Application
do
{    
    Console.Clear();

    Console.WriteLine("Welcome to the Character Creation Menu! Would you like to:\n");
    Console.WriteLine("1. View all stored characters");
    Console.WriteLine("2. Create a new character");
    Console.WriteLine("3. Edit a current character");
    Console.WriteLine("4. Delete a current character\n");
    Console.WriteLine("Please enter the number of your desired option.");
    Console.WriteLine("Type 'exit' to close the application.\n");

    readResult = Console.ReadLine();

    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        //Allows the user to view all characters stored.
        case "1":
            for (int i = 0; i < maxCharacters; i++)
            {
                if (characterArray[i,0] != "Name: ")
                {
                    for (int n = 0; n < 6; n++)
                    {
                        Console.WriteLine(characterArray[i,n]);
                    }
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        //Allows the user to add a character if room allows. Includes ID, name, age, gender, class, weapon, and desc.
        case "2":
            int characterCount = 0;

            for (int i = 0; i < maxCharacters; i++)
            {
                if (characterArray[i,0] != "Name: ")
                {
                    characterCount += 1;
                }
            }

            if (characterCount < maxCharacters)
            {
                Console.WriteLine($"Number of created characters: {characterCount}. Number of open slots remaining: {maxCharacters - characterCount}.\n");
                //Sets characterName
                do
                {
                    Console.WriteLine("Please enter the name of your character:");

                    readResult = Console.ReadLine();

                    if (readResult != null && readResult.Trim() != "")
                    {
                        characterName = readResult.ToLower();
                        validEntry = true;
                    }
                } while(validEntry == false);

                //Sets characterAge
                do
                {
                    Console.WriteLine("Please enter the age of your character:");

                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        validEntry = int.TryParse(readResult, out charAge);
                    }
                } while(validEntry == false);

                //Sets characterGender
                do
                {
                    Console.WriteLine("Please enter the gender of your character:");

                    readResult = Console.ReadLine();

                    if (readResult != null && readResult.Trim() != "")
                    {
                        characterGender = readResult.ToLower();
                        validEntry = true;
                    }
                } while(validEntry == false);
                
                //Sets characterClass
                do
                {
                    Console.WriteLine("Please enter the class of your character:");

                    readResult = Console.ReadLine();

                    if (readResult != null && readResult.Trim() != "")
                    {
                        characterClass = readResult.ToLower();
                        validEntry = true;
                    }
                } while(validEntry == false);

                //Sets characterWeapon
                do
                {
                    Console.WriteLine("Please enter the weapon of your character:");

                    readResult = Console.ReadLine();

                    if (readResult != null && readResult.Trim() != "")
                    {
                        characterWeapon = readResult.ToLower();
                        validEntry = true;
                    }
                } while(validEntry == false);

                //Sets characterDesc
                do
                {
                    Console.WriteLine("Please enter the description of your character:");

                    readResult = Console.ReadLine();

                    if (readResult != null && readResult.Trim() != "")
                    {
                        characterDesc = readResult.ToLower();
                        validEntry = true;
                    }
                } while(validEntry == false);

                characterArray[characterCount, 0] = "Name: " + characterName;
                characterArray[characterCount, 1] = "Age: " + charAge.ToString();
                characterArray[characterCount, 2] = "Gender: " + characterGender;
                characterArray[characterCount, 3] = "Class: " + characterClass;
                characterArray[characterCount, 4] = "Weapon: " + characterWeapon;
                characterArray[characterCount, 5] = "Description: " + characterDesc;

                Console.WriteLine($"Character {characterArray[characterCount, 0]} added!");
            }

            //Denial of creation
            else
            {
                Console.WriteLine("The maximum amount of characters has been reached. Please delete one before creating another.");
            }

            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        //Allows a user to edit a character's specific attributes.
        case "3":
            characterCount = 0;

            for (int i = 0; i < maxCharacters; i++)
            {
                if (characterArray[i,0] != "Name: ")
                {
                    characterCount++;
                    Console.WriteLine($"{i + 1}\t{characterArray[i,0]}");
                }
            }

            do
            {
                Console.WriteLine($"Select the number of the character to edit (1 - {characterCount})");

                readResult = Console.ReadLine();

                if (readResult != null)
                    {
                        validEntry = int.TryParse(readResult, out charSelect);
                        charSelect--;
                        if (charSelect < 0 || charSelect > characterCount)
                            validEntry = false;
                    }
            } while(validEntry == false);

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{i + 1}.\t{characterArray[charSelect,i]}");
            }

            do
            {
                Console.WriteLine("Select the number of the attribute to edit (1 - 6)");
                
                int attributeSelect;

                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    validEntry = int.TryParse(readResult, out attributeSelect);
                    attributeSelect--;

                    switch (attributeSelect)
                    {
                        case 0:
                            do
                            {
                                Console.WriteLine($"Please enter the new name of {characterArray[charSelect,0]}:");

                                readResult = Console.ReadLine();

                                if (readResult != null && readResult.Trim() != "")
                                {
                                    characterName = readResult.ToLower();
                                    validEntry = true;
                                }
                            } while(validEntry == false);
                            characterArray[charSelect,0] = "Name: " + characterName;
                            Console.WriteLine("Character updated! Press the Enter key to continue");
                            readResult = Console.ReadLine();
                            break;
                        case 1:
                            do
                            {
                                Console.WriteLine($"Please enter the new age of {characterArray[charSelect,0]}:");

                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    validEntry = int.TryParse(readResult, out charAge);
                                }
                            } while(validEntry == false);
                            characterArray[charSelect,1] = "Age: " + characterAge;
                            Console.WriteLine("Character updated! Press the Enter key to continue");
                            readResult = Console.ReadLine();
                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine($"Please enter the gender of {characterArray[charSelect,0]}:");

                                readResult = Console.ReadLine();

                                if (readResult != null && readResult.Trim() != "")
                                {
                                    characterGender = readResult.ToLower();
                                    validEntry = true;
                                }
                            } while(validEntry == false);
                            characterArray[charSelect,2] = "Gender: " + characterGender;
                            Console.WriteLine("Character updated! Press the Enter key to continue");
                            readResult = Console.ReadLine();
                            break;
                        case 3:
                            do
                            {
                                Console.WriteLine($"Please enter the class of {characterArray[charSelect,0]}:");

                                readResult = Console.ReadLine();

                                if (readResult != null && readResult.Trim() != "")
                                {
                                    characterClass = readResult.ToLower();
                                    validEntry = true;
                                }
                            } while(validEntry == false);
                            characterArray[charSelect,3] = "Class: " + characterClass;
                            Console.WriteLine("Character updated! Press the Enter key to continue");
                            readResult = Console.ReadLine();
                            break;
                        case 4:
                            do
                            {
                                Console.WriteLine($"Please enter the weapon of {characterArray[charSelect,0]}:");

                                readResult = Console.ReadLine();

                                if (readResult != null && readResult.Trim() != "")
                                {
                                    characterWeapon = readResult.ToLower();
                                    validEntry = true;
                                }
                            } while(validEntry == false);
                            characterArray[charSelect,4] = "Weapon: " + characterWeapon;
                            Console.WriteLine("Character updated! Press the Enter key to continue");
                            readResult = Console.ReadLine();
                            break;
                        case 5:
                            do
                            {
                                Console.WriteLine($"Please enter the description of {characterArray[charSelect,0]}:");

                                readResult = Console.ReadLine();

                                if (readResult != null && readResult.Trim() != "")
                                {
                                    characterDesc = readResult.ToLower();
                                    validEntry = true;
                                }
                            } while(validEntry == false);
                            characterArray[charSelect,5] = "Description: " + characterDesc;
                            Console.WriteLine("Character updated! Press the Enter key to continue");
                            readResult = Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                }
            } while(validEntry == false);

            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();
            break;
        /*
        Allows a user to delete a character entirely.
        A record must be deleted, and records after 
        the one deleted must be moved up a row.
        */
        case "4":
            characterCount = 0;

            for (int i = 0; i < maxCharacters; i++)
            {
                if (characterArray[i,0] != "Name: ")
                {
                    characterCount++;
                    Console.WriteLine($"{i + 1}\t{characterArray[i,0]}");
                }
            }

            do
            {
                Console.WriteLine($"Select the number of the character to edit (1 - {characterCount})");

                readResult = Console.ReadLine();

                if (readResult != null)
                    {
                        validEntry = int.TryParse(readResult, out charSelect);
                        charSelect--;
                        if (charSelect < 0 || charSelect > 9)
                            validEntry = false;
                    }
            } while(validEntry == false);

            //Makes a loop based on characterCount (max) and charSelect (min)
            //Deletes values in charSelect and moves every subsequent record up a row
            characterArray[charSelect, 0] = "Name: ";
            characterArray[charSelect, 1] = "Age: ";
            characterArray[charSelect, 2] = "Gender: ";
            characterArray[charSelect, 3] = "Class: ";
            characterArray[charSelect, 4] = "Weapon: ";
            characterArray[charSelect, 5] = "Description: ";
            for (int i = charSelect; i < characterCount; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    characterArray[i,j] = characterArray[i+1,j];
                }      

                characterArray[i+1,0] = "Name: ";   
                characterArray[i+1,1] = "Age: ";   
                characterArray[i+1,2] = "Gender: ";   
                characterArray[i+1,3] = "Class: ";   
                characterArray[i+1,4] = "Weapon: ";   
                characterArray[i+1,5] = "Description: ";   

            }
            Console.WriteLine("Press the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        default:
            break;
    }

} while(menuSelection != "exit");
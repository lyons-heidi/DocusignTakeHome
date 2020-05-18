# DocusignTakeHome
C# take home project for docusign 

This project is created for Docusign. 
This is an app based project that runs in the console. Users can manually enter in a command and receive an output string.

## Structure:

### Person Class:
  This class represents a Person who is getting dressed based on the weather today. 
  When instantiated, it accepts a command string in the format "TEMPERATURE COMMA_SEPARATED_STEPS".
  

##### Attributes:
  - commands: A list of user-inputted commands
  - weather: The weather outside for the day. Can handle the cases for HOT or COLD 
  - finalResp: The output of the commands entered
  - visited: A list of steps that the user has already completed.
  
##### Methods:
  - ParseInput(string input):
      Takes in the user entered command string and parses out the weather and a list of commands.
  - ValidateData():
      This method loops thru the command strings and generates a finalResp string based on the given business logic.
      A finalResp string will be created regardless of its validity. 

## Unit Testing:
I wrote unit tests that cover all of the example edge cases to consider in the prompt. 

## Manual Testing:
To test manually, build and run the program. A console will appear where you can enter in a command or enter quit to exit the program. After each command is entered, the program will display the string output response.

## Notes:
I chose to separate the user interface (Program class) from the business logic and input parsing (Person class). The Person class does both the string parsing and the business logic because they seemed very related. Ideally they would be separated but for this project I kept them in the same class, in different methods.

My background is primarily in Python, so I used Microsoft's online documentation to help refresh my memory on C# syntax/styling.


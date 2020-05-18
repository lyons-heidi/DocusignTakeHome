# DocusignTakeHome
C# take home project for docusign 

This project is created for Docusign. 
This is an app based project that runs in the console. Users can manually enter in a command and receive an output string.

## Structure:

### Person Class:
  This class represents a Person who is getting dressed based on the weather today. 
  When instantiated, it accepts a command string in the format "TEMPERATURE COMMA_SEPARATED_STEPS".
  

##### Attributes:
  -commands: A list of user-inputted commands
  -weather: The weather outside for the day. Can handle the cases for HOT or COLD 
  -finalResp: The output of the commands entered
  -visited: A list of steps that the user has already completed.
  
##### Methods:
  - ParseInput(string input):
      Takes in the user entered command string and parses out the weather and a list of commands.
  - ValidateData():
      This method loops thru the command strings and generates a finalResp string based on the given business logic.
      A finalResp string will be created regardless of its validity. 

## Unit Testing:
I wrote unit tests that cover all of the example edge cases to consider in the prompt. 


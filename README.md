# PDFGenerator

## Installation

### [Download zip from release](https://github.com/Chatewgne/PDFGenerator/releases)

OR
### Clone from github
```
git clone https://github.com/Chatewgne/PDFGenerator
```

## How to use 

### Running the program
You will need an input file in the form of a .txt file containing commands and text lines. You can use the "myfile.txt" file available in the project.

Open the solution (PDFGenerator.sln) in Visual Studio and run the application.
In the console that pops up, enter the path to your input file i.e. :  
```
C:\Users\Alex\Documents\myfile.txt  
```
The program will generate a pdf file with the same name (i.e. myfile.pf) in the same folder.

### Input file formatting 
The supported commands are the following : 
- .large
- .normal and .regular (identical effects)
- .paragraph
- .fill 
- .nofill
- .bold
- .italic
- .indent X -> replace X by 0 for default indentation, a positive integer offsets to the right **from the default indentation** while a negative integer offsets to the left **from the default indentation**.   

The .indent command must come as the **last command** if several commands in a row are written.

Make sure there are no spaces after a command or it will not be recognized. 
Make sure there are no linebreaks in a text entry or some parts might be missing in the output pdf.

## Possible improvements
I couldn't find a quick easy way to add pagination. 
For the indent command I chose to use the absolute position rather than using the relative position, although it's not exactly what was expected it was easier to implement. 
I didn't refactor my code, but it is quite short and I think it is clear enough as it is.

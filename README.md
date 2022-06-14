# BlartVersenwald_III-
Program that will calculate number of occurrences of the the filename in the specified file


```
 Project created for programing test
 Author Niklas Rydén (c)2022-06-14
 
 The console aplication is writen in .NET 6
 ````
**Assignment:**
 1. Write a console program that takes one argument, a path to a file
 2. Open that file and count how many times its filename (minus the file extension) occurs in the file's contents.
 3. Create tests aiming.
 4. Nice error messages
 
 
 Build project
 To run: 
  Build project
  then just run
 ``` 
 BlartVersenwald_IIIProject.exe [path to file] 
 ```


 I Have stept out from the Assainment a litle and the program will count usage of the file name in three senarios and print it to the console

 1. Get all occurrences of the filename without the file extension
 2. Get all occurrences of the filename with the file extension
 3. Get all occurrences of the filename with and without the file extension
 
 The program will throw error
 - if file missing
 - if file extends 300MB
 - if it fail to read the text from the file
 - if the Text propery in GetFileNameOccurrencesInFile is null or empty

 Test:
 I created 10 test for the GetFileNameOccurrencesInFile class try to cover as mutch as possible.

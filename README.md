# SampleProject

Sample c # application developed using TDD and DDD methodologies. The story of the application is aimed to calculate the final positions of the rovers on
Mars starting from the coordinates specified in the input and following the commands specified in the input. The first line specifies the size of the area,
the second line the coordinates of the navigator and the third line the route the rover will take. The final location and status of the rover is indicated as output.
The commands 'L' means turning left, 'M' means walking forward, 'R' means turning right. The letter in the rows where the rover's coordinates are located indicates
the direction the rover is facing. The roaming information continues to be read until the blank enter command comes. Another traveler cannot begin walking until
he finishes his walk. If one of the roamers moves outside the specified area or if an invalid parameter is encountered, subsequent roamers will not proceed.

Test Input:
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

Expected Output:
1 3 N
5 1 E

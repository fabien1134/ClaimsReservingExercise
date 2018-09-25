Background
One of the major jobs that we do is claims reserving, which involves assessing how much money is likely to be paid in future in respect of the claims that arise from a set of insurance policies that have already been taken out. The statistical analysis of this is based around triangles of payment figures for previous claims.

The numbers in the triangle are the amounts of payments made in respect of claims on a particular block of insurance policies.
The block of claims will be broken into origin years. For example, all claims originally happening in 1996 will go into the 1996 row of the triangle.
For each origin year grouping of claims we will see development of payments over time as settlements are made. 
To do this in practice, it is easier to spot patterns if we �accumulate� the data in the triangle, so that rather than showing the amount paid in any particular development year, it shows the total amount paid in all development years up to and including the one we�re looking at. 

Example Input Data 
A short input file might contain the following: 

Product, Origin Year, Development Year, Incremental Value 
Comp, 1992, 1992, 110.0 
Comp, 1992, 1993, 170.0 
Comp, 1993, 1993, 200.0 
Non-Comp, 1990, 1990, 45.2 
Non-Comp, 1990, 1991, 64.8 
Non-Comp, 1990, 1993, 37.0 
Non-Comp, 1991, 1991, 50.0 
Non-Comp, 1991, 1992, 75.0 
Non-Comp, 1991, 1993, 25.0 
Non-Comp, 1992, 1992, 55.0 
Non-Comp, 1992, 1993, 85.0 
Non-Comp, 1993, 1993, 100.0 

This example file contains two triangles � one for a product called �Comp� and one for a product called �Non- Comp�. The first row contains column headings, and the subsequent rows contain the data, so, for example, for accidents occurring on the Non-Comp product in 1990, 45.2 was paid in 1990, 64.8 was paid in 1991 and 37 was paid in 1993. 

The output file corresponding to the above input file would be: 
1990, 4 
Comp, 0, 0, 0, 0, 0, 0, 0, 110, 280, 200 
Non-Comp, 45.2, 110, 110, 147, 50, 125, 150, 55, 140, 100 

The first line gives the earliest origin year (i.e. 1990) and the number of development years (in this case ranging from 1990 through to 1993 i.e. 4). 

After the first line, there is a line for each triangle. The first field in the line gives the name of the product. The subsequent fields are the accumulated triangle values.


The Problem

You are required to create a program to read in incremental payment data from a comma-separated text file, to accumulate the data and to display the results. This process represents the creation of the cumulative data triangle from the incremental data triangle above.

Browse for an input file
View / edit input data
Validate that the input data has no missing values
View output data


As much attention should be given to the intuitive nature of the UI as the structure of the code

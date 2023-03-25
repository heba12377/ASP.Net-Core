# ASP.Net-Core
MVC Lab

### Day1 Requirements : 

Given a list of Cars, you will need to implement 2 pages:

First Page:
1.	Contains two different ways to list the cars
       a.	Using a table.
       b.	Using a list.
2.	Each car entity should have (Manufacturer, Model, Image, HtmlDescription, FirstUseDate)
3.	Display the name of the cars as ({Model} From {Manufacturer}).
4.	Display the usage duration (Seek for help for how to deal with DateTime).
5.	Display the HtmlDescription as rendered Html not as plain text.
6.	A button that redirects the user to a single element view.
7.	Image should be rendered inside a figure tag and the alt attribute and the figcaption tag should contain the name of the car ({Model} From {Manufacturer}).
Ex:
 
8.	A button that lets the user choose the rendering method.

Second Page:

1.	Details Page
2.	Contains the details of the element and message to tell whether the user came from a list or a table.




### Day2 Requirements : 

Having a ticket entity which has the following properties:
-	CreatedDate
-	IsClosed
-	Severity (enum)
-	Description

Severity is an enum that has three values (low, medium and high).

Developer is class that has the following properties:
-	Id
-	FirstName
-	LastName

1.	Create a form to add a ticket

     a.	Create a view model for the add from
2.	Add the entity to a local static list.
3.	Display the list in another action.





### Day3 Requirements : 

Having a ticket entity which has the following properties:
-	CreatedDate
-	IsClosed
-	Department (Complex Type)
-	Severity (enum)
-	Assignees (List<Developer>)
-	Description

Severity is an enum that has three values (low, medium and high).

Developer is class that has the following properties:
-	Id
-	FirstName
-	LastName

1.	Create a form to add a ticket
             a.	Create a view model for the add from
2.	Create a form to edit the ticket
3.	Add the entity to a local static list.
4.	Display the list in another action.




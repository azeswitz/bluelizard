Generic Repository based on:
http://blog.magnusmontin.net/2013/05/30/generic-dal-using-entity-framework/


Third Party Libraries:
AutoMapper 3.2.1
StructureMap 2.6.4.1
StructureMapMVC for StructureMap 2.x
Log4Net 2.0.3


Environment
Visual Studio 2013 Update 2
Entity Framework PowerTools
Web Essentials for 2013 Update 2


To Update Domain Model
Make database change
Add / Update BlueLizard.Domain object
Add / Update BlueLizard.Data mapping object
If new - add to context in BlueLizard.Data.Entities.cs
Tip - if creating multiple tables or more complex objects, create a separate data "stage"
project to execute the Entity Framework PowerTools to generate the code then copy/refactor the 
code into the target Data and Domain projects.

Use Fiddler2 to debug services.  
In the BlueLizard reference, the following is valid for the person service:
HEADERS
User-Agent: Fiddler
Host: localhost:43188
Content-Type: application/json; charset=utf-8

BODY
{
firstName: "Justin",
lastName: "Thyme",
middleName: "Nick",
streetAddress1: "Any St",
streetAddress2: "Apt 1",
city: "Sometown",
state: "VA",
zip: "22031",
phone: "111-222-3333",
email: "justatest@icfi.com",
createDate: "2014-07-13T19:04:32.107",
createdBy: "Test1",
updateDate: "2014-07-13T19:04:32.107",
updateBy: "Test1"
}


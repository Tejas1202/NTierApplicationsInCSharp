# NTierApplicationsInCSharp
Repository contains the fundamentals of how to create a Domain Driven Design architecture from a simple Monolithic application - Inspired by Steve Smith's (aka Ardalis) Pluralsight Course

A breif overview of this Repository:
- At first, only PluralSightBook.Website ASP.NET Web Forms project was only added and all the business logic and data access was written there itself in Page_Load or Button_Click event
(An example of Monolithic Application)
  - Hence our Data and business logic was now tightly coupled to the UI and hence change in any one leads to change in UI
  - We were violating the DRY (Don't Repeat Yourself) principle as the same code has to be duplicated in other code behind (aspx) pages
  
- Hence, we created two seperate projects PluralSight.BLL (Business Logic Layer) and PluralSight.DAL (Data Access Layer) to move the business logic and data access into their
respective layers. This is an example of Data-Centric N-Tier Architecture where all the dependencies points towards the Database
  - Now, we've slighly decoupled code where our Business Logic and Data access concerns are seperated
  - And we can re-use our Business logic at multiple places in our application and Data access can be changed independently
  - But the problem with this architecture is all our dependencies points towards the database, and so our business logic is tightly coupled to data access
  
- Hence, for creating Domain Driven Design architecture, PluralSightBook.Core and PluralSightBook.Infrastructure projects were added
  - Now, all the projects like PluralSightBook.Website and PluralSightBook.Web (an API) will reference Core and call its Services
  - We'll use DIP (Dependency Inversion Priciple) to invert Dependencies from Infrastructure to Core and hence our Core doesn't have a dependency on Infrastructure

- JustShowMeMyFriends is an exe in this enterprise application and it talks to Api rather than using our Infrastructure directly (to avoid firewall issues).
  - All we need to do was to implement Core Interfaces and implement our logic by calling Api rather than Infrastructure.
  
Summary:
  - All our different front end applications (Api, WebApp, Console) are re-using Core interfaces and none of them is dependent on the Infrastructure directly.
  - This type of architecture also leads to applications that are highly loosely coupled, testable, extensible and re-usable
  
Note: Not all the things are neatly arranged and it'll still be much more clear if you actually go through Steve's PluralSight Course.
More info: https://github.com/ardalis/CleanArchitecture

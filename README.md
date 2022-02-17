# Refactoring task

Following solution is an example of a shortener for links.
It consists of 2 api's one for data access logic and another one for business layer logic.
To keep it short in this document we will refer to them by dataApi and logicApi.
LogicApi is exposes towards external integration. DataApi is for internal use only.
Fork the solution into your own account to solve the tasks.


Requirements for the refactoring of the code base are the following:
Set up the data access layer this includes:
- Set up the context. Database restrictions : SQL Server.
- Set up the data model configurations.
- Ensure that the saved links are available only for a period of 7 days which can be extened in the future without the need to contact a developer. 
- Ensure that the connection string and other types of secrets are not stored in the code base.
- Treat generated links as sensitive data. (For example purpose right now.)
- Ensure that the service is performant even with high amounts of data stored.

Set up business layer logic:
- Ensure that there is an easy to access and review documentation of the api that can be used for integration with it.
- Ensure the logicApi can call and execute methods on the dataApi via HTTP.
- Refactor the api to follow the rules of SOLID.
- There are serveval tests in the UnitTest library, some of them probably are outdated. Create a set of tests that will ensure that the logicApi is working as expected.
- Reduce the number of calls to the dataApi whenever possible.
- Ensure that the connection string and other types of secrets are not stored in the code base.
- Ensure high availability and resiliency of the logicApi.
- Add a method that will process high amount of data(links) asynchronously. If any error/exception in the processing occurs create a mechanism that would restart the process with minimal effort from the user.
- The algorithm might change in the future ensure that there exists a mechanism for smooth transitioning towards a the new implementation.
- Ensure that the developers can pin point the cause of a failure in production effectively.


Additional requirements:

- Recommend a system design diagram of the running solution.
- Recommend protection mechanisms.
- Recommend a effective autoscaling strategy.
- Recommend a effective monitoring strategy.
- Recommend a deployment strategy that will lower the cost of maitaining the solution running.
- Recommend a strategy for compute provisioning.
- Recommend a CI/CD strategy that will ensure that deployment is done only in case that tests are passing. And that the running time for a deployment is optimised.
- Recommend a strategy for geo-redundancy of the solution.


# AMPmockDB
Mock API used while the development of the front side of the AMP portfolio management project. It provides set of endpoints allowing the management of portfolios, investors and assets.
It also consumes the FMP API for the calculation of the portflio's risk and return

### Followed pattern
- REST

### FMP API
"https://financialmodelingprep.com/"

### Used technologies/frameworks
- SQL Server
- .NET Framework 4.7.2
- EntityFramework
- OAuth 2.0

### Project architecture
    ```
    - Controllers (set of controllers per entity)
    - DBContext (database context and models)
    - Models (AuthorizationServerProvider and HttpHelper)
    - Repository (GeneralRepository, its contract, and userRepository for the access control)
    ```
### Endpoitns definition
  Check this link "https://documenter.getpostman.com/view/8729406/TVK5bgDv" 

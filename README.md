**AZURE DEPLOYED WEBSITE:
https://checkmatedemo.azurewebsites.net**
- Visit this link to check our Web App Live!


**Prerequisites**

1.) .NET Core SDK: Install the latest version of the .NET Core SDK from https://dotnet.microsoft.com/download.

2.) Azure Account: (Optional) For cloud deployment, create a free Azure account at https://azure.microsoft.com/free/.

3.) SQL Server or Azure SQL Database: Choose and setup your desired database.

4.) Git: Install Git on your system from https://git-scm.com/

**Steps**

1.) Clone the Repository: 
  - git clone https://github.com/BaronDV/CheckMate.git
    
2.) Configuration:
- appsettings.json:
  - Update ConnectionStrings with your database connection information.
  - If using Azure Active Directory, configure the AzureAd section with your tenant ID, client ID, etc.

3.) Restore Dependencies:
  - dotnet restore
    
4.) Apply Database Migrations:
  - dotnet ef database update

5.) Run the Application:
  - dotnet run
  - Open your browser and navigate to https://localhost:5001 (or your specified port).

**Azure Deployment (Optional)**

1.) Create an Azure Web App:
  - Log in to the Azure portal.
  - Create a new Web App resource.
  - Choose your desired configuration (pricing tier, region, etc.).\
    
2.)Publish from Visual Studio:
- Right-click your project in Visual Studio.
- Choose "Publish."
- Select "Azure" as your target and follow the instructions.

**Additional Configuration (Active Directory)**

If you're using Active Directory, follow these steps:
1. Register CheckMate in Azure AD:
  - Go to your Azure AD tenant in the Azure portal.
  - Register CheckMate as an application.
  - Note the Client ID and Tenant ID for use in appsettings.json.
    
2. Configure CheckMate for AD:
  - In appsettings.json, update the AzureAd section with the correct values.
  - Ensure your Active Directory is properly configured for single sign-on.

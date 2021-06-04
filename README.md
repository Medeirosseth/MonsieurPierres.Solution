#### Pierres Bakery 2.0

#### By _**:neckbeard:Seth Medeiros**_

![]()

## Technologies Used

- _HTML_
- _CSS_
- _C#_
- _MYSQL_
- _ASP.NET core MVC_
- \_Entity Framework Core

## Description:memo:

_This project was designed to practice building basic web applications with C# using mysql databases, many to many relationships, and log in authorization and authentication_
![ScreenShot](/SQLchart.png)

## Setup and Use

<details>
  <summary>Setup/installation Requirements:open_file_folder:</summary>
  
  ### Prerequisites

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- A text editor like [VS Code](https://code.visualstudio.com/)
- A command line interface like Terminal or GitBash to run and interact with the console app.
- [MySQL Community Server][https://dev.mysql.com/downloads/file/?id=484914]

### Installation

1. Clone the repository: `$ git clone https://github.com/Medeirosseth/MonsieurPierres.Solution`
2. Navigate to the `MonsieurPierres.Solution/` directory on your computer
3. Open with your preferred text editor to view the code base
4. To setup a SQL database using MySQL:
   - Create an `appsettings.json` file in the `{Factory}` directory
   - Copy the text box below and paste into the `appsettings.json` file, replacing `<password>` with your MySQL password:
     {
     "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Port=3306;database=ENTERNAMEDESIRED;uid=root;pwd=<password>;"
     }
     }
   - Open your terminal and run the command: `mysql -uroot -p<mysql_password>` (replace `<mysql_password>` with your MySQL password) and select the enter key to launch MySQL servers
   - Type the following commands to setup the database:
     - `CREATE DATABASE Salon;` to make a new database
     - `USE Salon;` to connect to the new database
     - `CREATE TABLE {template_category (TemplateCategory INT, SomeProperty VARCHAR (255))};` to create a `{template_category}` table
     - `CREATE TABLE {template_item (TemplateItemId INT, TemplateCategoryId Int)};` to create another new `{template_item}` table
5. To run the console app:
   - Navigate to `{MonsieurPierres.Solution/Pierres}` in your command line
   - Run the command `dotnet restore` to restore the dependencies that are listed in `{Template.csproj}`
   - Run the command `dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0`
   - Run the command `dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2`
   - Run the command `dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0`
   - Run the command `dotnet build` to build the project and its dependencies into a set of binaries
   - Finally, run the command `dotnet run` to run the project!
   - Note: `dotnet run` also restores and builds the project, so you can use this single command to start the console app
6. Visit the application via web browser at: `localhost:5000/`
</details>

## Known Bugs :no_entry_sign: :bug:

- _None known_

## License

<details>
  <summary>MIT</summary>
Copyright <2021> <Seth Medeiros>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

</details>

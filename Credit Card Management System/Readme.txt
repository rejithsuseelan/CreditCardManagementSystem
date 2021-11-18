Scaffold-DbContext "Data Source=D01SMC0222\SQLEXPRESS2017;Initial Catalog=CreditCardManagementSystem;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context CCMSDBContext -f


Scaffold-DbContext -Connection "Server=D01SMC0222\SQLEXPRESS2017;Database=CreditCardManagementSystem;Integrated Security=True;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -context CCMSDBContext -force
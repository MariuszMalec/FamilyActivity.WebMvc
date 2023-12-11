# Activity
1. seed data using sql commands (insert only one activity)

# use sql scripts to create database with more activities
look folder SqlQuery

# migration daypilot
add-migration InitWorkOrderDb -context WorkOrderDbContext
update-database -context WorkOrderDbContext

# or
 Add-Migration InitialActivityDb -Context ApplicationContext -OutputDir .\Migrations\MySql
 Add-Migration InitialWorkOrderDbMySql -Context WorkOrderDbContext -OutputDir .\Migrations\MySql
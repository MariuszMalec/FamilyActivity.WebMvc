# Activity
1. seed data using sql commands (insert only one activity)

# use sql scripts to create database with more activities
look folder SqlQuery

# migration daypilot and activity
add-migration InitWorkOrderDb -context WorkOrderDbContext
update-database -context WorkOrderDbContext

add-migration InitActivity -context ApplicationContext
update-database -context ApplicationContext

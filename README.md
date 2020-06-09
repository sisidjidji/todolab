# todolab
Lab 26: Todo API + Scaffold Identity Database
- Set up your API for Todos
  - Use repository pattern
  - Todo approximately like what is above
- Set up a TodoUser + UserDbContext
- Make sure both DBs exist
Todo Model:
- title/text
- dueDate
- assignee
- difficulty rating (1-5 stars)
User Model:
whatever you want
Stretch Goal:
Add tests for controller actions
 (edited) 

The Identity setup steps we wrote down:
1. Inherit from IdentityUser
2. Inherit from IdentityDbContext<MyUser>
2a. Make sure it has the options constructor
3. AddDbContext() in Startup
3a. Set connection string
4. Add-Migration -Context UserDbContext
5. Update-Database
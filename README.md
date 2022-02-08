## BookStore API
-----------------
- books store API is an ASP.NET api using C# programming language 
- the API utilizes all CRUD operations for the Books that is adding, get a book, update and delete

- the API also has users operations that is register , login and delete
- the users operation include jwt authenticatios for authorizing some  routes as noted below
- the jwt tokens expires after 120 min and carries username, name, issuer, audience  and email

### Books Endpoints :book:
--------------------
- /books :GET: The endpoint gets all the books in the record :lemon:
- /books/id :GET: The endpoint gets a single book by id :lemon: 
- /books :POST: The endpoint create a book  takes book json {title:"",description:""}, :key: requires jwt auth :pineapple:
- /books/id :UPDATE: The endpoint updates a book takes a json {title:"",description:""}, :key: requires jwt auth :pear:
- /books/id :DELETE: The endpoint deletes a book from records, :key: requires jwt auth :apple:

### Users Endpoints :office_worker:
--------------------
- /users :GET: The endpoint gets all users, :key: requires jwt auth {with admin role} :lemon:
- /users :POST: Registers a new user, takes a json object {name:"",username:"",password:"",email:""} :pineapple:
- /users/login :POST: The endpoint login an new user and genrates a jwt token for user  :pineapple:
- /users :UPDATE: Edit user information, not fully implimented,:key: requires jwt auth  :sob: :hot_face:
- /users :DELETE: The endpoint  deletes a user from the records, :key: requires jwt auth   :apple:

### code info :computer:
The code embraces depeceny injections.
Decoupling strategy int the services folder which represents the repositories
the controllers utilizes the services interfaces to serve requests.
The database used postgress is online hosted at amazon ec2 secured from Heroku services and uses the sql in the models folder to generate the tables.

### deployment info :bow_and_arrow:
The code has 3 branches master, deploy and heroku
Deploy runs github actions to deploy the code on Azure while heroku should deploy to heroku
The API is currently running on Azure through the deploy github branch at 
https://muchira-books-api.azurewebsites.net/ 

### contributers :technologist: :technologist:
# muchira junior
https://github.com/muchirajunior

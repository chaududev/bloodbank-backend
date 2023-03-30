
                <div>
                    <h3>Install</h3>
                    <ul class="item__infos">
                        <li>Clone the repo: <code>git clone https://github.com/chauuduu/BloodBankWeb</code></li>
                        <li>Create database in MSSQL: <code>create database BloodBankDB </code> and configure in <code>appsetting.json</code> if you want</li>
                        <li>Install database: <code>cd Insfrastructure </code> and  <code>dotnet ef database update</code> </li>
                        <li>Run project: <code>dotnet run</code></li>
                    </ul>
                </div>
                <h3>Structure</h3>

               
<pre><code class="bash">
BloodBankWeb
├──domain    # model containing all entities, enum, base, value object,...
│  ├── entity 
│  ├── enum  
│  ├── valueobject  
└──└── base   
│
│──insfrucstrure    # storage database, migration, handle and directly interact with database     
│  ├── data
│  ├── migrations
│  ├── irepository
└──└── repository
│
│──application    #handle business logic, and interact with the database through the repository layer
│  ├── iservice
└──└── service
│
│──ui
│  ├── viewsmodel 
│  ├── apicontroller
│  ├── areas
│  ├── controllers
│  ├── mapper
│  ├── views
└──└── wwwroot   #include css,js, fonts, lib, uploads
</code></pre>

              
               

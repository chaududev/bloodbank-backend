 <div class="docs-article docs--start" id="Install">
                    <h3>Install</h3>
                    <ul class="item__infos">
                        <li>Clone the repo : <code>git clone https://github.com/chauuduu/BloodBankWeb.git</code></li>
                       <li>Install database in package Infrastructure :<code>PM > update-database</code> </li>
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

              
               
